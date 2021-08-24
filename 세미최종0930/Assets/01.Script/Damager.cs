using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : StatusController
{
    public int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        //충돌이 일어나는 동안 물리갱신주기 (기본값 0.02초에 맞춰 지속실행)
        StatusController target = other.GetComponent<StatusController>();
        Vector3 hitPoint = other.ClosestPoint(transform.position);
        //closet.Point:콜라이더의 표면 위 점중 특정위치와 가장 가까운점 반환
        Vector3 hitNormal = transform.position - other.transform.position; //공격대상 위치에서 자신의 위치로 향하는 방향
        if (target != null)
        {
            target.OnDamage(damage, hitPoint, hitNormal); //공격 실행
        }
    }

    public override void OnDamage(int damage, Vector3 hitPoint, Vector3 hitNormal)
    {

        base.OnDamage(damage, hitPoint, hitNormal);
        
    }

    // 사망 처리
    public override void Die()
    {
        // LivingEntity의 Die()를 실행하여 기본 사망 처리 실행
        base.Die();
        gameObject.SetActive(false);

    }
}
