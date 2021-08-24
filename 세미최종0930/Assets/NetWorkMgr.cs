using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetWorkMgr : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true; //방의 모든 클라이언트 마스터 클라이언트와 동일한 레벨을 로드해야하는가 ? -> yes
    }

    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings(); //즉시 온라인 상태로 만들어준다.
    }


    //포톤 서버에 접속
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(); //로비로 들어간다.
        //base.OnConnectedToMaster();
    }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.Instantiate("")
        //base.OnJoinedRoom();
    }
}
