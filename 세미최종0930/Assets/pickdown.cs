using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickdown : MonoBehaviour
{

   // public GameObject playerpick;
  

    //켜져있는 오브젝트를 pick해버리는것. 
    

    //아예 전체 화면을 꺼버리는것.
    public void brownbearpickoff()
    {
       
        //SceneManager.LoadScene("StartScene");
        GameManager.chnum = 1;
        
    }

    public void checkbearbearpickoff()
    {
        //playerpick.gameObject.SetActive(false);
       
        //SceneManager.LoadScene("StartScene");
        GameManager.chnum = 2;
    }

    public void lovebearoff()
    {

        GameManager.chnum = 3;
    }

}
