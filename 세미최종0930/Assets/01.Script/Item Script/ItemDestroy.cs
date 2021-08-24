using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ItemDestroy : MonoBehaviourPun
{
    [PunRPC]
    public void destroyMe()
    {
        
        Destroy(this.gameObject);
    }


    public void destroyall()
    {
     
            photonView.RPC("destroyMe", RpcTarget.All);



    
    }
}
