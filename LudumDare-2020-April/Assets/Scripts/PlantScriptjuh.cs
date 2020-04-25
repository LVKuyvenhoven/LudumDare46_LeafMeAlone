using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlantScriptjuh : MonoBehaviour
{
    public Canvas ui;

    public Slider WaterSlider;
    public Slider SunSlider;

    public float SunStatus = 100;
    public float MaxSunStatus = 100;

    public float WaterStatus = 100;
    public float MaxWaterStatus = 100;

    public static Vector3 posP2;
    public static Vector3 posP1;

    public int SunDecreaseSpeed;
    public int SunIncreaseSpeed;

    public int RainDecreaseSpeed;
    public int RainIncreaseSpeed;

    public int range = 10;

    public bool InSun;
    public bool InRain;

    void Update()
    {
        StatusUpdate();
        CheckStatus();
        updateUi();
    }

    void updateUi()
    {
        if(Vector3.Distance(posP1, this.transform.position) < range || Vector3.Distance(posP2, this.transform.position) < range)
        {
            ui.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            ui.GetComponent<Canvas>().enabled = false;
        }
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

        WaterSlider.value = WaterStatus;
        SunSlider.value = SunStatus;
    }

    void CheckStatus()
    {
        if(SunStatus <= 0 || WaterStatus <= 0)
        {
            Scoreboard.PlantsDead = Scoreboard.PlantsDead + 1;
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
