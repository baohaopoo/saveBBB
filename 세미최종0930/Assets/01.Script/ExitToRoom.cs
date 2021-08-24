
using UnityEngine;

public class ExitToRoom : MonoBehaviour
{
    private Animator windowAnimator;

    private bool windowOpen;
    void Start()
    {
        windowOpen = false;
        windowAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            windowOpen = true;

            windowAnimator.SetTrigger("Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (windowOpen)
        {
            windowOpen = false;
            windowAnimator.SetTrigger("Close");
           
        }
    }

}
