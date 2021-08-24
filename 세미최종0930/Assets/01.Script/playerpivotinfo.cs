using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



public class playerpivotinfo : MonoBehaviourPun, playerpivot
{
    public Vector3 pivotPos { get; protected set; }
    public GameObject player;
    [PunRPC]
    public void showmeyourinfo(Vector3 pos)
    {

        pivotPos = pos;
        //Debug.Log(this.transform.position);
        //playerpivotPos.x = this.transform.position.x;
        //playerpivotPos.y = this.transform.position.y;
        //playerpivotPos.z = this.transform.position.z;



    }
}

