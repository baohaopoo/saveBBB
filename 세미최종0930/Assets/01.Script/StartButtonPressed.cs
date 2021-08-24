using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonPressed : MonoBehaviour
{
    // Start is called before the first frame update

    void PressedStartButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("화면전환");
            SceneManager.LoadScene("Kidsroom");
        }
     
    
    }

    private void Update()
    {
        PressedStartButton();
    }
}
