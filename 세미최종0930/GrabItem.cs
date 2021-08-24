using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    GameObject playerGrabPoint;
    GameObject box;
    bool isPicking;
    // Start is called before the first frame update
    void Start()
    {
        playerGrabPoint = GameObject.FindGameObjectWithTag("grabPoint"); //플레이어 아이템 잡을 부분 객체 소환

    }

    // Update is called once per frame
    void Update()
    {
        if (isPicking)
        {
            if (Input.GetMouseButtonDown(0))
            {


                Debug.Log("enter Player");
                //isPlayerEnter = false;

                transform.SetParent(playerGrabPoint.transform); //아이템을 GrabPoint에 종속시키는 부분.
                transform.localPosition = Vector3.zero;
                transform.rotation = new Quaternion(0, 0, 0, 0);




            }
        }

        else if (!isPicking)
        {
            int fall = -1;
            if (Input.GetMouseButtonDown(0))
            {

                playerGrabPoint.transform.DetachChildren();
                while (transform.position.y == 0)
                    transform.position = new Vector3(0, 0+fall, 0);
               //playerGrabPoint.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);


            }




        }

   
    }
    private void OnTriggerEnter(Collider other)
    {
        isPicking = true;
       
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("나갔어");
    //    isPicking = false;
    //}
}
