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

    public int SunDecreaseSpeed;
    public int SunIncreaseSpeed;

    public int RainDecreaseSpeed;
    public int RainIncreaseSpeed;

    public GameObject player1;
    public GameObject player2;

    public bool InSun;
    public bool InRain;

    void Update()
    {
        StatusUpdate();
        CheckStatus();

        Vector3 plantPos = this.transform.position;

        Vector3 Player1Pos = player1.transform.position;
        Vector3 Player2Pos = player2.transform.position;

        int range = 5;

        if (Vector3.Distance(Player1Pos, plantPos) < range || Vector3.Distance(Player2Pos, plantPos) < range)
        {
            ui.enabled = true;
        }
        else if (Vector3.Distance(Player1Pos, plantPos) > range || Vector3.Distance(Player2Pos, plantPos) > range)
        {
            ui.enabled = false;
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
