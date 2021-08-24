using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextplayer : MonoBehaviour
{
    //PPs= brouwn, PCs = green, PBs = pick
    public GameObject brown;
    public GameObject green;
    public GameObject pink;
    public void next()
    {
     
        brown.SetActive(false);
        green.SetActive(true);
     
     
        Debug.Log("체크베어 씬으로 가자");
    
    }

    public void prev()
    {
        green.SetActive(false);
        brown.SetActive(true);

        //SceneManager.LoadScene("PlayerPick", LoadSceneMode.Additive);
        Debug.Log("brownbear씬으로 가자");

    }

    public void lovebear()
    {
        green.SetActive(false);
        pink.SetActive(true);
  
        //SceneManager.LoadScene("pinkbearpick", LoadSceneMode.Additive);
        Debug.Log("핑크페버씬으로 가자");

    }

    public void prevlove()
    {
        pink.SetActive(false);
        green.SetActive(true);
        //GameObject.Find("SSs").SetActive(false);
   
        //SceneManager.LoadScene("checkbearpick", LoadSceneMode.Additive);
        Debug.Log("체크베어 씬으로 가자");

    }
}
