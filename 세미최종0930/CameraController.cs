using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public float offsetX = -400f;
    public float offsetY = 400f;
    public float offsetZ = 0f;
    Vector3 cameraPosition;

    //zoom 관련
    public float zoomSpeed = 10f;

    //회전 관련
    public float rotateSpeed = 10f;

    private Camera mainCamera;



    // Start is called before the first frame update
    void Start()
    {

        mainCamera = GetComponent<Camera>();






    }

    // Update is called once per frame
    void Update()
    {
        ZoomInOut();
        Rotate();
    }
    private void LateUpdate()
    {

        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = cameraPosition;

        ZoomInOut();
    }
    private void ZoomInOut()
    {

        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }
    void Rotate()
    {

        if (Input.GetMouseButton(1))
        {

            Vector3 rot = transform.rotation.eulerAngles;
            rot.y += Input.GetAxis("Mouse X") * rotateSpeed;
            rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed;
            Quaternion q = Quaternion.Euler(rot);
            q.z = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);


        }



    }
}
