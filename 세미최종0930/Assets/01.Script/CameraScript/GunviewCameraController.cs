using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunviewCameraController : MonoBehaviour
{
    public float rotateSpeed = 1;//화면이 움직이는 속도
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public GameObject player;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        yaw += rotateSpeed * Input.GetAxis("Mouse X");
        pitch += rotateSpeed * Input.GetAxis("Mouse Y");

        // Mathf.Clamp(x, 최소값, 최댓값) - x값을 최소,최대값 사이에서만 변하게 해줌
        pitch = Mathf.Clamp(pitch, -30f, 20f);
        gameObject.transform.localEulerAngles = new Vector3(-pitch, 0, 0.0f);
        player.transform.localEulerAngles = new Vector3(0, yaw, 0.0f);

    }
}
