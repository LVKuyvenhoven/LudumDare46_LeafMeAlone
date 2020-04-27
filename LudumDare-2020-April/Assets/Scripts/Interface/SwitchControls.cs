using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void SwitchTheControlScreen()
    {
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