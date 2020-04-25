using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Header("References")]
    public GameObject groundObject;
    public GameObject cloudPrefabObject;
    public GameObject sunPrefabObject;
    [HideInInspector] public GameObject minXPositionFrame, maxXPositionFrame, minZPositionFrame, maxZPositionFrame;

    [Header("Weather Spawner")]
    public int maxAmountOfCloudsAndSuns = 10;
    public int spawnRateInSeconds = 5;
    public float spawnOffset;

    [Header("Sun and Cloud Stats")]
    public float growRate = 0.005f;
    public int idleTimeInSeconds = 2;
    [HideInInspector] public float maxSize;

    [Header("Variables")]
    int sectorIndex, previousSectorIndex;
    float minXPosition, maxXPosition, minYPosition, maxYPosition;
    float randomPositionX, randomPositionZ, previousPositionX, previousPositionZ, distanceToPreviousX, distanceToPreviousZ;
    Vector3 newCloudPosition;
    bool spawnCloud, spawnLocationChosen;

    private void Awake()
    {
        maxSize = 300;
        StartCoroutine(SpawnCloud());
    }

    IEnumerator SpawnCloud()
    {
        for (int i = 0; i < maxAmountOfCloudsAndSuns; i++) {
            //Get a random spawn position
            while (!spawnLocationChosen) {
                //Get a random position within the boundaries
                randomPositionX = Random.Range(minXPositionFrame.transform.position.x + 3, maxXPositionFrame.transform.position.x - 3);
                randomPositionZ = Random.Range(minZPositionFrame.transform.position.z + 3, maxZPositionFrame.transform.position.z - 3);
                //Calculate the distance to the previous position
                distanceToPreviousX = Mathf.Abs(randomPositionX - previousPositionX);
                distanceToPreviousZ = Mathf.Abs(randomPositionZ - previousPositionZ);
                if (distanceToPreviousX > spawnOffset || distanceToPreviousZ > spawnOffset) {
                    //Pick again
                } else {
                    spawnLocationChosen = true;
                }
                yield return null;
            }
            spawnLocationChosen = false;

            newCloudPosition = new Vector3(randomPositionX, gameObject.transform.position.y, randomPositionZ);
            previousPositionX = randomPositionX;
            previousPositionZ = randomPositionZ;

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