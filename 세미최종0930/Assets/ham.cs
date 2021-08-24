using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ham : StatusController
{
    public GameObject player;

    void Start()
    {

     
    }


    public void showinfo()
    {

        Debug.Log("플레이어의 현재 체력을 알려줘");
        Debug.Log(HP);
        UIManager.instance.UpdateHPSlider(HP + 80);

    }
    void Update()
    {
        
    }
}
