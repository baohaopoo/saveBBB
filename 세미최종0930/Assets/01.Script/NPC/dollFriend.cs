using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollFriend : MonoBehaviour
{

    [SerializeField] private string dollName;
    [SerializeField] private float walkSpeed;

    private bool isWalking;


    private float walkTime;
    private float waitTime;
    private float currentTime;
    private Animator anim;
    private Rigidbody rigid;
    private BoxCollider boxCol;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = waitTime;

    }


    private void FixedUpdate()
    {
     
    }
    // Update is called once per frame
    void Update()
    {
        ElapsedTime();
        
    }
    private void ElapsedTime()
    { 
     
    
    }

}
