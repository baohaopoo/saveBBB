using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendcontroller : MonoBehaviour
{
    private Rigidbody FriendRigidbody; //친구 캐릭터의 리지드 바디
    private Animator FriendAnimator; //친구 캐릭터의 애니메이터 -> idle


    bool Idle = false;


    // Start is called before the first frame update
    void Start()
    {
       
        FriendRigidbody = GetComponent<Rigidbody>();
        FriendAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void AnimationUpdate()
    {
        FriendAnimator.SetBool("Idle", true);
        Debug.Log("idle 모션 나왔음");
    
    }
}
