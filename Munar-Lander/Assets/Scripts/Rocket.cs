using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float thrust = 1000f;
    [SerializeField] float rcs = 200f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void Rotate()
    {
        
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) { }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                //rigidBody.freezeRotation = true;
                transform.Rotate(Vector3.forward * Time.deltaTime * rcs);
                //print("A");
                //rigidBody.freezeRotation = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //rigidBody.freezeRotation = true;
                transform.Rotate(-Vector3.forward * Time.deltaTime * rcs);
                //print("D");
                //rigidBody.freezeRotation = false;
            }
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float thrustPerFrame = thrust * Time.deltaTime;
            rigidBody.AddRelativeForce(Vector3.up * thrustPerFrame);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            audioSource.Stop();
        }
    }
}
