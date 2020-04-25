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

    [Header("Variables")]
    float timeToScale;
    float opacity;
    Vector3 despawnTriggerBoxPosition;

    private void Awake()
    {
        //Get required components
        cloudRenderer = gameObject.GetComponent<SpriteRenderer>();
        skyObject = GameObject.Find("Sky");
        weatherScript = skyObject.GetComponent<WeatherManager>();
        //Start scaling
        StartCoroutine(SizeCloud());
    }

    IEnumerator SizeCloud()
    {
        while (timeToScale < weatherScript.maxSize) {
            timeToScale += 1;
            //Increase opacity of shadow
            opacity += weatherScript.growRate * 2;
            cloudRenderer.color = new Color(1, 1, 1, opacity);
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
            opacity -= weatherScript.growRate;
            cloudRenderer.color = new Color(1, 1, 1, opacity);
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