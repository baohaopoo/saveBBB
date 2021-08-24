using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviourPun
{
    public string VerticalAxisName = "Vertical";
    public string HorizontalAxisName = "Horizontal";
    public string jumpButtonName = "Jump"; 
    public string RightMouseButtonName = "UseGun"; //총사용할때 누르는 버튼
    public string fireButtonName = "Fire1"; //총 발사를 위한 버튼

    // 값 할당은 내부에서만 가능
    public float Verticalmove { get; private set; }
    public float Horizontalmove { get; private set; }
    public bool jump { get; private set; }
    public bool rightmouse { get; private set; }
    public bool fire { get; private set; }
    public bool backMirror { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }

    private StatusController status;

    private void Start()
    {
        status = GetComponent<StatusController>();
    }

    public bool blockKey = false;

    // 매프레임 사용자 입력을 감지
    private void Update()
    {
        if (photonView.IsMine)
        {

            //게임오버 상태에서는 사용자 입력 감지 안함
            if (blockKey || status.dead)
            {
                Verticalmove = 0;
                Horizontalmove = 0;
                rightmouse = false;
                jump = false;
                fire = false;
                backMirror = false;
                mouseX = 0;
                mouseY = 0;
                return;
            }

            //  입력 감지
            Verticalmove = Input.GetAxis(VerticalAxisName);
            Horizontalmove = Input.GetAxis(HorizontalAxisName);
            jump = Input.GetButtonDown(jumpButtonName);
            fire = Input.GetButtonDown(fireButtonName);

            //카메라 입력감지 
            backMirror = Input.GetKey(KeyCode.F);
            rightmouse = Input.GetButtonDown(RightMouseButtonName);

            //마우스 입력감지
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

        }
    }
}