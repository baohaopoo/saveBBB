using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    GameObject playerGrabPoint;

    private PlayerInput playerInput; 
    bool isPicking;


    void Start()
    {
        playerGrabPoint = GameObject.FindGameObjectWithTag("grabPoint"); //플레이어 아이템 잡을 부분 객체 소환

    }

    void Update()
    {
        if (isPicking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("enter Player");
                transform.SetParent(playerGrabPoint.transform); //아이템을 GrabPoint에 종속시키는 부분.
                transform.localPosition = new Vector3(-0.53f, -0.82f, 0.22f);
                transform.rotation = FindObjectOfType<PlayerController>().transform.rotation;

            }
        }

        else if (!isPicking)
        {
            int fall = -1;
            if (Input.GetMouseButtonDown(0))
            {

                playerGrabPoint.transform.DetachChildren();
                while (transform.position.y == 0)
                    transform.position = new Vector3(0, 0 + fall, 0);
                //playerGrabPoint.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);


            }

        }

        isPicking = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isPicking = true;
    }

}
