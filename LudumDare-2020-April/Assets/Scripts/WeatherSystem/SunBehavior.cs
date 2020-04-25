using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehavior : MonoBehaviour
{
    [Header("Variables")]
    public float scalingSpeed;
    Light lt;

    private void Awake()
    {
        lt = GetComponent<Light>();
        lt.type = LightType.Spot;
        StartCoroutine(SizeCloud());
    }

    IEnumerator SizeCloud()
    {
        while (lt.spotAngle < 10) {
            lt.spotAngle += scalingSpeed;
            yield return null;
        }
        yield return null;
    }

}