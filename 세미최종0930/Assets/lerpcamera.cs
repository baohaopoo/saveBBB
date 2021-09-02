using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class lerpcamera : MonoBehaviour
{
    private Transform camera;
    public GameObject target;
    public float CameraZ = -0.0003f;


    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, CameraZ);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 0.2f);
    }
}
