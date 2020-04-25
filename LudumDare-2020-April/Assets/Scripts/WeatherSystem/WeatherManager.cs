using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Header("References")]
    public GameObject groundObject;
    public GameObject cloudPrefabObject;
    public GameObject sunPrefabObject;
    public GameObject minXPosition, maxXPosition, minZPosition, maxZPosition;

    [Header("Weather Spawner")]
    public int maxAmountOfCloudsAndSuns = 10;
    public int spawnRateInSeconds = 5;

    [Header("Sun and Cloud Stats")]
    public float growRate = 0.005f;
    public int idleTimeInSeconds = 2;
    [HideInInspector] public float maxSize;

    float randomPositionX, randomPositionZ;
    Vector3 newCloudPosition;
    bool spawnCloud;

    private void Awake()
    {
        maxSize = 300;
        CreateSectors();
        StartCoroutine(SpawnCloud());
    }

    void CreateSector()
    {

    }

    IEnumerator SpawnCloud()
    {
        for (int i = 0; i < maxAmountOfCloudsAndSuns; i++) {
            //Get random position for the cloud
            randomPositionX = Random.Range(minXPosition.transform.position.x, maxXPosition.transform.position.x);
            randomPositionZ = Random.Range(minZPosition.transform.position.z, maxZPosition.transform.position.z);
            newCloudPosition = new Vector3(randomPositionX, gameObject.transform.position.y, randomPositionZ);
            //Determine if a cloud or a sun must be spawned
            if (spawnCloud) {
                spawnCloud = false;
                newCloudPosition = new Vector3(randomPositionX, groundObject.transform.position.y + 0.55f, randomPositionZ);
                Instantiate(cloudPrefabObject, newCloudPosition, Quaternion.Euler(90, 0, 0), gameObject.transform);
            } else{
                spawnCloud = true;
                newCloudPosition = new Vector3(randomPositionX, groundObject.transform.position.y + 0.55f, randomPositionZ);
                Instantiate(sunPrefabObject, newCloudPosition, Quaternion.Euler(90, 0, 0), gameObject.transform);
            }
            //Delay before spawning another cloud
            yield return new WaitForSeconds(spawnRateInSeconds);
        }
        yield return null;
    }

}