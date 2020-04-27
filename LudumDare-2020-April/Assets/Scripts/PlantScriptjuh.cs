using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using FMODUnity;
using UnityEngine;

public class PlantScriptjuh : MonoBehaviour
{
    [Header("Plant Mood Settings")]
    [HideInInspector] public GameObject plantMoodManagerObject;
    PlantMoodManager plantMoodScript;
    SpriteRenderer plantFaceRenderer;

    public Canvas ui;

    public GameObject p1;
    public GameObject p2;

    public Slider WaterSlider;
    public Slider SunSlider;

    public int WaterAmount;
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

    public int range = 2;

    public bool InSun;
    public bool InRain;

    bool startCrying, startJay, startDeath;
    FMOD.Studio.EventInstance getWater;

    private void Awake()
    {
        getWater = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Watering/Watering");
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        plantMoodManagerObject = GameObject.Find("PlantMoodManager");
        plantMoodScript = plantMoodManagerObject.GetComponent<PlantMoodManager>();
        plantFaceRenderer = GetComponentInChildren<SpriteRenderer>();
        plantFaceRenderer.sprite = plantMoodScript.neutralSprite;
    }

    private void Start()
    {
        RuntimeManager.AttachInstanceToGameObject(getWater, gameObject.transform, GetComponent<Rigidbody>());
    }

    void Update()
    {
        StatusUpdate();
        CheckStatus();
        updateUi();
    }

    void updateUi()
    {
        if (Vector3.Distance(posP2, this.transform.position) < range)
        {
            WaterAmount = p2.GetComponent<Movement_Script>().WaterAmount;
            ui.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetButtonDown("XControllerTwo"))
            {
                if (WaterAmount >= 25)
                {
                    if (WaterStatus < 90)
                    {
                        getWater.start();
                        WaterAmount = WaterAmount - 25;
                        WaterStatus = WaterStatus + 10;
                        p2.GetComponent<Movement_Script>().WaterAmount = WaterAmount;
                    }
                }
            }
        }

        if (Vector3.Distance(posP1, this.transform.position) < range)
        {
            WaterAmount = p1.GetComponent<Movement_Script>().WaterAmount;
            ui.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("XControllerOne"))
            {
                if (WaterAmount >= 25)
                {
                    if (WaterStatus < 90)
                    {
                        getWater.start();
                        WaterAmount = WaterAmount - 25;
                        WaterStatus = WaterStatus + 10;
                        p1.GetComponent<Movement_Script>().WaterAmount = WaterAmount;
                    }
                }
            }
        }

        

        if (Vector3.Distance(posP2, this.transform.position) > range && Vector3.Distance(posP1, this.transform.position) > range)
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
            plantMoodScript.StopHungry(gameObject.name);
            plantMoodScript.PlayDeath(gameObject.name);
            Destroy(this.gameObject);
        }
        CheckMood();
    }

    void CheckMood()
    {
        //Display mood
        if ((SunStatus < 50 && WaterStatus < 50))
        {
            //Cry if both statusses are below 50
            plantFaceRenderer.sprite = plantMoodScript.hungrySprite;
            if (!startCrying)
            {
                startCrying = true;
                plantMoodScript.PlayHungry(gameObject.name);
            }
        }
        else
        {
            //Cry if hungry and not in the sun
            if (SunStatus < 50 && !InSun)
            {
                plantFaceRenderer.sprite = plantMoodScript.hungrySprite;
                if (!startCrying)
                {
                    startCrying = true;
                    startJay = false;
                    plantMoodScript.PlayHungry(gameObject.name);
                }
            }
            else
            {
                //Cry if thirsty and not in the rain
                if (WaterStatus < 50 && !InRain)
                {
                    plantFaceRenderer.sprite = plantMoodScript.hungrySprite;
                    if (!startCrying)
                    {
                        startCrying = true;
                        startJay = false;
                        plantMoodScript.PlayHungry(gameObject.name);
                    }
                }
                else
                {
                    if ((SunStatus < 50 || WaterStatus < 50) || (InRain || InSun))
                    {
                        plantFaceRenderer.sprite = plantMoodScript.happySprite;
                        if (!startJay)
                        {
                            startJay = true;
                            startCrying = false;
                            plantMoodScript.PlayJay(gameObject.name);
                        }
                    }
                    else
                    {
                        startJay = false;
                        startCrying = false;
                        plantFaceRenderer.sprite = plantMoodScript.neutralSprite;
                        plantMoodScript.StopHungry(gameObject.name);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SunRay") {
            InSun = true;
            //plantFaceRenderer.sprite = plantMoodScript.happySprite;
        }
        if (other.tag == "Rain") {
            InRain = true;
            //plantFaceRenderer.sprite = plantMoodScript.happySprite;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SunRay") {
            InSun = false;
        }
        if (SunStatus < 50 || WaterStatus < 50) {
            //plantFaceRenderer.sprite = plantMoodScript.hungrySprite;
        } else {
            //plantFaceRenderer.sprite = plantMoodScript.neutralSprite;
        }

        if (other.tag == "Rain") {
            InRain = false;
        }
        if (SunStatus < 50 || WaterStatus < 50) {
            //plantFaceRenderer.sprite = plantMoodScript.hungrySprite;
        } else {
            //plantFaceRenderer.sprite = plantMoodScript.neutralSprite;
        }
    }

}