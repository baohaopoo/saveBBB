using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class letteron : MonoBehaviourPunCallbacks
{
    public GameObject chat;
    public GameObject chatinput;
    bool ison = false;
    int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onletter()
    {
        //if (!photonView.IsMine)
        //    return; 


        ison = true;
        if (ison)
        {
            chat.gameObject.SetActive(true);
            chatinput.gameObject.SetActive(true);
            cnt += 1;
            Debug.Log("씨엔티출현");
            Debug.Log(cnt);


            if (cnt == 2)
            {
                chat.gameObject.SetActive(false);
                chatinput.gameObject.SetActive(false);
                cnt = 0;
                ison = false;
            }
        }

    }


}
