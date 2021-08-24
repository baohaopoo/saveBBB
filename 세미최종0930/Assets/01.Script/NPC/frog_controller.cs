using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class frog_controller : StatusController
{
    public LayerMask PlayerTarget;//추적대상 레이어
    public StatusController target;// 추적대상 

    public int damage = 10;// 공격력
    public float timeBetAttack = 0.5f; //공격간격
    private float lastAttackTime; //마지막 공격 시점
    public float traceRange = 5f; //추적 범위 
    private Animator frogAnimator;
    public float speed = 10;

    Transform targetTrans;
    private bool goFrog = false;

    private bool isSwimming = false;

    public float traceTime = 15f; //일정시간 지나면 추적 안함 
    private float lastTraceTime = 0; //마지막 추적 시점 
    public bool Ontrap = false;

    private AudioSource frogAudio;

    // 추적할 대상이 존재하는지 알려주는 프로퍼티
    private bool hasTarget
    {
        get
        {
            // 추적할 대상이 존재하고, 대상이 사망하지 않았다면 true
            if (target != null && !target.dead)
            {
                return true;
            }

            // 그렇지 않다면 false
            return false;
        }
    }
    [PunRPC]
    public void Setup(int newHealth, int newDamage)
    {
        // 체력 설정
        startHP = newHealth;
        HP = newHealth;
        // 공격력 설정
        damage = newDamage;
    }
    // Start is called before the first frame update
    void Start()
    {
        frogAnimator = GetComponent<Animator>();
        frogAudio = GetComponent<AudioSource>();

        // 호스트가 아니라면 AI의 추적 루틴을 실행하지 않음
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        // 게임 오브젝트 활성화와 동시에 AI의 추적 루틴 시작
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
        // 호스트가 아니라면 애니메이션의 파라미터를 직접 갱신하지 않음
        // 호스트가 파라미터를 갱신하면 클라이언트들에게 자동으로 전달되기 때문.
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        if (!isSwimming && !dead)
        {
            frogAnimator.SetBool("isJump", hasTarget); //타겟 있으면 뛴다
            frogAudio.Play();
        }



        if (hasTarget && goFrog)
        {
            frogMove();
        }
    }

    private void frogMove()
    {
        transform.LookAt(targetTrans);
        transform.position = Vector3.Lerp(transform.position, targetTrans.position, 0.1f * speed * Time.deltaTime);
    }
    // 주기적으로 추적할 대상의 위치를 찾아 경로를 갱신
    private IEnumerator UpdatePath()
    {
        // 살아있는 동안 무한 루프
        while (!dead)
        {

            if (hasTarget)
            {

                goFrog = true;
                var distance = target.transform.position - this.transform.position; //거리
                                                                                    //목표 갱신
                targetTrans = target.transform;

                if (distance.sqrMagnitude < 1f)
                {
                    goFrog = false;
                }


                if (Time.time > lastTraceTime + traceTime)
                {
                    //일정한 추적시간이 지나면 추적 중지.
                    lastTraceTime = Time.time;
                    target = null;
                    goFrog = false;
                }
            }

            else
            {
                if (!Ontrap)
                {
                    // 20 유닛의 반지름을 가진 가상의 구를 그렸을때, 구와 겹치는 모든 콜라이더를 가져옴
                    // 단, targetLayers에 해당하는 레이어를 가진 콜라이더만 가져오도록 필터링
                    Collider[] colliders =
                        Physics.OverlapSphere(transform.position, traceRange, PlayerTarget);

                    // 모든 콜라이더들을 순회하면서, 살아있는 플레이어를 찾기
                    for (int i = 0; i < colliders.Length; i++)
                    {
                        // 콜라이더로부터 statuscontroller 컴포넌트 가져오기
                        StatusController statuscontroller = colliders[i].GetComponent<StatusController>();

                        // statuscontroller 컴포넌트가 존재하며, 해당 statuscontroller 살아있다면,
                        if (statuscontroller != null && !statuscontroller.dead)
                        {
                            // 추적 대상을 해당 statuscontroller로 설정
                            target = statuscontroller;

                            // for문 루프 즉시 정지
                            break;
                        }
                    }
                }

            }

            yield return new WaitForSeconds(0.25f);
        }
    }

    // 데미지를 입었을때 실행할 처리
    [PunRPC]
    public override void OnDamage(int damage, Vector3 hitPoint, Vector3 hitNormal)
    {

        // statuscontroller OnDamage()를 실행하여 데미지 적용
        base.OnDamage(damage, hitPoint, hitNormal);
        if (!dead)
        {
            goFrog = false;
            target = null;
            frogAnimator.SetTrigger("isDamaged");
        }

    }

    // 사망 처리
    public override void Die()
    {
        // statuscontroller의 Die()를 실행하여 기본 사망 처리 실행
        base.Die();
        ;
        // 다른 AI들을 방해하지 않도록 자신의 모든 콜라이더들을 비활성화
        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        frogAudio.Stop();
        goFrog = false;
        target = null;
        frogAnimator.SetTrigger("isDie");
        Destroy(gameObject, 20f);//20초뒤 제거 

    }

    private void OnTriggerStay(Collider other)
    {
        //호스트가 아니라면 공격 실행 불가
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        if (other.tag == "water")
        {
            isSwimming = true;
            frogAnimator.SetBool("isJump", false);
            frogAnimator.SetBool("isSwim", true);
        }

        // 자신이 사망하지 않았으며,
        // 최근 공격 시점에서 timeBetAttack 이상 시간이 지났다면 공격 가능
        if (!dead && Time.time >= lastAttackTime + timeBetAttack)
        {
            // 상대방으로부터 StatusController 타입을 가져오기 시도
            StatusController attackTarget
                = other.GetComponent<StatusController>();

            // 상대방의 Statuscontroller 자신의 추적 대상이라면 공격 실행
            if (attackTarget != null && attackTarget == target)
            {
                // 최근 공격 시간을 갱신
                lastAttackTime = Time.time;

                // 상대방의 피격 위치와 피격 방향을 근삿값으로 계산
                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitNormal = transform.position - other.transform.position;

                // 공격 실행
                attackTarget.OnDamage(damage, hitPoint, hitNormal);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "water")
        {
            frogAudio.Stop();
            isSwimming = false;
            frogAnimator.SetBool("isSwim", false);
            frogAnimator.SetBool("isJump", true);
        }
    }
}
