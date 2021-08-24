using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
public class chatmanager : MonoBehaviourPun
{
    public PhotonView PV;
    public TextMeshProUGUI ChatText;
    public InputField ChatInput;
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
