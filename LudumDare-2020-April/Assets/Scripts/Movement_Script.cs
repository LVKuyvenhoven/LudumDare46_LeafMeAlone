using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{

    int Speed = 24;
    public KeyCode Forward;
    public KeyCode Backward;

    public KeyCode Left;
    public KeyCode Right;
    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(Left))
            rb.AddForce(Vector3.left * Speed);
        if (Input.GetKey(Right))
            rb.AddForce(Vector3.right * Speed);

        if (Input.GetKey(Forward))
            rb.AddForce(Vector3.forward * Speed);
        if (Input.GetKey(Backward))
            rb.AddForce(Vector3.back * Speed);
    }
}
