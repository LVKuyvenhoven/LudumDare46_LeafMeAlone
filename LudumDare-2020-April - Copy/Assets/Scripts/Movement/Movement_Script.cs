using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    public CharacterController controller;
    public GameObject ghostObject;
    public float speed = 12f;
    float gravity = -9.81f;

    Vector3 velocity;
    Vector3 move;

    public KeyCode Forward;
    public KeyCode Back;

    public float pushPower = -2000f;

    public KeyCode Right;
    public KeyCode Left;

    [Header("Set Playstation Controller")]
    public bool thisIsPlayerTwo;

    void Update()
    {
        Movement();
        if(this.gameObject.name == "Player1")
        {
            PlantScriptjuh.posP1 = transform.position;
        }
        else
        {
            PlantScriptjuh.posP2 = transform.position;
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
        if (thisIsPlayerTwo)
        {
            //Joystick PlayerTwo
            if (Input.GetAxis("ControllerTwoJoyX") != 0)
            {
                move = transform.right * Input.GetAxis("ControllerTwoJoyX");
                controller.Move(move * speed * Time.deltaTime);
                if (Input.GetAxis("ControllerTwoJoyX") > 0)
                {
                    FaceRight();
                }
                else
                {
                    FaceLeft();
                }
            }
            else
            {
                if (Input.GetAxis("ControllerTwoJoyY") != 0)
                {
                    move = transform.forward * -Input.GetAxis("ControllerTwoJoyY");
                    controller.Move(move * speed * Time.deltaTime);
                    if (Input.GetAxis("ControllerTwoJoyY") < 0)
                    {
                        FaceForward();
                    }
                    else
                    {
                        FaceBackward();
                    }
                }
            }
        }
        else
        {
            if (Input.GetAxis("ControllerOneJoyX") != 0)
            {
                move = transform.right * Input.GetAxis("ControllerOneJoyX");
                controller.Move(move * speed * Time.deltaTime);
                if (Input.GetAxis("ControllerOneJoyX") > 0)
                {
                    FaceRight();
                }
                else
                {
                    FaceLeft();
                }
            }
            if (Input.GetAxis("ControllerOneJoyY") != 0)
            {
                move = transform.forward * -Input.GetAxis("ControllerOneJoyY");
                controller.Move(move * speed * Time.deltaTime);
                if (Input.GetAxis("ControllerOneJoyY") < 0)
                {
                    FaceForward();
                }
                else
                {
                    FaceBackward();
                }
            }
        }

        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
    }

    void FaceForward()
    {
        if (ghostObject != null) {
            ghostObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
    }

    void FaceBackward()
    {
        if (ghostObject != null) {
            ghostObject.transform.rotation = Quaternion.Euler(-90, 0, 180);
        }
    }

    void FaceRight()
    {
        if (ghostObject != null) {
            ghostObject.transform.rotation = Quaternion.Euler(-90, 0, 90);
        }
    }

    void FaceLeft()
    {
        if (ghostObject != null) {
            ghostObject.transform.rotation = Quaternion.Euler(-90, 0, -90);
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
}
