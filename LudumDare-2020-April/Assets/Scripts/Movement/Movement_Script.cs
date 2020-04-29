using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;

public class Movement_Script : MonoBehaviour
{
    public GameObject defaultModel;
    public GameObject pushingModel;

    public GameObject raycastOrigin;

    public CharacterController controller;
    public GameObject ghostObject;
    public float speed = 12f;
    float gravity = -9.81f;

    public int WaterAmount;

    public GameObject barrel;
    public Canvas WaterLevel;
    public Slider WaterValue;

    public float rangeBarrel;
    public KeyCode playerSpecialKey;

    Vector3 velocity;
    Vector3 move;

    public KeyCode Forward;
    public KeyCode Back;

    public float pushPower = -2000f;

    public KeyCode Right;
    public KeyCode Left;

    RaycastHit hit;

    FMOD.Studio.EventInstance getWater;

    [Header("Set Playstation Controller")]
    public bool thisIsPlayerTwo;
    public string specialKeyPlaystation;

    private void Awake()
    {
        getWater = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Watering/Water_Fill");
    }

    private void Start()
    {
        RuntimeManager.AttachInstanceToGameObject(getWater, gameObject.transform, GetComponent<Rigidbody>());
        WaterAmount = 0;
        WaterValue.value = WaterAmount;
    }

    void Update()
    {
        CheckIfPlantIsBeforeYou();
        WaterValue.value = WaterAmount;
        Movement();
        if(this.gameObject.name == "Player1")
        {
            PlantScriptjuh.posP1 = transform.position;
        }
        else
        {
            PlantScriptjuh.posP2 = transform.position;
        }

        if (Vector3.Distance(barrel.transform.position, this.transform.position) < rangeBarrel)
        {
            WaterLevel.enabled = true;
            if (Input.GetKeyDown(playerSpecialKey) || Input.GetButtonDown(specialKeyPlaystation))
            {
                if(WaterAmount < 100)
                {
                    getWater.start();
                    WaterAmount = WaterAmount + 20;
                    WaterValue.value = WaterAmount;
                }
            }
        }
        else
        {
            WaterLevel.enabled = false;
        }
    }

