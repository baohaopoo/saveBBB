using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    public bool inNight = false;
    //private Material originalSky; //원래하늘 
    public Material NightSky; 
    public Material DaySky;
    [HideInInspector]
    public float progressDawn = 0;//새벽
    [HideInInspector]
    public float progressDay = 0;//낮
    [HideInInspector]
    public float progressEvening = 0;//저녁
    [HideInInspector]
    public float progressNight = 0; //밤
    private Color sunSet;
    private Color sunOrigin;
    private Color nightStart;
    private DayandNight daynight;

    public Material window;
    public Color windowlightForday;
    public Color windowlightFornight;
    public Color windowlightOff;

    void Start()
    {
        daynight = GetComponent<DayandNight>();
        //originalSky = RenderSettings.skybox;
        sunSet = new Color(0.8784f, 0.1607f, 0.2352f, 1f);
        sunOrigin = new Color(0.5f, 0.5f, 0.5f, 1f);
        nightStart = new Color(0.7f, 0.7f, 0.7f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
       if (inNight)
        {
            RenderSettings.skybox = NightSky;
            NightSkyColor();
        }
        else if (!inNight)
        {
            RenderSettings.skybox = DaySky;
            DaySkyColor();
        }
       
    }


    private void DaySkyColor()
    {
        //머터리얼 색상은 0~1까지 
        //Debug.Log(DaySky.GetColor("_TintColor"));
        //Debug.Log(daynight.DayTime);
        if (progressDawn < 1)
        {
            //새벽
            // DaySky.SetFloat("_Exposure",1f);

            DaySky.SetColor("_TintColor", Color.Lerp(Color.black, sunOrigin, progressDawn));
            progressDawn += (Time.deltaTime / (daynight.DayTime/6f)); 
            //Debug.Log("새벽이당");
        }
        else if (progressDawn >= 1)
        {
            if (progressDay < 1)
            {
                //낮
                //Debug.Log("낮이당" + Mathf.Lerp(1.0f, 2f, progressDay));
                Windowlighting(1);
                //DaySky.SetFloat("_Exposure", Mathf.Lerp(1.0f, 2f, progressDawn));
                DaySky.SetColor("_TintColor", Color.Lerp(sunOrigin, sunSet, progressDay));
                progressDay += (Time.deltaTime / (daynight.DayTime *(5f/6f)));
                        
            }

        }
        
    }

    private void NightSkyColor()
    {
        if (progressEvening < 1)
        {
            Debug.Log("저녁이당!");
            Windowlighting(2);
            NightSky.SetColor("_TintColor", Color.Lerp(nightStart, sunOrigin, progressEvening));
            progressEvening += (Time.deltaTime / (daynight.DayTime * (4f / 6f)));
        }
        else if (progressEvening >= 1)
        {
            if (progressNight < 1)
            {
                Windowlighting(3);
                //Debug.Log("밤에서 칠흙으로 가는길");
                NightSky.SetColor("_TintColor", Color.Lerp(sunOrigin, Color.black, progressNight));
                progressNight += (Time.deltaTime / (daynight.DayTime / (2f / 6f)));
            }

        }
    }

    private void Windowlighting(int n)
    {
        if (n==1)
        {
            window.color = windowlightForday;
        }
        else if (n == 2)
        {
            window.color = windowlightFornight;
        }
        else if (n == 3)
        {
            window.color = windowlightOff;
        }
    }
}
