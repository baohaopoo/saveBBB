using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class water : MonoBehaviourPun
{
    private static bool isWater = false; //물속 안에 있는가 
    [SerializeField]
    private float waterDrag; //물속의 중력 
    private float originDrag;//원래 중력 
    [SerializeField]
    private Color waterColor; //물색깔
    [SerializeField]
    private float waterFogDensity; //물속의 탁함 정도 

    private Color originColor;//원래 색깔 
    private float originFogDensity;

    private AudioSource waterAudio;

    // Start is called before the first frame update
    void Start()
    {
        waterAudio = GetComponent<AudioSource>();
        originColor = RenderSettings.fogColor;
        originFogDensity = RenderSettings.fogDensity;

        originDrag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            InWater(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            OutWater(other);
        }
    }

    private void InWater(Collider player)
    {

        waterAudio.Play();
        isWater = true;
        player.transform.GetComponent<Rigidbody>().drag = waterDrag;

        RenderSettings.fogColor = waterColor;
        RenderSettings.fogDensity = waterFogDensity;
        Debug.Log("들어왔닝?");
    }
    private void OutWater(Collider player)
    {



        if (isWater)
        {
            waterAudio.Stop();
            isWater = false;
            player.transform.GetComponent<Rigidbody>().drag = originDrag;
            RenderSettings.fogColor = originColor;
            RenderSettings.fogDensity = originFogDensity;
        }
    }
}
