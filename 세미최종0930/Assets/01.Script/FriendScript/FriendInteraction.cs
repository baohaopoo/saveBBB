using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FriendInteraction : MonoBehaviourPun
{
    public GameObject myCam;
    private Animator bearAnimator;

    private void Start()
    {
        bearAnimator = GetComponent<Animator>();
    }

    public void goOff()
    {
        photonView.RPC("FriendOff", RpcTarget.All);
    }
    [PunRPC]
    public void FriendOff()
    {
        gameObject.SetActive(false);
    }

    public void CamOn(bool onoff)
    {
        myCam.SetActive(onoff);
    }
    public void MeetAnim()
    {
        bearAnimator.SetTrigger("find");
    }
}
