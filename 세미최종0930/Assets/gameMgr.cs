using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class gameMgr : MonoBehaviourPun
{
        public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPos = Random.insideUnitSphere * 5f;
        randomPos.y = 0f;

        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
