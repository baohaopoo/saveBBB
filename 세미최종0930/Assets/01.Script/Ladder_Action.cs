using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Action : MonoBehaviour
{

    private bool isLadder;
    private bool isAir;
    public float speed = 3f;


    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        isLadder = false;
        isAir = false;
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (isLadder)
        {
           
            bool upKey = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            bool downKey = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

            if (upKey)
            {
                this.transform.Translate(0, speed * Time.deltaTime, 0);
            }
            else if (downKey)
            {
                this.transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        }
        else if (isAir)
        {
            bool upKey = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            bool downKey = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
            if (upKey)
            {
                this.transform.Translate(0, 0, speed * Time.deltaTime);
            }
            else if (downKey)
            {
                this.transform.Translate(0, 0, -speed * Time.deltaTime);
            }
        }

        else
        {
            // 일반 이동의 경우 소스 (생략)


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ladder_bottom")
        {
            if (!isLadder)
            {
                Debug.Log("사다리 밑바닥");
                isLadder = true;
                this.transform.Translate(0, 0.5f, 0);
            }
        }
        else if (collision.transform.tag == "Ladder_Air")
        {
            if (isLadder)
            {
                Debug.Log("사다리 공기");
                isLadder = false;
                isAir = true;
            }
        }
        else if (collision.transform.tag == "Ladder_Top")
        {
            if (!isLadder)
            {
                Debug.Log("사다리 위");
                isLadder = true;

                this.transform.Translate(0, -0.5f, 0);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ladder_Air")
        {
            isAir = false;
        }

    }
    
}
    
