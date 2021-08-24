using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class playerEffect : MonoBehaviourPun
{
    Vector3 addPos;
    [SerializeField]
    private GameObject pushEffect;
    public ParticleSystem push;
   
    void Start()
    {
        
    }
    //private void OnParticleCollision(GameObject other)
    //{
    //    if (other.transform.tag == "Player")
    //    {
    //        Debug.Log("플레이어가 밀어서 파티클 써짐");
    //    }
    //}
    private void OnCollisionEnter(Collision other)
    {
        //만약 pushObject들이 player와 닿는다면
        if (other.transform.tag == "pushObject")
        {
            Instantiate(pushEffect);
           // StartCoroutine(goEffect());
            //UIManager.instance.OnpushUI();
        }

    }


    private IEnumerator goEffect()
    {
        push.Play();

        yield return new WaitForSeconds(0.03f);
        
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
