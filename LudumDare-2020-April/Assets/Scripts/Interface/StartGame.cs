using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public string scene;

    public void StartTheGame()
    {
        Debug.Log("start");
        SceneManager.LoadScene("Game");
        Scoreboard.CurrentPlatsDead = 0;
    }

}
