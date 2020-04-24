using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Header("References")]
    public GameObject cloudPrefabObject;

    [Header("Variables")]
    public float maxXPosition, maxZPosition, yPosition;
    float randomPositionX, randomPositionZ;
    Vector3 newCloudPosition;

    private void Awake()
    {
        StartCoroutine(SpawnCloud());
    }

    IEnumerator SpawnCloud()
    {
        randomPositionX = Random.Range(0, maxXPosition);
        randomPositionZ = Random.Range(0, maxZPosition);
        newCloudPosition = new Vector3(randomPositionX, 10, randomPositionZ);
        Instantiate(cloudPrefabObject, newCloudPosition, Quaternion.identity, gameObject.transform);
        yield return null;
    }

}