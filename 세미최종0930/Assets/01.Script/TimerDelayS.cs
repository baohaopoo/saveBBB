 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDelayS : MonoBehaviour
{



    Button StartButton;
    bool showbutton;

    // Start is called before the first frame update
    void Start()
    {

        StartButton = GetComponent<Button>();
        StartButton.interactable = false;

        Invoke("showButton", 3);

        
    }

    // Update is called once per frame
    void Update()
    {
        ShowButton(showbutton);

    }

    private void ShowButton(bool button)
    {
        if (!showbutton)
        {
            showbutton = true;
        }

        else if (showbutton)
        {

            StartButton.interactable = true;

        }


    }

    void test()
    {

        Debug.Log("3초");
    }

}
