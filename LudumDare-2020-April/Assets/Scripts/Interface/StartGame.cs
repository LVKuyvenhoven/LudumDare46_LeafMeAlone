using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public string scene;
    FMOD.Studio.EventInstance clickSound;

    private void Awake()
    {
        clickSound = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Click");
    }

    void Start()
    {
        RuntimeManager.AttachInstanceToGameObject(clickSound, gameObject.transform, GetComponent<Rigidbody>());
    }

    public void StartTheGame()
    {
        clickSound.start();
        SceneManager.LoadScene("Game");
        Scoreboard.CurrentPlatsDead = 0;
    }

}
