using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehavior : MonoBehaviour
{
    [Header("References")]
    GameObject skyObject;
    WeatherManager weatherScript;
    SpriteRenderer sunRenderer;

    [Header("Variables")]
    float timeToScale;
    float opacity;

    private void Awake()
    {
        //Get required components
        sunRenderer = gameObject.GetComponent<SpriteRenderer>();
        skyObject = GameObject.Find("Sky");
        weatherScript = skyObject.GetComponent<WeatherManager>();
        //Start scaling
        StartCoroutine(SizeSunray());
    }

    IEnumerator SizeSunray()
    {
        while (timeToScale < weatherScript.maxSize) {
            timeToScale += 1;
            //Increase opacity of sunray
            opacity += weatherScript.growRate * 2;
            sunRenderer.color = new Color(1, 1, 1, opacity);
            //Increase size of sunray
            gameObject.transform.localScale += new Vector3(weatherScript.growRate, weatherScript.growRate, weatherScript.growRate);
            yield return null;
        }
        StartCoroutine(DestroyThisSun());
        yield return null;
    }

    IEnumerator DestroyThisSun()
    {
        yield return new WaitForSeconds(weatherScript.idleTimeInSeconds);
        while (timeToScale > 1) {
            timeToScale -= 2;
            //Decrease opacity of sunray
            opacity -= weatherScript.growRate;
            sunRenderer.color = new Color(1, 1, 1, opacity);
            //Decrease size of sunray
            gameObject.transform.localScale -= new Vector3(weatherScript.growRate * 2, weatherScript.growRate * 2, weatherScript.growRate * 2);
            yield return null;
        }
        yield return null;
        //Destroy sunray
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

}