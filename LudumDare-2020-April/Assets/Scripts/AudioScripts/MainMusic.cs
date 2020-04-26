using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    FMOD.Studio.EventInstance mainTrack;

    void Awake()
    {
        RuntimeManager.AttachInstanceToGameObject(mainTrack, gameObject.transform, GetComponent<Rigidbody>());
        mainTrack.start();
    }

    private void FixedUpdate()
    {
        //mainTrack.setParameterByName("rain", 1f);
    }

}