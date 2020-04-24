using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Header("References")]
    public GameObject cloudPrefabObject;
    public GameObject minXPosition, maxXPosition, minZPosition, maxZPosition;

    [Header("Variables")]
    float randomPositionX, randomPositionZ;
    Vector3 newCloudPosition;
    int maxAmountOfClouds = 10;

    private void Awake()
    {
        StartCoroutine(SpawnCloud());
    }

    IEnumerator SpawnCloud()
    {
        for (int i = 0; i < maxAmountOfClouds; i++)
        {
            //Get random position for the cloud
            randomPositionX = Random.Range(minXPosition.transform.position.x, maxXPosition.transform.position.x);
            randomPositionZ = Random.Range(minZPosition.transform.position.z, maxZPosition.transform.position.z);
            newCloudPosition = new Vector3(randomPositionX, gameObject.transform.position.y, randomPositionZ);
            //Instantiate the cloud at the sky parent
            Instantiate(cloudPrefabObject, newCloudPosition, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }

}