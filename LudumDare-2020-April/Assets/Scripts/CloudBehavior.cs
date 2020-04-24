using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{
    [Header("Variables")]
    float timeToScale;

    private void Awake()
    {
        StartCoroutine(SizeCloud());
    }

    IEnumerator SizeCloud()
    {
        while (timeToScale < 1000)
        {
            Debug.Log(timeToScale);
            yield return null;
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        yield return null;
    }

}