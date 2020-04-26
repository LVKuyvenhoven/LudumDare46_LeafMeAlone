using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundaries : MonoBehaviour
{
    [Header("Boundary Setting")]
    public bool westBoundary;
    public bool northBoundary;
    public bool eastBoundary;
    public bool southBoundary;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plant")
        {
            if (westBoundary)
            {
                other.gameObject.transform.position = new Vector3(
                    other.gameObject.transform.position.x + 2,
                    other.gameObject.transform.position.y,
                    other.gameObject.transform.position.z);
            }
            if (northBoundary)
            {
                other.gameObject.transform.position = new Vector3(
                    other.gameObject.transform.position.x,
                    other.gameObject.transform.position.y,
                    other.gameObject.transform.position.z - 2);
            }
            if (eastBoundary)
            {
                other.gameObject.transform.position = new Vector3(
                    other.gameObject.transform.position.x - 2,
                    other.gameObject.transform.position.y,
                    other.gameObject.transform.position.z);
            }
            if (southBoundary)
            {
                other.gameObject.transform.position = new Vector3(
                    other.gameObject.transform.position.x,
                    other.gameObject.transform.position.y,
                    other.gameObject.transform.position.z + 2);
            }
        }
    }

}