using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Open_Closet : MonoBehaviourPun
{
    private Animator closetAnimator;
    private bool IsOpen = false;
    
    private void Start()
    {
        closetAnimator = GetComponent<Animator>();

    }
    private void Update()
    {

    }



    public void goclosetani()
    {
        photonView.RPC("ClosetAnimation", RpcTarget.All);
    
    }
    [PunRPC]
    public void ClosetAnimation()
    {
        //closetAnimator.SetBool("Open", true);
        if (IsOpen == false)
        {
            Debug.Log("열림");
            closetAnimator.SetBool("Open", true);
            IsOpen = true;
        }
        else if (IsOpen == true)
        {
            Debug.Log("닫힘");
            closetAnimator.SetBool("Open", false);
            IsOpen = false;
        }
    }
}
