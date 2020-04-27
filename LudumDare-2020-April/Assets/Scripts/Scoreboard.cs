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

    [Header("Plant References for Disabling")]
    public GameObject plantone;
    public GameObject planttwo;
    public GameObject plantthree;
    public GameObject plantfour;
    public GameObject plantfive;
    public GameObject plantsix;

    bool gameIsDone = true;

    void Start()
    {
        Debug.Log(gameIsDone.ToString() + "start");
        Debug.Log(CurrentPlatsDead.ToString(0 + "start"));
        CurrentPlatsDead = 0;
        deadlabel.text = "" + (0 - CurrentPlatsDead);
        timelabel.text = "00:00";
        StartCoroutine(ResetGame());
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(5f);
        gameIsDone = false;
    }

    void Update()
    {
        if(CurrentPlatsDead != PlantsDead)
        {
            CurrentPlatsDead = PlantsDead;
            deadlabel.text = "" + (0 + CurrentPlatsDead);
        }
        if (CurrentPlatsDead >= 4)
        {
            if (plantone != null)
            {
                plantone.SetActive(false);
            }
            if (planttwo != null)
            {
                planttwo.SetActive(false);
            }
            if (plantthree != null)
            {
                plantthree.SetActive(false);
            }
            if (plantfour != null)
            {
                plantfour.SetActive(false);
            }
            if (plantfive != null)
            {
                plantfive.SetActive(false);
            }
            if (plantsix != null)
            {
                plantsix.SetActive(false);
            }
            if (!gameIsDone)
            {
                gameIsDone = true;
                CurrentPlatsDead = 0;
                EndGame();
            }
        }
        CountPlayingTime();
    }

    void EndGame()
    {
        Debug.Log(gameIsDone.ToString() + "start");
        Debug.Log(CurrentPlatsDead.ToString(0 + "start"));
        SceneManager.LoadScene("Game");
    }

    void CountPlayingTime()
    {
        timeAlive += 1 * Time.deltaTime;
        timelabel.text = Mathf.Round(timeAlive).ToString() + " seconds";
    }

}
