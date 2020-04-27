using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public string scene;

    public GameObject controlsParent;
    public GameObject titleParent;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    [System.Obsolete]
    void TaskOnClick()
    {
        if (scene == "Exit")
        {
            Application.Quit();
        }
        else
        {
            controlsParent.SetActive(true);
            titleParent.SetActive(false);
            //Application.LoadLevel(scene);
            //Scoreboard.CurrentPlatsDead = 0;

            //SceneManager.LoadScene(scene);
        }
    }
}
