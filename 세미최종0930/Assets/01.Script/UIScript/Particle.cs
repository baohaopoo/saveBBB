﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
   
//    public bool OnlyDeactivate;

//    void OnEnable()
//    {
//        StartCoroutine("CheckIfAlive");
//    }

//    IEnumerator CheckIfAlive()
//    {
//        ParticleSystem ps = this.GetComponent<Particle>();

//        while (true && ps != null)
//        {
//            yield return new WaitForSeconds(0.5f);
//            if (!ps.IsAlive(true))
//            {
//                if (OnlyDeactivate)
//                {
//#if UNITY_3_5
//						this.gameObject.SetActiveRecursively(false);
//#else
//                    this.gameObject.SetActive(false);
//#endif
//                }
//                else
//                    GameObject.Destroy(this.gameObject);
//                break;
//            }
//        }
//    }



}
