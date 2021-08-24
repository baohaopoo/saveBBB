using System.Collections;
using System.Collections.Generic;

using Photon.Pun; 
using Photon.Realtime; 

using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1"; //게임 버전
    private static string roomname;

    public Button startButton, goButton;
    public TMP_InputField nicknameinput, roominput; //인풋필드

    //public InputField nicknameinput, roominput;


    public TextMeshProUGUI inputplayer, inputroom; //roomlist용 코드

    public GameObject Roomlist;
    public GameObject pause;
    private bool isclickgo = false;
    private string add;
    private int gocnt = 0;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings(); //마스터 서버 연결


        // startButton.interactable = false;
        gocnt = 0;

    }


    //서버 연결
    public override void OnConnectedToMaster() //connect가 연결이 되면 콜백함수임. 여기서 콜백함수란 앞의 connet함수가 잘되어야 이 함수가 된다는의미.
    {

        Debug.Log("서버 접속 완료");

    }

    //서버 연결끊기
    public override void OnDisconnected(DisconnectCause cause)
    {

        Debug.Log("연결끊김");
        PhotonNetwork.ConnectUsingSettings(); //마스터 서버 재연결
    }


    public void ongo() //플레이어 닉네임과 방 이름 저장
    {
        isclickgo = true;


        // PhotonNetwork.NickName = nicknameinput.text.ToString();

        PhotonNetwork.LocalPlayer.NickName = nicknameinput.text.ToString(); //플레이어 이름 정해주기 , 로컬 이름에 nicknameinput에서 받아온 text를 넣어준다.
        //roomname = roominput.text.ToString(); //roomname string에도 roominput.text받아온거를 넣어준다.   
        roomname = PlayerPrefs.GetString(roominput.text.ToString());
        gocnt += 1;
        Debug.Log("클릭했냐?");
        Debug.Log(isclickgo);


    }

    //startbutton 누르면
    public void Connect() {

        if (PhotonNetwork.IsConnected) //마스터에 연결되어있고
        {

            if (gocnt >= 1)
            {
                //   PhotonNetwork.JoinOrCreateRoom(roominput.text, new RoomOptions { MaxPlayers = 4 },)
                //CreateRoom(); //방만들기 정해준 이름으로

                PhotonNetwork.JoinOrCreateRoom(roominput.text, null, TypedLobby.Default);

            } else if (gocnt == 0)
            {
                pause.SetActive(true);
            }


            Debug.Log("방 생성 및 접속중..");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    //방만들기
    public void CreateRoom()
    {
        //룸옵션 주기
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.PublishUserId = true;

        PhotonNetwork.CreateRoom(roominput.text, new RoomOptions { MaxPlayers = 4 });


    }
    //방 만들기 콜백함수
    public override void OnCreatedRoom()
    {
        Debug.Log("방 만들기 완료");
    }


    //방 참가 콜백함수
    public override void OnJoinedRoom()
    {



        Vector3 randomPos;
        randomPos.x = -2;
        randomPos.y = 0;
        randomPos.z = 0;


        Debug.Log("방 참가 완료");
        PhotonNetwork.LoadLevel("Kidsroom"); //모든 룸 참가자가 Kidsroom씬을 로드하게 함.

    }




    //방만들기 실패 콜백함수
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("방 만들기 실패");
    }

    //방만들기 실패 콜백함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("방 참가 실패");
    }

    //랜덤 방 참가
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        //룸옵션 주기
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.PublishUserId = true;

    }

    //빈방이 없어 랜덤 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("랜덤 방 참가 실패");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });

    }

    ////채팅관련함수
    //public void Send()
    //{ 

    //    string msg = PhotonNetwork.NickName+":"+ 

    //}
    //public override void OnPlayerEnteredRoom(Player newPlayer)
    //{
    //    PV.RPC("ChatRPC", RpcTarget.All, "<color=yellow>" + newPlayer.NickName + "님이 참가하셨습니다</color>");
    //}
    public void Infoclose()
    {

        Roomlist.SetActive(false);



    }


    public void cautionclose()
    {

        pause.SetActive(false);



    }
    //roomlist버튼 누르면
    public void Info()
    {


        Roomlist.SetActive(true);

        if (isclickgo)
        {
            
            inputplayer.text = ""; //한번씩 초기화
            inputroom.text = ""; //한번씩 초기화
                
            string playerStr = "방에 있는 플레이어 목록 : ";
            for (int i = 0; i < nicknameinput.text.Length; i++) playerStr += nicknameinput.text;//;PhotonNetwork.PlayerList[i].NickName + ",";

            string roomname2 = roomname;

            inputplayer.text += nicknameinput.GetComponent<TMP_InputField>().text.ToString();// nicknameinput.text.ToString();
            inputroom.text += roominput.GetComponent<TMP_InputField>().text.ToString();// roomname2.ToString();// + playernum.ToString() + playerallnum.ToString();
        }
        else if(!isclickgo)
        {

            inputplayer.text = ""; //한번씩초기화
            inputroom.text = ""; //한번씩 초기화
            add = "...";
            inputplayer.text += add.ToString();
            inputroom.text += add.ToString();


        }

        if (PhotonNetwork.InRoom)
        {
  
            print("현재 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대 인원수 :" + PhotonNetwork.CurrentRoom.MaxPlayers);

        }
        else
        {

            print("마스터 서버에 접속한 인원수 :" + PhotonNetwork.CountOfPlayers);
            print("방 개수 : " + PhotonNetwork.CountOfRooms);
            print("모든 방에 있는 인원수 : " + PhotonNetwork.CountOfPlayersInRooms);
            print("로비에 있는지? : " + PhotonNetwork.InLobby);
            print("연결되었는지? :" + PhotonNetwork.IsConnected);
        
        }

    }

}
