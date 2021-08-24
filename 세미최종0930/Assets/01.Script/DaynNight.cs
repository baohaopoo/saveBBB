using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaynNight : MonoBehaviour
{

    [SerializeField]
    private float gameTime;

    private bool isNight = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * gameTime * Time.deltaTime);
    }
}
