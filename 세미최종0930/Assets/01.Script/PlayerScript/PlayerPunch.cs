using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerPunch : MonoBehaviourPun
{
    private Animator playerAnimator;
    public GameObject punchCollider;
   // public ParticleSystem hitLauncher;
    Vector3 hitPosition = Vector3.zero;
    private AudioSource playerAudioPlayer;
    public AudioClip hitSound;
    // bool punchseton = false;
    public float timeBetPunch = 0.12f; // 총알 발사 사이의 시간간격
    public float lastPunchTime = 0; // 총을 마지막으로 발사한 시점 
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAudioPlayer = GetComponent<AudioSource>();
        //punchCollider.SetActive(punchseton);
    }
    //private IEnumerator ShotEffect(Vector3 hitPosition)
    //{
    //    //hitLauncher.Play();


    //    // 0.03초 동안 잠시 처리를 대기
    //    yield return new WaitForSeconds(0.03f);

       

    //}

    void Update()
    {
        hitPosition.x = 88;
        hitPosition.y = 5;
        hitPosition.z = 453; 

        // 로컬일때
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0)) //키를 누르면
            {
                if (Time.time >= lastPunchTime + timeBetPunch) {
                    lastPunchTime = Time.time;
                    onpunch();
                }
                
              // StartCoroutine(ShotEffect(hitPosition));
               

            }

            if (Input.GetMouseButtonUp(0))
            {
                offpunching();


            }
        }
            
     }




    private void onpunch()
    {

        photonView.RPC("Punchging", RpcTarget.All);

    }

    private void offpunching()
    {

        photonView.RPC("Punchgingoff", RpcTarget.All);

    }


    [PunRPC]
    public void Punchging()
    {

      
        punchCollider.SetActive(true);
        playerAnimator.SetTrigger("isPunch");
        playerAudioPlayer.PlayOneShot(hitSound);


    }


    [PunRPC]
    public void Punchgingoff()
    {


        punchCollider.SetActive(false);



    }


}
