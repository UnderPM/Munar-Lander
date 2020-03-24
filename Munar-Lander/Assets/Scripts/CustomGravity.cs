using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CustomGravity : MonoBehaviour
{
    [SerializeField] float gravityScale = 1.0f;

    float globalGravity = -9.81f;

    Rigidbody rigidBody;

    private void OnEnable()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }

    private void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rigidBody.AddForce(gravity, ForceMode.Acceleration);
    }
}
