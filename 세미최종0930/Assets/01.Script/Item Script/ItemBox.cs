using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ItemBox : MonoBehaviourPun
{

    private bool IsOpen = false;
    private Animator BoxAnimator;


    private Transform ItemboxTransform;
    [SerializeField]
    private GameObject bullet_item_prefab; //총알 아이템
    [SerializeField]
    private GameObject trap_item_prefab; //덫 아이템
    [SerializeField]
    private GameObject obstacle_item_prefab; //가시 아이템
    [SerializeField]
    private GameObject ham_item_prefab; //햄 아이템
    [SerializeField]
    private GameObject bread_item_prefab; //빵 아이템
    [SerializeField]
    private GameObject shield_item_prefab;



    public float SpawnTime = 300f; //아이템 스폰 시간 

    private float lastSpawnTime; //마지막 생성 시점

    private bool isFirstOpen;
    private void Start()
    {
        BoxAnimator = GetComponent<Animator>();
        ItemboxTransform = GetComponent<Transform>();

        lastSpawnTime = 0;
        isFirstOpen = true;
    }


    public void goani()
    {
        photonView.RPC("BoxAnimation", RpcTarget.All);
    }

    //public void WhatItem()
    //{
    //    photonView.RPC("WhatItemIntheBox", RpcTarget.All);

    //}
    //박스 애니메이션 

    //RPC All 로 모든 peer에게 작업지시로 내 플레이어의 작업(애니메이션)을 시키면 될것 같은데요.
    [PunRPC]
    public void BoxAnimation()
    {
  

        if (IsOpen == false)
        {
            BoxAnimator.SetBool("BoxOpen", true);
            if (isFirstOpen) //처음으로 여는거면
            {
                Debug.Log("처음아이템 박스를 연다");
                WhatItemIntheBox();
                isFirstOpen = false;
                lastSpawnTime = Time.time;
            }
            else //처음으로 여는게 아니면 
            {
                Debug.Log("처음아이템 박스를 여는것이 아님");
                if (Time.time >= lastSpawnTime + SpawnTime) //쿨타임 돌고나서 가능 
                {
                    lastSpawnTime = Time.time;
                    WhatItemIntheBox();
                }
            }

            IsOpen = true;
        }
        else if (IsOpen == true)
        {
            BoxAnimator.SetBool("BoxOpen", false);
            IsOpen = false;
        }
    }

    private void WhatItemIntheBox()
    {
        ////호스트에서만 아이템 직접 생성 가능.
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

       
        Debug.Log("무얼까요무얼까요");
        int ItemNum = Random.Range(0, 6);//랜덤
        if (ItemNum ==0)
        {
            //총알 아이템 생성 Instantiate(생성아이템,아이템위치,기본회전값)

           
            PhotonNetwork.Instantiate(bullet_item_prefab.name, ItemboxTransform.position, Quaternion.identity);
            Debug.Log("총알 아이템 생성");



        }
        else if (ItemNum == 1)
        {
            //덫 아이템 생성
           

            PhotonNetwork.Instantiate(trap_item_prefab.name, ItemboxTransform.position, Quaternion.identity);
            Debug.Log("덫 아이템 생성");
        }

        else if (ItemNum == 2)
        {
            //가시아이템생성
          

            PhotonNetwork.Instantiate(obstacle_item_prefab.name, ItemboxTransform.position, Quaternion.identity);
            //Debug.Log("가시 아이템 생성");
        }
        else if (ItemNum == 3)
        {
            //햄아이템생성
           

            PhotonNetwork.Instantiate(ham_item_prefab.name, ItemboxTransform.position, Quaternion.identity);
            Debug.Log("햄 아이템 생성");
        }
        else if (ItemNum == 4)
        {
            //빵아이템생성
           
            PhotonNetwork.Instantiate(bread_item_prefab.name, ItemboxTransform.position, Quaternion.identity);
            Debug.Log("빵 아이템 생성");
        }
        else if (ItemNum == 5)
        {
            //쉴드포션
            PhotonNetwork.Instantiate(shield_item_prefab.name, ItemboxTransform.position, Quaternion.identity);
        }
    }
}