using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections;
using UnityStandardAssets.Utility;

public class Health : StatusController, IPunObservable
{
    private AudioSource playerAudio; // 플레이어 소리 재생기
    public AudioClip damageClip;
    private Animator playerAnimator; // 플레이어의 애니메이터
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디

    private PlayerController playercontroller; // 플레이어 움직임 컴포넌트
    public ActionControler actionController; //플레이어의 친구 수 받아오려고 

    int x = 100;
    public Magazine magazine;
    private StatusController status;

    private FriendManager friendManager;

    public bool onShield = false;

    // 싱글톤 접근용 프로퍼티

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {

            stream.SendNext(HP);

        }
        else
        {


            HP = (int)stream.ReceiveNext();
        
        }
    
    }
    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        status = GetComponent<StatusController>();
        playercontroller = GetComponent<PlayerController>();
        friendManager = GameObject.Find("FriendManager").GetComponent<FriendManager>();
    }

    private void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        if (dead && Input.GetMouseButtonDown(0))
        {
            Respawn();
        }

    }
    public void OnEnable()
    {
        // StatusController의 OnEnable() 실행 (상태 초기화)
    
        base.OnEnable();
 
    }

    // 체력 회복

    [PunRPC]
    public override void RestoreHP(int newHP)
    {
        base.RestoreHP(newHP);

        if (photonView.IsMine)
        {
           
            //체력 갱신 
            UpdateUI();

        }


    }

    public void RegenHP()
    {
        HP = 100;
        UpdateUI();


    }

    // 데미지 처리
    [PunRPC]
    public override void OnDamage(int damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        if (onShield)
        {
            Debug.Log("쉴드다!");
            return;
        }
        base.OnDamage(damage, hitPoint, hitDirection);

        playerAudio.PlayOneShot(damageClip);
        //죽지않았고 , 닿으면 뒤로
        if (!dead)
        {
            playerAnimator.SetTrigger("Damaged");
            StartCoroutine(DamageCorutain());
            playerRigidbody.velocity = Vector3.zero; //속도 0으로하고
            //playerRigidbody.AddForce(Vector3.right * -10, ForceMode.Impulse);//뒤로
        }

        if (photonView.IsMine)
        {

            //갱신된 체력 슬라이더에 반영
            UpdateUI();

        }


       
    }

    //ui갱신 
    public void UpdateUI()
    {
         if (playerRigidbody != null && UIManager.instance != null)
        {
            UIManager.instance.UpdateHPSlider(HP);
        }
    }

    private IEnumerator DamageCorutain()
    {

        if (!photonView.IsMine)
        {
            yield break;

        }
        DamagedUI(true);
        yield return new WaitForSeconds(0.3f);
        DamagedUI(false);
    }

    private void DamagedUI(bool active)
    {
        if (playerRigidbody != null && UIManager.instance != null)
        {
            UIManager.instance.SetActiveDamagerUI(active);
        }
    }

    // 사망 처리
    public override void Die()
    {

        base.Die();

        actionController.minusFriend(); //친구 빼라
        //총 내려놓게함
        playercontroller.NotUseGun();
        photonView.RPC("dieAni", RpcTarget.All);
        if (photonView.IsMine)
        {
            UpdategameoverUI(true);
        }
    }
    [PunRPC]
    public void dieAni()
    {
        //사망애니메이션
        playerAnimator.SetTrigger("Die");
    }
    private void UpdategameoverUI(bool active)
    {
        if (playerRigidbody != null && UIManager.instance != null)
        {
            UIManager.instance.offallUI(); //아예 모든 UI를 꺼주세요.
            UIManager.instance.SetActiveGameoverUI(active);
        }
    }

    //부활 처리

    public void Respawn()
    {


        //로컬 플레이어만 직접 위치 변경 가능
        if (photonView.IsMine)
        {
            photonView.RPC("repawnAni", RpcTarget.All);
            UpdategameoverUI(false);
            UIManager.instance.onallUI(); //모든 UI 켜기




            Vector3 randomPos;

            randomPos.x = 88.2153f;
            randomPos.y =5f;
            randomPos.z = 453.567f;
            gameObject.transform.position = randomPos;

            magazine.bulletRemain = 5;
            magazine.UpdateUI();




        }

    }

    [PunRPC]
    public void repawnAni()
    {
        status.dead = false;
        playerAnimator.SetTrigger("Respawn"); //다시 일어낫!
        status.RestoreHP(1000); //체력 100 충전 
        


    }




}
