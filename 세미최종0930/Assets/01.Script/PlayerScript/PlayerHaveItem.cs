using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerHaveItem : MonoBehaviourPun
{
    public Item Iitem1; //획득한 아이템1
    public Item Iitem2; //획득한 아이템2

    //진짜 아이템 정보인것
    public void AcquireItem(Item _item)
    {
        if (Iitem1 == null) //아이템 1이 비어있다면 
        {
            AddItem1(_item); //아이템 1 추가 
        }
        else if (Iitem1 != null)  //아이템 1 비어있지 않으면 
        {
            if (Iitem2 == null)  //아이템2는 비어있으면?
            {
                AddItem2(_item);  //아이템 2 추가 
            }

            else if (Iitem2 != null)  //만약 아이템2도 차있다면? 
            {
                Debug.Log("슬롯이 꽉 찼습니다.");
            }
        }

    }



    [PunRPC]
    private void AddItem1(Item _item1) //아이템1 추가
    {
        Iitem1 = _item1;
        // UIManager.instance.AddItem1(Iitem1);
        updateItemUI();

    }
    [PunRPC]
    private void AddItem2(Item _item2) //아이템2 추가 
    {
        Iitem2 = _item2;
        //UIManager.instance.AddItem2(Iitem2);
        updateItemUI();

    }

    public void updateItemUI()
    {
        if (Iitem1 != null)
        {
            UIManager.instance.AddItem1(Iitem1);
        }
        if (Iitem2 != null)
        {
            UIManager.instance.AddItem2(Iitem2);
        }
    }

    public void UseItem() //아이템 사용하기 
    {
        Iitem1 = null;
        UIManager.instance.UseItem1();
        if (Iitem2 != null)//만약 아이템2가 존재하면
        {
            AddItem1(Iitem2); //아이템2를 아이템1에 추가
            Iitem2 = null; //아이템2는 비워주기


            UIManager.instance.MoveItem2();
        }
    }


}
