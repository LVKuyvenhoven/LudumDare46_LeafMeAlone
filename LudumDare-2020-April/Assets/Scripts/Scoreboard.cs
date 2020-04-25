using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public static int PlantsDead;
    public static int CurrentPlatsDead;

    public TextMeshProUGUI deadlabel;

    void Start()
    {
        CurrentPlatsDead = 0;
        deadlabel.text = "" + CurrentPlatsDead;
    }

    void Update()
    {
        if(CurrentPlatsDead != PlantsDead)
        {
            CurrentPlatsDead = PlantsDead;
            deadlabel.text = ""+CurrentPlatsDead;
        }
    }
}
