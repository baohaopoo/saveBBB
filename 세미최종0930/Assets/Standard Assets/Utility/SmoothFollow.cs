using UnityEngine;
using Photon.Pun;

#pragma warning disable 649
namespace UnityStandardAssets.Utility
{
    public class SmoothFollow : MonoBehaviourPun
    {


        // The target we are following
        //[SerializeField]
        public Transform target;
        // The distance in the x-z plane to the target
        [SerializeField]
        private float width = 10.0f;
        // the height we want the camera to be above the target
        [SerializeField]
        private float height = 5.0f;

        [SerializeField]
        private float rotationDamping;
        [SerializeField]
        private float heightDamping;

        private float distance = 0f; //플레이어와 카메라 사이의 거리

        Vector3 dir;


        public bool iswall = false;

        private void Start()
        {
            distance = Mathf.Sqrt(width * width + height * height);

            //플레이어와 카메라까지의 방향벡터
            dir = new Vector3(0, height, -width).normalized;
        }

        void FixedUpdate()
        {


            // Early out if we don't have a target

            if (!target)
                return;

            Vector3 ray = target.up * height + target.forward * (width * -1);
            RaycastHit hitinfo;
            Physics.Raycast(target.position, ray, out hitinfo, distance);

            if (hitinfo.point != Vector3.zero && hitinfo.collider.gameObject.tag == "wall")
            {
                //레이캐스트 성공시

                transform.position = Vector3.Lerp(transform.position, hitinfo.point, Time.deltaTime);
                //transform.position = hitinfo.point;
                iswall = true;

            }
            else
            {
                iswall = false;
                // Calculate the current rotation angles
                var wantedRotationAngle = target.eulerAngles.y;
                var wantedHeight = target.position.y + height;

                var currentRotationAngle = transform.eulerAngles.y;
                var currentHeight = transform.position.y;

                // Damp the rotation around the y-axis
                currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

                // Damp the height
                currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

                // Convert the angle into a rotation
                var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

                // Set the position of the camera on the x-z plane to:
                // distance meters behind the target
                transform.position = target.position;
                transform.position -= currentRotation * Vector3.forward * width;

                // Set the height of the camera
                transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
            }


            // Always look at the target
            transform.LookAt(target);
        }
    }
}