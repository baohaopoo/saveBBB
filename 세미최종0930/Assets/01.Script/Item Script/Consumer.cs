using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템 먹으면, 고기..햄 관련 스크립트
public class Consumer : MonoBehaviour
{

    GameObject[] portions;
    int currentIndex;
    float lastChange;
    public float interval = 0.5f;

    void Start()
    {
        bool skipFirst = transform.childCount > 4;
        portions = new GameObject[skipFirst ? transform.childCount-1 : transform.childCount];
        for (int i = 0; i < portions.Length; i++)
        {
            portions[i] = transform.GetChild(skipFirst ? i + 1 : i).gameObject;
            if (portions[i].activeInHierarchy)
                currentIndex = i;
        }
    }

    void Update()
    {
        if (Time.time - lastChange > interval)
        {
            Consume();
            lastChange = Time.time;
        }
    }

    void Consume()
    {
        if (currentIndex != portions.Length)
            portions[currentIndex].SetActive(false);
        currentIndex++;
        if (currentIndex > portions.Length)
        {
            currentIndex = 0;
            //Destroy(gameObject);
            gameObject.SetActive(false);

        }
            
        
        else if (currentIndex == portions.Length)
            return;
        portions[currentIndex].SetActive(true);
    }

}
