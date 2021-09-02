using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startcamera : MonoBehaviour
{

    public GameObject camera;
    public GameObject target;
    public float CameraZ;

    private void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(target.transform.position.x, target.transform.position.y, CameraZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 2f);
        
    }

}
