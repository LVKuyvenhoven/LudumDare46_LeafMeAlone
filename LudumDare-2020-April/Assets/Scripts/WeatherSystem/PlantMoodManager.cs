using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PlantMoodManager : MonoBehaviour
{
    [Header("Face sprites")]
    public Sprite neutralSprite;
    public Sprite hungrySprite;
    public Sprite happySprite;

    [Header("References")]
    public GameObject plantOne;
    public GameObject plantTwo;
    public GameObject plantThree;
    public GameObject plantFour;
    public GameObject plantFive;
    public GameObject plantSix;

    FMOD.Studio.EventInstance plantOneCry;
    FMOD.Studio.EventInstance plantTwoCry;
    FMOD.Studio.EventInstance plantThreeCry;
    FMOD.Studio.EventInstance plantFourCry;
    FMOD.Studio.EventInstance plantFiveCry;
    FMOD.Studio.EventInstance plantSixCry;

    FMOD.Studio.EventInstance plantOneJoy;
    FMOD.Studio.EventInstance plantTwoJoy;
    FMOD.Studio.EventInstance plantThreeJoy;
    FMOD.Studio.EventInstance plantFourJoy;
    FMOD.Studio.EventInstance plantFiveJoy;
    FMOD.Studio.EventInstance plantSixJoy;

    FMOD.Studio.EventInstance plantOneDeath;
    FMOD.Studio.EventInstance plantTwoDeath;
    FMOD.Studio.EventInstance plantThreeDeath;
    FMOD.Studio.EventInstance plantFourDeath;
    FMOD.Studio.EventInstance plantFiveDeath;
    FMOD.Studio.EventInstance plantSixDeath;

    private void Awake()
    {
        plantOneCry = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Cry_Loop");
        plantTwoCry = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Cry_Loop");
        plantThreeCry = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Cry_Loop");
        plantFourCry = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Cry_Loop");
        plantFiveCry = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Cry_Loop");
        plantSixCry = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Cry_Loop");

        plantOneJoy = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Yay");
        plantTwoJoy = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Yay");
        plantThreeJoy = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Yay");
        plantFourJoy = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Yay");
        plantFiveJoy = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Yay");
        plantSixJoy = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Yay");

        plantOneDeath = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Death");
        plantTwoDeath = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Death");
        plantThreeDeath = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Death");
        plantFourDeath = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Death");
        plantFiveDeath = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Death");
        plantSixDeath = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Plants/Plant_Death");
    }

    private void Start()
    {
        //Attach the cry sound to all plants
        RuntimeManager.AttachInstanceToGameObject(plantOneCry, plantOne.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantTwoCry, plantTwo.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantThreeCry, plantThree.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantFourCry, plantFour.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantFiveCry, plantFive.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantSixCry, plantSix.transform, GetComponent<Rigidbody>());

        //Attach the joy sound to all plants
        RuntimeManager.AttachInstanceToGameObject(plantOneJoy, plantOne.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantTwoJoy, plantTwo.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantThreeJoy, plantThree.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantFourJoy, plantFour.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantFiveJoy, plantFive.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantSixJoy, plantSix.transform, GetComponent<Rigidbody>());

        //Attach the death sound to all plants
        RuntimeManager.AttachInstanceToGameObject(plantOneDeath, plantOne.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantTwoDeath, plantTwo.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantThreeDeath, plantThree.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantFourDeath, plantFour.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantFiveDeath, plantFive.transform, GetComponent<Rigidbody>());
        RuntimeManager.AttachInstanceToGameObject(plantSixDeath, plantSix.transform, GetComponent<Rigidbody>());
    }

    public void PlayHungry(string name)
    {
        if (name == "plantone")
        {
            plantOneCry.start();
        }
        //if (name == "planttwo")
        //{
        //    plantTwoCry.start();
        //}
        //if (name == "plantthree")
        //{
        //    plantThreeCry.start();
        //}
        //if (name == "plantfour")
        //{
        //    plantFourCry.start();
        //}
        //if (name == "plantfive")
        //{
        //    plantFiveCry.start();
        //}
        //if (name == "plantsix")
        //{
        //    plantSixCry.start();
        //}
    }

    public void PlayJay(string name)
    {
        if (name == "plantone")
        {
            plantOneJoy.start();
        }
        //if (name == "planttwo")
        //{
        //    plantTwoJoy.start();
        //}
        //if (name == "plantthree")
        //{
        //    plantThreeJoy.start();
        //}
        //if (name == "plantfour")
        //{
        //    plantFourJoy.start();
        //}
        //if (name == "plantfive")
        //{
        //    plantFiveJoy.start();
        //}
        //if (name == "plantsix")
        //{
        //    plantSixJoy.start();
        //}
    }

    public void PlayDeath(string name)
    {
        if (name == "plantone")
        {
            plantOneDeath.start();
        }
        //if (name == "planttwo")
        //{
        //    plantTwoDeath.start();
        //}
        //if (name == "plantthree")
        //{
        //    plantThreeDeath.start();
        //}
        //if (name == "plantfour")
        //{
        //    plantFourDeath.start();
        //}
        //if (name == "plantfive")
        //{
        //    plantFiveDeath.start();
        //}
        //if (name == "plantsix")
        //{
        //    plantSixDeath.start();
        //}
    }

    public void StopHungry(string name)
    {
        if (name == "plantone")
        {
            plantOneCry.stop(0);
        }
        //if (name == "planttwo")
        //{
        //    plantTwoCry.stop(0);
        //}
        //if (name == "plantthree")
        //{
        //    plantThreeCry.stop(0);
        //}
        //if (name == "plantfour")
        //{
        //    plantFourCry.stop(0);
        //}
        //if (name == "plantfive")
        //{
        //    plantFiveCry.stop(0);
        //}
        //if (name == "plantsix")
        //{
        //    plantSixCry.stop(0);
        //}
    }

}