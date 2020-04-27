using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public string scene;

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
            Application.LoadLevel(scene);
            //SceneManager.LoadScene(scene);
        }
    }
}
