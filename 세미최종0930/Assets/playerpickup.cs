using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerpickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerpick;
    public GameObject playerPickScene;
    int cnt = 0;

    public void Awake()
    {
     
    }
    public void pick()
    {
        //playerpick.gameObject.SetActive(true);

        cnt += 1;

        // PlayerPrefs.SetString("Name",)
        GameObject.Find("SSs").SetActive(false);
        playerPickScene.SetActive(true);
        
        if (cnt == 2)
        {
            //playerpick.gameObject.SetActive(false);
            cnt = 0;
          
        }
    }

    public void pickoff()
    {
        playerpick.gameObject.SetActive(false);
  
    }
}

