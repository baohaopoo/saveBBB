using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class MainCameraController : MonoBehaviour
{
    public float rotateSpeed = 1;//화면이 움직이는 속도

    private Transform camTransform;
    private float yPosition = 0.0f;
    private float pitch = 0.0f;

    private SmoothFollow smoothfollow;

    // Start is called before the first frame update
    void Start()
    {
        smoothfollow = GetComponent<SmoothFollow>();
        camTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (smoothfollow.iswall)
        {
            return;
        }
        float y = Input.GetAxis("Mouse Y");

        yPosition = camTransform.position.y;
        pitch += 0.001f * y;
        if (!(-0.1f < pitch && pitch < 0.15f))
        {
            pitch -= 0.001f * y;
        }
        camTransform.localPosition += Vector3.up * pitch;

    }
}
