using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{
    [Header("Variables")]
    public float scalingSpeed;
    float timeToScale, maxScale = 500;

    private void Awake()
    {
        StartCoroutine(SizeCloud());
    }

    IEnumerator SizeCloud()
    {
        while (timeToScale < maxScale)
        {
            timeToScale += 1;
            gameObject.transform.localScale += new Vector3(scalingSpeed, scalingSpeed, scalingSpeed);
            yield return null;
        }
        yield return null;
    }

}