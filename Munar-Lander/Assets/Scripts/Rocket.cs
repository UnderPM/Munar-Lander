﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {  }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 3.5f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-Vector3.forward * Time.deltaTime * 3.5f);
            }
        }
    }
}
