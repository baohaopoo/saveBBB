using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviourPunCallbacks
{
    public static int playernum = 0;

    public static int chnum;

    //싱글톤 접근용 프로퍼티 
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    public GameObject playerPrefab; //생성할 게임플레이어 (마스터)
    public GameObject player2Prefab; //생성할 게임플레이어 (마스터)
    public GameObject player3Prefab; //생성할 게임플레이어

    public PhotonView PV;
    public TextMeshProUGUI ChatText;
    public InputField ChatInput;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }
    void Start()
    {

        Vector3 randomPos;

        randomPos.x = 88.2153f;
        randomPos.y = 4.39109f;
        randomPos.z = 453.567f;

        Vector3 localPos;
        localPos.x = 85.2153f;
        localPos.y = 4.39109f;
        localPos.z = 450.567f;

       
        //if (PhotonNetwork.IsMasterClient)
        //{

        //    PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
        //    playernum = 1;
        //}
        //else if (!PhotonNetwork.IsMasterClient)
        //{

        //    PhotonNetwork.Instantiate(player2Prefab.name, randomPos, Quaternion.identity);
        //    playernum = 2;
        //}

        if (chnum == 1)
        {

            PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
                playernum = 1;
        }else if (chnum == 2)
        {

            PhotonNetwork.Instantiate(player2Prefab.name, randomPos, Quaternion.identity);
            playernum = 2;
        }else if(chnum ==3)
        {
            PhotonNetwork.Instantiate(player3Prefab.name, randomPos, Quaternion.identity);
            playernum = 3;
        }

    }




    public void Chat()
    {


        string msg = string.Format("[{0}] {1}", "<color=yellow>" + PhotonNetwork.LocalPlayer.NickName + "</color>", ChatInput.text);
      
        photonView.RPC("Send", RpcTarget.All, msg);
        //  ChatText.text = "";
        ChatInput.text = "";
    }


    //채팅관련함수
    [PunRPC]
    public void Send(string msg)
    {
        if (photonView.IsMine) // 포톤뷰가 내꺼여도 
            ChatText.text += "\n" + msg;
        if (!photonView.IsMine) //내것이 아니여도
            ChatText.text += "\n" + msg;

    }



}
