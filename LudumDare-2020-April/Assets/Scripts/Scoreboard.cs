using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public static int PlantsDead;
    public static int CurrentPlatsDead;

    public float timeAlive;

    public TextMeshProUGUI deadlabel;
    public TextMeshProUGUI timelabel;

    void Start()
    {
        CurrentPlatsDead = 0;
        deadlabel.text = "" + CurrentPlatsDead;
        timelabel.text = "00:00";
    }

    void Update()
    {
        if(CurrentPlatsDead != PlantsDead)
        {
            CurrentPlatsDead = PlantsDead;
            deadlabel.text = ""+CurrentPlatsDead;
        }
        if (CurrentPlatsDead == 4)
        {
            SceneManager.LoadScene("Menu");
        }
        CountPlayingTime();
    }

    void CountPlayingTime()
    {
        timeAlive += 1 * Time.deltaTime;
        timelabel.text = Mathf.Round(timeAlive).ToString() + " seconds";
    }

}
