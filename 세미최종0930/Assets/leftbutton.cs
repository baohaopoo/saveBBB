using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftbutton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ch1;
    public GameObject ch2;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void left()
    {

        ch1.SetActive(false);
        ch2.SetActive(true);
        Debug.Log("left 관련 버튼 눌렸다");

    }

    public void right()
    {

        ch2.SetActive(false);
        ch1.SetActive(true);
    
    
    }
}
