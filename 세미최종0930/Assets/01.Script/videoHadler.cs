using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Photon.Pun;
using UnityStandardAssets.Utility;

public class videoHadler : MonoBehaviourPun
{
    private GameObject FollowCam; //main camera

    public RawImage mScreen = null;
    public VideoPlayer mVideoPlayer = null;
    private int cnt = 0;
    private GameObject PlayerPibot;
    private ActionControler actioncontroller;

    private Health player;
    private Magazine magazine;
    private PlayerHaveItem playerhaveItem;

    void Start()
    {
        if (mScreen != null && mVideoPlayer != null)
        {
            // 비디오 준비 코루틴 호출
            StartCoroutine(PrepareVideo());
        }



    }
    protected IEnumerator PrepareVideo()
    {
        // 비디오 준비
        mVideoPlayer.Prepare();

        // 비디오가 준비되는 것을 기다림
        while (!mVideoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer의 출력 texture를 RawImage의 texture로 설정한다

        mScreen.texture = mVideoPlayer.texture;
    }

    void Update()
    {

        if (!mVideoPlayer.isPlaying)
        {
            cnt += 1;

        }
        if (cnt == 10)
        {
            StopMovie();
        }

        if (Input.GetKeyDown("1"))
        {
            StopMovie(); //영상 멈추는 치트키 
        }

    }

    public void StopMovie()
    {
        resetCam(); //cam 피봇 재설정 
        resetUI(); //UI 넘어가면서 재설정 
        UIManager.instance.EndMovie();

    }

    private void resetCam()
    {
        FollowCam = GameObject.Find("MainCamera");
        PlayerPibot = GameObject.Find("playerpivot");
        FollowCam.GetComponent<SmoothFollow>().target = PlayerPibot.transform;
    }


    private void resetUI()
    {
        //친구구한 갯수 
        actioncontroller = GameObject.Find("ItemCollider").GetComponent<ActionControler>();
        actioncontroller.updateScore();
        //HP
        player = GameObject.FindWithTag("Player").GetComponent<Health>();
        player.UpdateUI();
        //총알
        magazine = GameObject.Find("Magazine").GetComponent<Magazine>();
        magazine.UpdateUI();

        //인벤토리
        playerhaveItem = GameObject.Find("InventorySlot").GetComponent<PlayerHaveItem>();
        playerhaveItem.updateItemUI();

    }

}