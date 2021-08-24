using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Window_Action : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //플레이어 객체 소환

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {

            Debug.Log("플레이어 윈도우 충돌");
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("플레이어 충돌");
    //    SceneChange();

    //}

    void SceneChange()
    {
        SceneManager.LoadScene("Garden");
    
    }
}
