using UnityEngine;
using Photon.Pun;
// 주어진 Gun 오브젝트를 쏘거나 재장전
public class PlayerShooter : MonoBehaviourPun
{
    public Gun gun; // 사용할 총
    public Magazine magazine; //탄창
    private PlayerInput playerInput;

    public Animator CrossHairAnimator;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {



        //총이 쏴질때.
        photonView.RPC("gunon_RPC", RpcTarget.All);


        if (photonView.IsMine)
        {
            //에임 UI도 활성화
            gun.Aimon();

            if (magazine.bulletRemain <= 0)
            {
                //총알상태를 off
                gun.Stateoff();
            }
            else if (magazine.bulletRemain > 0)
            {
                gun.Stateon();
            }

            // Aim.SetActive(false);


        }

    }
    [PunRPC]
    public void gunon_RPC()
    {

        // 슈터가 활성화될 때 총도 함께 활성화
        gun.gameObject.SetActive(true);

    }

    private void OnDisable()
    {
        photonView.RPC("gunoff_RPC", RpcTarget.All);
        //에임 비활성화

        if (photonView.IsMine) //포톤이 로컬일떄
        {
            gun.Aimoff();

        }
    }
    [PunRPC]
    void gunoff_RPC()
    {

        // 슈터가 비활성화될 때 총도 함께 비활성화
        gun.gameObject.SetActive(false);


    }


    private void Update()
    {

        animations();


    }

    //에임 애니메이션 

    private void animations()
    {
        if (playerInput.Verticalmove >= 1f)
        {
            CrossHairAnimator.SetBool("Walking", true);

            if (playerInput.fire && magazine.bulletRemain != 0)
            {
                CrossHairAnimator.SetTrigger("walk_Fire");
                gun.Fire();
            }
        }
        else
        {
            CrossHairAnimator.SetBool("Walking", false);
            if (playerInput.fire && magazine.bulletRemain != 0)
            {
                CrossHairAnimator.SetTrigger("Idle_Fire");
                gun.Fire();
            }
        }

    }


}