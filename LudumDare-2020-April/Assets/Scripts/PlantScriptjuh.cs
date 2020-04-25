using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScriptjuh : MonoBehaviour
{
    public float SunStatus = 100;
    public float MaxSunStatus = 100;

    public float WaterStatus = 100;
    public float MaxWaterStatus = 100;

    public int SunDecreaseSpeed;
    public int SunIncreaseSpeed;

    public int RainDecreaseSpeed;
    public int RainIncreaseSpeed;

    public bool InSun;
    public bool InRain;

    void Update()
    {
        StatusUpdate();
        CheckStatus();
    }

    void StatusUpdate()
    {
        if (!InSun)
        {
            SunStatus -= SunDecreaseSpeed * Time.deltaTime;
        }else if (InSun)
        {
            if (SunStatus <= MaxSunStatus)
            {
                SunStatus += SunIncreaseSpeed * Time.deltaTime;
            }
        }

        if (!InRain)
        {
            WaterStatus -= RainDecreaseSpeed * Time.deltaTime;
        }else if (InRain)
        {
            if (WaterStatus <= MaxWaterStatus)
            {
                WaterStatus += RainIncreaseSpeed * Time.deltaTime;
            } 
        }
    }

    void CheckStatus()
    {
        if(SunStatus <= 0 || WaterStatus <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SunRay")
        {
            InSun = true;
        }

        if (other.tag == "Rain")
        {
            InRain = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SunRay")
        {
            InSun = false;
        }

        if (other.tag == "Rain")
        {
            InRain = false;
        }
    }
}
