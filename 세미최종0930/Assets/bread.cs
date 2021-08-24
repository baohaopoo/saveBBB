using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class bread : StatusController
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void showinfo()
    {

        Debug.Log("플레이어의 현재 체력을 알려줘");
        Debug.Log(HP);
        UIManager.instance.UpdateHPSlider(HP + 40);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
