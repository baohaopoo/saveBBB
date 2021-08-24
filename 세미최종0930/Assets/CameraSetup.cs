using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Utility;
public class CameraSetup : MonoBehaviourPun
{

    private GameObject FollowCam; //main camera
    public GameObject PlayerPibot;
    void Start()
    {
        //////maincamera가 플레이어만 보고 달려오는 부분 구현
        if (photonView.IsMine)
        {

            FollowCam = GameObject.Find("MainCamera");
            //FollowCam.GetComponent<SmoothFollow>().target = this.Player.transform;
            FollowCam.GetComponent<SmoothFollow>().target = PlayerPibot.transform;


        }

    }

    // Update is called once per frame
    void Update()
    {
       // Camera.main.GetComponent<SmoothFollow>().target = PlayerPibot.transform;

    }
}
