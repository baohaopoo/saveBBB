using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gethp : MonoBehaviour
{

    public GameObject playerTarget;
    private Health h_instance;


    // Start is called before the first frame update
    void Start()
    {

        h_instance.OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
