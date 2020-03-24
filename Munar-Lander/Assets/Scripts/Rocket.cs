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

    [SerializeField] TextMesh xSpeed;
    [SerializeField] TextMesh ySpeed;
    [SerializeField] TextMesh totalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        xSpeed.text = "";
        ySpeed.text = "";
        totalSpeed.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("You may live... For now");
                break;
            case "Finish":
                print("Yeah, I know, you won.");
                break;

            default:
                print("Die mf!");
                break;
        }
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
