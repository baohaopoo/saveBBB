using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator Fade;


    private void Start()
    {
        Fade = GetComponent<Animator>();
     
        fadeIn();
    }

    public void fadeIn()
    {
        
        Fade.SetTrigger("In");
    }
    public void fadeOut()
    {
    
         
        Fade.SetTrigger("Out");
    }
}
