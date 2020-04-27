using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchControls : MonoBehaviour
{
    public string scene;

    public GameObject pcButton;
    public GameObject playstationButton;
    public GameObject playstationBase;
    public GameObject pcBase;

    public bool switchToPC;
    FMOD.Studio.EventInstance clickSound;

    private void Awake()
    {
        clickSound = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Click");
    }

    void Start()
    {
        RuntimeManager.AttachInstanceToGameObject(clickSound, gameObject.transform, GetComponent<Rigidbody>());
    }

    public void SwitchTheControlScreen()
    {
        clickSound.start();
        if (switchToPC)
        {
            pcButton.SetActive(true);
            pcBase.SetActive(true);
            playstationBase.SetActive(false);
            playstationButton.SetActive(false);
        }
        else
        {
            pcButton.SetActive(false);
            pcBase.SetActive(false);
            playstationBase.SetActive(true);
            playstationButton.SetActive(true);
        }
    }

}