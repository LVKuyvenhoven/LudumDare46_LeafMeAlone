using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaedOnTimeWijzer : MonoBehaviour
{
    public int wijzer;
    public Image wijzerSprite;
    int rotation = -90;
    // Update is called once per frame
    void Update()
    {
        wijzer = (int)sun.hour;
        
        if(wijzer == 0) {
            wijzerSprite.transform.rotation = Quaternion.Euler(0,0,180 - rotation);
        }

        if (wijzer == 1)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 165 - rotation);
        }

        if (wijzer == 2)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 150 - rotation);
        }

        if (wijzer == 3)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 135 - rotation);
        }

        if (wijzer == 4)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 120 - rotation);
        }

        if (wijzer == 5)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 105 - rotation);
        }

        if (wijzer == 6)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 90 - rotation);
        }

        if (wijzer == 7)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 75 - rotation);
        }

        if (wijzer == 8)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 60 - rotation);
        }

        if (wijzer == 9)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 45 - rotation);
        }

        if (wijzer == 10)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 30 - rotation);
        }

        if (wijzer == 11)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 15 - rotation);
        }

        if (wijzer == 12)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, 0 - rotation);
        }


        if (wijzer == 13)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -15 - rotation);
        }

        if (wijzer == 14)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -30 - rotation);
        }

        if (wijzer == 15)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -45 - rotation);
        }

        if (wijzer == 16)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -60 - rotation);
        }

        if (wijzer == 17)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -75 - rotation);
        }

        if (wijzer == 18)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -90 - rotation);
        }

        if (wijzer == 19)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -105 - rotation);
        }

        if (wijzer == 20)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -120 - rotation);
        }

        if (wijzer == 21)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -135 - rotation);
        }

        if (wijzer == 22)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -150 - rotation);
        }

        if (wijzer == 23)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -165 - rotation);
        }

        if (wijzer == 24)
        {
            wijzerSprite.transform.rotation = Quaternion.Euler(0, 0, -180 - rotation);
        }
    }
}
