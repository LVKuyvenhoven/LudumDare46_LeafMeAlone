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
            rb.(Vector3.left * Speed);
        if (Input.GetKey(Right))
            rb.AddRelativeForce(Vector3.right * Speed);

        if (Input.GetKey(Forward))
            rb.AddRelativeForce(Vector3.forward * Speed);
        if (Input.GetKey(Backward))
            rb.AddRelativeForce(Vector3.back * Speed);
    }
}
