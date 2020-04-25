using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    float gravity = -9.81f;

    Vector3 velocity;
    Vector3 move;

    public KeyCode Forward;
    public KeyCode Back;

    public float pushPower = -2000f;

    public KeyCode Right;
    public KeyCode Left;


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
        }

        if (Input.GetKey(Left))
        {
            move = transform.right * -1f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(Back))
        {
            move = transform.forward * -1f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(Right))
        {
            move = transform.right * 1f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
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
