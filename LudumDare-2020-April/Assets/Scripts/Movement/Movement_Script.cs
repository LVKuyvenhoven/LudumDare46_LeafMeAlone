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

    public KeyCode Right;
    public KeyCode Left;


    void Update()
    {
        Movement();
    }


    void Movement()
    {
        if (Input.GetKey(Forward))
        {
            move = transform.forward * 0.5f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(Left))
        {
            move = transform.right * -0.5f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(Back))
        {
            move = transform.forward * -0.5f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(Right))
        {
            move = transform.right * 0.5f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
    }
}
