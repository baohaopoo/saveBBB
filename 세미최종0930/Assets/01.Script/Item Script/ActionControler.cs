using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ActionControler : MonoBehaviourPun
{

    public Transform PlayerPivot;
    public Transform FriendPivot;

    [SerializeField]
    private PlayerHaveItem playerhaveitem;

    [SerializeField]
    private GameObject player;

    private Animator pickupanim;
    private Item item;

    private FriendInteraction friendInter;
    private bool friendMeet = false;

    private int kFriendnum = 0;
    private int cFrinednum = 0;
    private FriendManager friendManager;

    private PlayerInput playerinput;

    private AudioSource ItemAudio;
    public AudioClip openClip;
    public AudioClip pickupClip;

    private void Start()
    {
        friendManager = GameObject.Find("FriendManager").GetComponent<FriendManager>();
        playerinput = player.GetComponent<PlayerInput>();
        pickupanim = player.GetComponent<Animator>();
        ItemAudio = GetComponent<AudioSource>();
    }

    public void minusFriend()
    {
        //죽으면 친구 하나 빼주는 곳 
        if (SceneManager.GetActiveScene().name == "Kidsroom")
        {
            //이곳이 키즈룸?
            if (kFriendnum > 0)
            {
                //친구 하나라도 구했다면
                kFriendnum -= 1; //하나는 삭제
                friendManager.updateKidsFriend(1);//키즈룸 남은 친구는 하나 더한다.
                friendManager.respawnKidsroomFriend(); //친구 리스폰

            }
        }
        else
        {
            //이곳이 씨티?
            if (cFrinednum > 0)
            {
                cFrinednum -= 1;
                friendManager.updateCityFriend(1);
                friendManager.respawnCityFriend();
            }

        }
        UIManager.instance.getScore(kFriendnum + cFrinednum); //점수갱신
    }


    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "Item")
        {

            if (photonView.IsMine) //로컬이라면,
            {

                item = other.transform.GetComponent<ItemPickup>().item;

                UIManager.instance.onactiontxt(); //UIManager로 actiontxt 켜줌
                UIManager.instance.getitem(other.transform.GetComponent<ItemPickup>().item.itemName);  //E키를 누르면 먹을수 있다.

                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickupanim.SetTrigger("isPickup"); //플레이어 애니메이션

                    if (other.transform != null) //정보를 가져왔을때
                    {

                        playerhaveitem.AcquireItem(other.transform.GetComponent<ItemPickup>().item); //아이템 장착
                        ItemAudio.PlayOneShot(pickupClip);


                    }

                    other.transform.GetComponent<ItemDestroy>().destroyall();
                    //Destroy(other.transform.gameObject);
                    UIManager.instance.offactiontxt();


                }

            }

        }


        if (other.tag == "CanOpen")
        {

            if (photonView.IsMine)
            {

                item = other.transform.GetComponent<ItemPickup>().item;

                UIManager.instance.onopentxt();
                UIManager.instance.openitem(other.transform.GetComponent<ItemPickup>().item.itemName);

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    pickupanim.SetTrigger("isPickup"); //플레이어 애니메이션
                    ItemAudio.PlayOneShot(openClip);
                    if (item.itemName == "아이템박스")
                    {
                        other.GetComponent<ItemBox>().goani();//아이템박스 열기닫기
                    }
                    else if (item.itemName == "옷장")
                    {
                        other.GetComponent<Open_Closet>().goclosetani();//옷장 열기닫기 
                    }
                }
            }

        }


        if (other.tag == "Friend")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {

                UIManager.instance.OffSaveUI();
                UIManager.instance.onallUI();
                playerinput.blockKey = false;
                UIManager.instance.offopentxt();
                friendMeet = false;
                friendInter.goOff();
                //other.gameObject.SetActive(false); //끈다
                //if (friendManager.isEnd())
                //{
                //    //끝났는지판정. 끝났다면 
                //    GameObject.Destroy(player);
                //    if (kFriendnum + cFrinednum >= 3)
                //    {
                //        //3개 이상 먹었으면 승리
                //        SceneManager.LoadScene("HappyEnding");
                //    }
                //    else
                //    {
                //        //3개 이상 먹지 못했다면 패배 
                //        SceneManager.LoadScene("BadEnding");
                //    }
                //}
            }

            if (photonView.IsMine) //로컬일때만, onactiontxt 켜져라.
            {

                //UIManager.instance.friendfind(other.transform.GetComponent<ItemPickup>().item.itemName);  
                //UIManager.instance.onactiontxt();

                item = other.transform.GetComponent<ItemPickup>().item;
                friendInter = other.GetComponent<FriendInteraction>();
                if (friendMeet == false)
                {
                    UIManager.instance.onopentxt();
                    UIManager.instance.friendfind(item.itemName);  //E키를 누르면 먹을수 있다.
                }
            }
                //E키를 누르면 먹어야하는데..
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickupanim.SetTrigger("isPickup"); //플레이어 애니메이션
                    UIManager.instance.offopentxt();
                    if (friendMeet == false)
                    {
                        friendMeet = true;
                        player.transform.position = other.gameObject.transform.position + new Vector3(0f, 0f, -4f);
                        //서로를 바라보세요
                        player.transform.LookAt(other.gameObject.transform);
                        other.gameObject.transform.LookAt(player.transform);
                        playerinput.blockKey = true; //플레이어 멈춤
                        friendInter.CamOn(true); //카메라 변경
                        friendInter.MeetAnim(); //친구 애니메이션 변경 
                        UIManager.instance.offallUI();

                        if (SceneManager.GetActiveScene().name == "Kidsroom")
                        {
                            //이곳은 키즈룸?
                            kFriendnum += 1;//키즈룸친구 1 추가
                            friendManager.updateKidsFriend(-1);  //남은 키즈룸친구 -1
                            if (item.itemName == "옹졸이")
                            {
                                UIManager.instance.OnsaveUI(1);
                            }
                            if (item.itemName == "움파룸파")
                            {
                                UIManager.instance.OnsaveUI(2);
                                Debug.Log("움파룸파");
                            }
                        }

                        else
                        {
                            //이곳은 씨티?
                            cFrinednum += 1;
                            friendManager.updateCityFriend(-1);  //남은 씨티친구 -1
                            if (item.itemName == "구미베어")
                            {
                                UIManager.instance.OnsaveUI(3);
                            }

                            if (item.itemName == "툼워치톡어")
                            {
                                UIManager.instance.OnsaveUI(4);
                                GameObject.Destroy(player);
                                if (kFriendnum + cFrinednum >= 3)
                                {
                                //3개 이상 먹었으면 승리
                                SceneManager.LoadScene("HappyEnding");
                                }
                                else
                                {
                                //3개 이상 먹지 못했다면 패배 
                                SceneManager.LoadScene("BadEnding");
                            }

                        }
                            if (item.itemName == "판")
                            {
                                UIManager.instance.OnsaveUI(5);

                            }

                        }

                        updateScore(); //ui업뎃
                    

                    //else if (friendMeet == true)
                    //{
                    //    UIManager.instance.offopentxt();
                    //    friendMeet = false;
                    //    Debug.Log("친구만나서 e");
                    //    other.gameObject.SetActive(false); //끈다
                    //}

                    //other.transform.GetComponent<ItemDestroy>().destroyall();


                }







            }
        }


    }


    private void Update()
    {
        if (friendManager.isEnd())
        {
            //끝났는지판정. 끝났다면 
            GameObject.Destroy(player);
            if (kFriendnum + cFrinednum >= 3)
            {
                //3개 이상 먹었으면 승리
                SceneManager.LoadScene("HappyEnding");
            }
            else
            {
                //3개 이상 먹지 못했다면 패배 
                SceneManager.LoadScene("BadEnding");
            }
        }
    }

    public void updateScore()
    {
        UIManager.instance.getScore(cFrinednum + kFriendnum); //ui업뎃
    }
    private void OnTriggerExit(Collider other)
    {

        if (photonView.IsMine)
        {
            UIManager.instance.offactiontxt();
            UIManager.instance.offopentxt();
        }

    }




}