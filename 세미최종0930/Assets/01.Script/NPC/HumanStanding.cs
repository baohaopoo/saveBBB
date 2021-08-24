using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStanding : MonoBehaviour
{
    private Animator humanAnimator;
    private float behaviorTime; //일정시간이 지나면 새로운 행동하기
    private float lastBehaviorTime; //마지막 행동 시점
    private VikingCrewDevelopment.Demos.SayRandomThingsBehaviour SaySomething;
    void Start()
    {
        behaviorTime = 10f;
        humanAnimator = GetComponent<Animator>();
        SaySomething = GetComponent<VikingCrewDevelopment.Demos.SayRandomThingsBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastBehaviorTime + behaviorTime)
        {
            lastBehaviorTime = Time.time;
            randomBehavor();
            behaviorTime = Random.Range(8, 15);
        }
    }

    private void randomBehavor()
    {
        int b = Random.Range(0, 2);
        if (b == 0)
        {
            //전화한다
            humanAnimator.SetBool("Thinking", false);
            humanAnimator.SetBool("OnPhone", true);
            SaySomething.doTalkOnYourOwn = true; //말한다

        }
        else
        {
            humanAnimator.SetBool("OnPhone", false);
            humanAnimator.SetBool("Thinking", true);
            SaySomething.doTalkOnYourOwn = false;
        }

    }
}