    void Movement()
    {
        if (Input.GetKey(Forward))
        {
            move = transform.forward * 1f;
            controller.Move(move * speed * Time.deltaTime);
            FaceForward();
        }

        if (Input.GetKey(Left))
        {
            move = transform.right * -1f;
            controller.Move(move * speed * Time.deltaTime);
            FaceLeft();
        }

        if (Input.GetKey(Back))
        {
            move = transform.forward * -1f;
            controller.Move(move * speed * Time.deltaTime);
            FaceBackward();
        }

        if (Input.GetKey(Right))
        {
            move = transform.right * 1f;
            controller.Move(move * speed * Time.deltaTime);
            FaceRight();
        }

        //DPAD
        if (thisIsPlayerTwo) {
            //DPAD Player Two
            if (Input.GetAxis("ControllerTwoYAxis") != 0) {
                move = transform.forward * Input.GetAxis("ControllerTwoYAxis");
                controller.Move(move * speed * Time.deltaTime);
                if (Input.GetAxis("ControllerTwoYAxis") > 0) {
                    FaceForward();
                } else {
                    FaceBackward();
                }
            } else {
                if (Input.GetAxis("ControllerTwoXAxis") != 0) {
                    move = transform.right * Input.GetAxis("ControllerTwoXAxis");
                    controller.Move(move * speed * Time.deltaTime);
                    if (Input.GetAxis("ControllerTwoXAxis") > 0) {
                        FaceRight();
                    } else {
                        FaceLeft();
                    }
                }
            }
        } else {
            //DPAD PlayerOne
            if (Input.GetAxis("ControllerOneYAxis") != 0) {
                move = transform.forward * Input.GetAxis("ControllerOneYAxis");
                controller.Move(move * speed * Time.deltaTime);
                if (Input.GetAxis("ControllerOneYAxis") > 0) {
                    FaceForward();
                } else {
                    FaceBackward();
                }
            } else {
                if (Input.GetAxis("ControllerOneXAxis") != 0) {
                    move = transform.right * Input.GetAxis("ControllerOneXAxis");
                    controller.Move(move * speed * Time.deltaTime);
                    if (Input.GetAxis("ControllerOneXAxis") > 0) {
                        FaceRight();
                    } else {
                        FaceLeft();
                    }
                }
            }
        }

        //Joystick PlayerOne
        //if (thisIsPlayerTwo)
        //{
        //    if (Input.GetAxis("ControllerTwoJoyX") != 0)
        //    {
        //        move = transform.right * Input.GetAxis("ControllerTwoJoyX");
        //        controller.Move(move * speed * Time.deltaTime);
        //        if (Input.GetAxis("ControllerTwoJoyX") > 0)
        //        {
        //            FaceRight();
        //        }
        //        else
        //        {
        //            FaceLeft();
        //        }
        //    }
        //    else
        //    {
        //        if (Input.GetAxis("ControllerTwoJoyY") != 0)
        //        {
        //            move = transform.forward * -Input.GetAxis("ControllerTwoJoyY");
        //            controller.Move(move * speed * Time.deltaTime);
        //            if (Input.GetAxis("ControllerTwoJoyY") < 0)
        //            {
        //                FaceForward();
        //            }
        //            else
        //            {
        //                FaceBackward();
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    if (Input.GetAxis("ControllerOneJoyX") != 0)
        //    {
        //        move = transform.right * Input.GetAxis("ControllerOneJoyX");
        //        controller.Move(move * speed * Time.deltaTime);
        //        if (Input.GetAxis("ControllerOneJoyX") > 0)
        //        {
        //            FaceRight();
        //        }
        //        else
        //        {
        //            FaceLeft();
        //        }
        //    }
        //    if (Input.GetAxis("ControllerOneJoyY") != 0)
        //    {
        //        move = transform.forward * -Input.GetAxis("ControllerOneJoyY");
        //        controller.Move(move * speed * Time.deltaTime);
        //        if (Input.GetAxis("ControllerOneJoyY") < 0)
        //        {
        //            FaceForward();
        //        }
        //        else
        //        {
        //            FaceBackward();
        //        }
        //    }
        //}

        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        //Prevent the player from glitching up
        transform.position = new Vector3(transform.position.x, 2.079989f, transform.position.z);
    }

    void FaceForward()
    {
        if (ghostObject != null) {
            if (ghostObject.name == "Opa")
            {
                ghostObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                ghostObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    void FaceBackward()
    {
        if (ghostObject != null) {
            if (ghostObject.name == "Opa")
            {
                ghostObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                ghostObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void FaceRight()
    {
        if (ghostObject != null) {
            if (ghostObject.name == "Opa")
            {
                ghostObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                ghostObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }

    void FaceLeft()
    {
        if (ghostObject != null) {
            if (ghostObject.name == "Opa")
            {
                ghostObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                ghostObject.transform.rotation = Quaternion.Euler(0, -90, -0);
            }
        }
    }

    //Maakt het mogelijk om rigidbody's te pushen als een charactercontroller
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }

    void CheckIfPlantIsBeforeYou()
    {
        if (Physics.Raycast(raycastOrigin.transform.position, ghostObject.transform.forward, out hit, 2))
        {
            if (hit.collider.tag == "Plant")
            {
                defaultModel.SetActive(false);
                pushingModel.SetActive(true);
            }
        }
        else
        {
            defaultModel.SetActive(true);
            pushingModel.SetActive(false);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    Debug.Log("collision");
    //    if (collision.gameObject.tag == "Plant")
    //    {
    //        defaultModel.SetActive(false);
    //        pushingModel.SetActive(true);
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Plant")
    //    {
    //        defaultModel.SetActive(true);
    //        pushingModel.SetActive(false);
    //    }
    //}

}