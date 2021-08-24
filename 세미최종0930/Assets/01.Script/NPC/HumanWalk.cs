using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWalk : MonoBehaviour
{
    private Animator humanAnimator;
    private float speed = 3f;
    private Quaternion rotation;
    private Rigidbody humanRigidbody;
    private bool isWalking;
    private float behaviorTime; //일정시간이 지나면 새로운 행동하기
    private float lastBehaviorTime; //마지막 행동 시점
    private bool onPhone;
    private VikingCrewDevelopment.Demos.SayRandomThingsBehaviour SaySomething;

    void Start()
    {
        behaviorTime = 20f;
        humanRigidbody = GetComponent<Rigidbody>();
        humanAnimator = GetComponent<Animator>();
        rotation = this.transform.rotation;
        isWalking = true;
        onPhone = false;
        SaySomething = GetComponent<VikingCrewDevelopment.Demos.SayRandomThingsBehaviour>();
    }


    private void Update()
    {
        humanAnimator.SetBool("walk", isWalking);
        humanAnimator.SetBool("OnPhone", onPhone);
        if (Time.time > lastBehaviorTime + behaviorTime)
        {
            lastBehaviorTime = Time.time;
            randomBehavor();
            behaviorTime = Random.Range(8, 21);
        }

        if (isWalking)
        {
            Move();
        }
    }


    private void Move()
    {
        Vector3 moveDistance = transform.forward * speed * Time.deltaTime;
        humanRigidbody.MovePosition(humanRigidbody.position + moveDistance);
    }

    private void randomBehavor()
    {
        int b = Random.Range(0, 2);
        if (b == 0)
        {
            //폰사용
            humanRigidbody.velocity = Vector3.zero; //속도 0으로 두자
            isWalking = false;
            onPhone = true;
            SaySomething.doTalkOnYourOwn = true; //말한다

        }
        else
        {
            onPhone = false;
            isWalking = true;
            SaySomething.doTalkOnYourOwn = false; //말 안한다
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BackOrRight")
        {
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                turn360();
            }
            else if (r == 1)
            {
                turnRight();
            }
        }
        else if (other.tag == "BackOrLeft")
        {
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                turn360();
            }
            else if (r == 1)
            {
                turnLeft();
            }
        }
        else if (other.tag == "Left")
        {
            turnLeft();
        }
        else if (other.tag == "Right")
        {
            turnRight();
        }
        else if (other.tag == "Back")
        {
            turn360();
        }

    }

    private void turn360()
    {
        transform.rotation = rotation * new Quaternion(0, 1, 0, 0);
    }
    private void turnRight()
    {
        transform.Rotate(0, 90, 0);
    }
    private void turnLeft()
    {
        transform.Rotate(0, -90, 0);
    }
}