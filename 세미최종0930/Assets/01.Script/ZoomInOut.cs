using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{

    public Transform Target;
    public float Zoom;
    private Transform tr;


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 TargetDist = tr.position - Target.position;
        TargetDist = Vector3.Normalize(TargetDist);

        tr.position -= (TargetDist * Input.GetAxis("Mouse ScrollWheel") * Zoom);
    }
}
