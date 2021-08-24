using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject Player;
    GameObject PlayerGrabPoint;

    bool isPlayerEnter;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //플레이어 객체 소환
        PlayerGrabPoint = GameObject.FindGameObjectWithTag("grabPoint"); //플레이어 아이템 잡을 부분 객체 소환
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isPlayerEnter)
        {
            Debug.Log("MouseXPressed");
            transform.SetParent(PlayerGrabPoint.transform); //아이템을 GrabPoint에 종속시키는 부분.
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);


            isPlayerEnter = false;


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            isPlayerEnter = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            isPlayerEnter = false;

        }
    }
}
