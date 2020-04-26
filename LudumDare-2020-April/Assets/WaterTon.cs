using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTon : MonoBehaviour
{
    public int range = 2;
    public static Vector3 posP2;
    public static Vector3 posP1;
    public Canvas P1WaterLevel;
    public Canvas P2WaterLevel;

    public KeyCode player1SpecialKey;
    public KeyCode player2SpecialKey;

    // Update is called once per frame
    void Update()
    {
        updateUi();
    }

    void updateUi()
    {
        if (Vector3.Distance(posP1, this.transform.position) < range)
        {
            P1WaterLevel.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(player1SpecialKey))
            {
                Debug.Log("Player 1 Press en dichtbij");
            }
        }
        else
        {
            P1WaterLevel.GetComponent<Canvas>().enabled = false;
        }

        if (Vector3.Distance(posP2, this.transform.position) < range)
        {
            P2WaterLevel.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(player2SpecialKey))
            {
                Debug.Log("Player 2 Press en dichtbij");
            }
        }
        else
        {
            P2WaterLevel.GetComponent<Canvas>().enabled = false;
        }
    }
}
