using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int bulletRemain = 5;

    public void UpdateUI()
    {
        if (UIManager.instance != null)
        {
            UIManager.instance.updateBullet(bulletRemain);
        }
    }
}
