using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Doll_Action : MonoBehaviour
{

    GameObject player;
    GameObject playerGrabPoint;
    GameObject UIImage;
    AudioSource audioSource;
    Vector3 movement;
    bool isPlayerEnter;

    GameObject bo;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerGrabPoint = GameObject.FindGameObjectWithTag("grabPoint");
        UIImage = GameObject.FindGameObjectWithTag("UIImage");
        audioSource = GetComponent<AudioSource>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // audioSource.Play();
        pickup();
        
    }



    void pickup()
    {

        if (isPlayerEnter)
        {
            if (Input.GetMouseButton(0))
            {


                //부모를 grabPoint
                transform.SetParent(playerGrabPoint.transform);
                transform.localPosition = Vector3.zero;
                transform.rotation = new Quaternion(0, 0, 0, 0);





            }


        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) {
            isPlayerEnter = true;

        }
        



 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) {
            isPlayerEnter = false;

        }
    }
}
