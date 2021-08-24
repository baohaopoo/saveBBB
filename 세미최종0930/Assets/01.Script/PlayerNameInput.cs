using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class PlayerNameInput : MonoBehaviour
{

    const string PlayerNamePrefKey = "baohao";

    // Start is called before the first frame update
    void Start()
    {
        string defaultName = string.Empty;
        InputField inputfield = this.GetComponent<InputField>();
        

        if (inputfield != null)
        {
            if (PlayerPrefs.HasKey(PlayerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(PlayerNamePrefKey);
                inputfield.text = defaultName;
            
            }
        
        }

        PhotonNetwork.NickName = defaultName;
        Debug.Log(PhotonNetwork.NickName);
    }

    public void setPlayerName(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("이상하다Player Name is null or empty");
            return;
        }
        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(PlayerNamePrefKey,value);
        Debug.Log("너의 이름은 정해졌어");
        Debug.Log(PhotonNetwork.NickName);
    }
}
