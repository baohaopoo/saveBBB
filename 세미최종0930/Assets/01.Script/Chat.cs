using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class Chat : MonoBehaviourPunCallbacks
{

    PhotonView PV = null;
    public InputField ChatInput;
    public Text[] ChatText;

    //채팅관련함수
    public void Send()
    {

        string msg = PhotonNetwork.NickName + ":" + ChatInput.text;
        PV.RPC("ChatRPC", RpcTarget.All, PhotonNetwork.NickName + ":" + ChatInput.text);
        ChatInput.text = "";

    }



    [PunRPC] // RPC는 플레이어가 속해있는 방 모든 인원에게 전달한다
    void ChatRPC(string msg)
    {
        bool isInput = false;
        for (int i = 0; i < ChatText.Length; i++)
            if (ChatText[i].text == "")
            {
                isInput = true;
                ChatText[i].text = msg;
                break;
            }
        if (!isInput) // 꽉차면 한칸씩 위로 올림
        {
            for (int i = 1; i < ChatText.Length; i++) ChatText[i - 1].text = ChatText[i].text;
            ChatText[ChatText.Length - 1].text = msg;
        }
    }

}
