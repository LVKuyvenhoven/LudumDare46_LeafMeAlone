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
    public int spawnRateInSeconds = 5;
    [Range(0.5f, 2.8f)]
    public float spawnOffset;
    [HideInInspector] public int maxAmountOfCloudsAndSuns = 10000;

    [Header("Sun and Cloud Stats")]
    public float growRate = 0.005f;
    public int idleTimeInSeconds = 2;
    [HideInInspector] public float maxSize;

    [Header("Variables")]
    int elementsInList;
    float minXPosition, maxXPosition, minYPosition, maxYPosition;
    float randomPositionX, randomPositionZ, distanceToPreviousX, distanceToPreviousZ;
    //float previousPositionX, previousPositionZ, 
    Vector3 newCloudPosition;
    bool spawnANewObject, spawnCloud, spawnLocationChosen, foundABadPosition;

    List<float> previousXPositions = new List<float>();
    List<float> previousZPositions = new List<float>();

    private void Awake()
    {
        maxSize = 300;
        previousXPositions.Add(100f);
        previousZPositions.Add(100f);
    }

    private void FixedUpdate()
    {
        if (!spawnANewObject)
        {
            spawnANewObject = true;
            StartCoroutine(SpawnCloud());
        }
    }

    IEnumerator SpawnCloud()
    {
        //Get a random spawn position
        while (!spawnLocationChosen)
        {
            //Get a random position within the boundaries
            randomPositionX = Random.Range(minXPositionFrame.transform.position.x + 3, maxXPositionFrame.transform.position.x - 3);
            randomPositionZ = Random.Range(minZPositionFrame.transform.position.z + 1, maxZPositionFrame.transform.position.z - 3);

            foundABadPosition = false;
            //Check all the previous X positions
            foreach (float position in previousXPositions)
            {
                distanceToPreviousX = Mathf.Abs(randomPositionX - position);
                //Check if the distance between the new position and the previous position is bigger 
                if (distanceToPreviousX < spawnOffset)
                {
                    //This position is not good
                    foundABadPosition = true;
                }
            }
            //Check all the previous Z positions
            foreach (float position in previousZPositions)
            {
                distanceToPreviousZ = Mathf.Abs(randomPositionZ - position);
                //Check if the distance between the new position and the previous position is bigger 
                if (distanceToPreviousZ < spawnOffset)
                {
                    //This position is not good
                    foundABadPosition = true;
                }
            }
            if (!foundABadPosition)
            {
                spawnLocationChosen = true;
            }
            yield return null;
        }
        spawnLocationChosen = false;

        newCloudPosition = new Vector3(randomPositionX, gameObject.transform.position.y, randomPositionZ);
        previousXPositions.Add(randomPositionX);
        previousZPositions.Add(randomPositionZ);

        //Make sure the list won't be too long, so that we can keep spawning clouds and sunrays
        elementsInList += 1;
        if (elementsInList >= 3)
        {
            previousXPositions.RemoveAt(0);
            previousZPositions.RemoveAt(0);
            //elementsInList -= 1;
        }

        //Determine if a cloud or a sun must be spawned
        if (spawnCloud)
        {
            spawnCloud = false;
            newCloudPosition = new Vector3(randomPositionX, groundObject.transform.position.y + 0.55f, randomPositionZ);
            Instantiate(cloudPrefabObject, newCloudPosition, Quaternion.Euler(90, 0, 0), gameObject.transform);
        }
        else
        {
            spawnCloud = true;
            newCloudPosition = new Vector3(randomPositionX, groundObject.transform.position.y + 0.55f, randomPositionZ);
            Instantiate(sunPrefabObject, newCloudPosition, Quaternion.Euler(90, 0, 0), gameObject.transform);
        }
        //Delay before spawning another cloud
        //StartCoroutine(MakeRoomForNewCloud());
        yield return new WaitForSeconds(spawnRateInSeconds);
        spawnANewObject = false;
    }

    IEnumerator MakeRoomForNewCloud()
    {
        yield return new WaitForSeconds(idleTimeInSeconds);
        elementsInList -= 1;
    }

}