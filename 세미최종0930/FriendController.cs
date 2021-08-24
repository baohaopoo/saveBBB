using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;
    public float jumpPower = 100f;

    private Rigidbody friendRigidbody; // 친구 캐릭터의 리지드바디
    private Animator friendAnimator; // 친구 캐릭터의 애니메이터
    // Start is called before the first frame update
    void Start()
    {
        friendRigidbody = GetComponent<Rigidbody>();
        friendAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
 
   

        
    }




}
