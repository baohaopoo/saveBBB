using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Utility;

using Photon.Pun;
public class nicknameText : MonoBehaviourPun
{
    public TextMeshProUGUI nickname; //플레이어의 nickname을 데려와..
    private string name;
    private GameObject FollowCam; //main camera
    public GameObject playerpivot;
    Vector3 mypos;

    LobbyManager lobby;
    void Start()
    {
        
        photonView.RPC("show", RpcTarget.All); //모두에게 닉네임 보여주기
 

    }
    [PunRPC]
    public void show()
    {
        if (photonView.IsMine)
        {
            nickname.text = "";

            name = photonView.Owner.NickName;
            nickname.text += name.ToString();
        }

        if (!photonView.IsMine)
        {


            nickname.text = "";

            name = photonView.Owner.NickName;

            nickname.text += name.ToString();
        }

    
    }

    private void LateUpdate()
    {
 
        transform.position = playerpivot.transform.position;
   
        

        // transform
        Vector3 pos;
        pos.x = 0;// -18.4f;
        pos.y = 0;
        pos.z = 0;// -10.3f;
       // FollowCam.GetComponent<SmoothFollow>().transform.rotation
        transform.rotation = Camera.main.transform.rotation;
    }


}
