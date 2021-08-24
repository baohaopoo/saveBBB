using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletUI : MonoBehaviour
{

    static public bulletUI b_instance = null;
    public GameObject bulletImage1;
    public GameObject bulletImage2;
    public GameObject bulletImage3;
    public GameObject bulletImage4;
    public GameObject bulletImage5;

   
    // Start is called before the first frame update
    void Start()
    {


    }
    
     public void BulletUI(int sb)
    {
       
        if (sb == 5)
        { 
            
        }
        else if (sb == 4)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(true);
            bulletImage4.SetActive(true);
            bulletImage5.SetActive(false);
        }
        else if (sb == 3)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(true);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if (sb == 2)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if (sb == 1)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(false);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if( sb == 0)
        {
            bulletImage1.SetActive(false);
            bulletImage2.SetActive(false);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
