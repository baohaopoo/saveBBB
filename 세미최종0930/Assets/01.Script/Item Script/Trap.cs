using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Trap : MonoBehaviourPun
{
    private GameObject player;
    private bool tied = false;
    private Animator TrapAnimator;
    private Animator playerAnimator;
    private frog_controller frog;
    private HumanEnemy cat;

    private void Start()
    {
        TrapAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            player.transform.position = this.gameObject.transform.position;
            playerAnimator = player.GetComponent<Animator>();
            TrapAnimator.SetBool("trap_bite", true);
            if (!player.GetComponent<Health>().onShield && !player.GetComponent<StatusController>().dead)
            {
                //플레이어 쉴드상태 아니고, 죽지 않았다면 덫에 걸림 
                StartCoroutine(playerOnTrap());
            }


        }

        else if (other.tag == "frog")
        {
            other.gameObject.transform.position = this.gameObject.transform.position;
            frog = other.gameObject.GetComponent<frog_controller>();
            StartCoroutine(frogOnTrap());
        }
        else if (other.tag == "cat")
        {
            other.gameObject.transform.position = this.gameObject.transform.position;
            cat = other.gameObject.GetComponent<HumanEnemy>();
            StartCoroutine(catOnTrap());
        }
    }
    private IEnumerator catOnTrap()
    {

        TrapAnimator.SetBool("trap_bite", true);
        cat.target = null;
        cat.Ontrap = true;
        yield return new WaitForSeconds(3f);//3초동안 기다린다 
        TrapAnimator.SetBool("trap_bite", false);
        frog.Ontrap = false;
    }
    private IEnumerator frogOnTrap()
    {

        TrapAnimator.SetBool("trap_bite", true);
        frog.target = null;
        frog.Ontrap = true;
        yield return new WaitForSeconds(3f);//3초동안 기다린다 
        TrapAnimator.SetBool("trap_bite", false);
        frog.Ontrap = false;
    }

    private IEnumerator playerOnTrap()
    {

        player.GetComponent<PlayerInput>().blockKey = true;
        playerAnimator.SetBool("OnTrap", true);
        yield return new WaitForSeconds(3f);//3초동안 기다린다 
        TrapAnimator.SetBool("trap_bite", false);
        playerAnimator.SetBool("OnTrap", false);
        player.GetComponent<PlayerInput>().blockKey = false;
    }

}
