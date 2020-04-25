using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Header("References")]
    public GameObject cloudPrefabObject;
    public GameObject sunPrefabObject;
    public GameObject minXPosition, maxXPosition, minZPosition, maxZPosition;

    [Header("Variables")]
    public int maxAmountOfClouds;
    public int spawnRate;
    float randomPositionX, randomPositionZ;
    Vector3 newCloudPosition;

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
            //Delay before spawning another cloud
            yield return new WaitForSeconds(spawnRate);
        }
        yield return null;
    }

}