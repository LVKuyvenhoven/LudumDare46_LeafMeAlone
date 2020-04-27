using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public string scene;

    public GameObject controlsParent;
    public GameObject titleParent;

    FMOD.Studio.EventInstance clickSound;

    private void Awake()
    {
        clickSound = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Click");
    }

    void Start()
    {
        RuntimeManager.AttachInstanceToGameObject(clickSound, gameObject.transform, GetComponent<Rigidbody>());
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    [System.Obsolete]
    void TaskOnClick()
    {
        if (scene == "Exit")
        {
            clickSound.start();
            Application.Quit();
        }
        else
        {
            clickSound.start();
            controlsParent.SetActive(true);
            titleParent.SetActive(false);
        }
    }
}
