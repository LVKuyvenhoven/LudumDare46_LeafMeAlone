using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{
    [Header("References")]
    GameObject skyObject;
    WeatherManager weatherScript;
    SpriteRenderer cloudRenderer;
    public GameObject triggerBox;
    [HideInInspector] public GameObject sunObject;
    sun sunScript;

    [Header("Variables")]
    public bool thisIsARainyCloud;
    float timeToScale;
    float opacity;
    Vector3 despawnTriggerBoxPosition;

    private void Awake()
    {
        //Get required components
        cloudRenderer = gameObject.GetComponent<SpriteRenderer>();
        skyObject = GameObject.Find("Sky");
        weatherScript = skyObject.GetComponent<WeatherManager>();
        sunObject = GameObject.Find("sun");
        sunScript = sunObject.GetComponent<sun>();
        //Start scaling
        StartCoroutine(SizeCloud());
    }

    IEnumerator SizeCloud()
    {
        while (timeToScale < weatherScript.maxSize) {
            timeToScale += 1;
            //Increase opacity of shadow
            opacity += weatherScript.growRate * 2;
            if (thisIsARainyCloud) {
                cloudRenderer.color = new Color(1, 1, 1, opacity);
            } else {
                //Set the right color for the sun/moon rays
                if (sunScript.hour > 7 && sunScript.hour < 18) {
                    cloudRenderer.color = new Color(1, 1, 1, opacity);
                } else {
                    cloudRenderer.color = new Color(0, 0.15f, 0.5f, opacity);
                }
            }
            //Increase size of shadow
            gameObject.transform.localScale += new Vector3(weatherScript.growRate, weatherScript.growRate, weatherScript.growRate);
            yield return null;
        }
        StartCoroutine(DestroyThisCloud());
        yield return null;
    }

    IEnumerator DestroyThisCloud()
    {
        yield return new WaitForSeconds(weatherScript.idleTimeInSeconds);
        despawnTriggerBoxPosition = triggerBox.transform.position - new Vector3(0, 10, 0);
        while (timeToScale > 1) {
            timeToScale -= 2;
            //Decrease opacity of shadow
            opacity -= weatherScript.growRate * 2;
            if (thisIsARainyCloud) {
                cloudRenderer.color = new Color(1, 1, 1, opacity);
            } else {
                //Set the right color for the sun/moon rays
                if (sunScript.hour > 7 && sunScript.hour < 18) {
                    cloudRenderer.color = new Color(1, 1, 1, opacity);
                } else {
                    cloudRenderer.color = new Color(0, 0.15f, 0.5f, opacity);
                }
            }
            //Decrease size of shadow
            gameObject.transform.localScale -= new Vector3(weatherScript.growRate * 2, weatherScript.growRate * 2, weatherScript.growRate * 2);
            //Move trigger box away so the plant will stop regenerating health
            triggerBox.transform.position = Vector3.MoveTowards(triggerBox.transform.position, despawnTriggerBoxPosition, 1.5f * Time.deltaTime);
            yield return null;
        }
        yield return null;
        //Destroy shadow
        Destroy(gameObject);
    }

}