using System;
using UnityEngine.SceneManagement;
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
    [SerializeField] TextMesh headingIndicator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        xSpeed.text = "";
        ySpeed.text = "";
        totalSpeed.text = "";
        headingIndicator.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
        StatsUpdate();
    }

    private void StatsUpdate()
    {
        Vector3 speed = rigidBody.GetRelativePointVelocity(rigidBody.centerOfMass);
        xSpeed.text = Math.Round(speed.x, 2).ToString();
        ySpeed.text = Math.Round(speed.y, 2).ToString();
        totalSpeed.text = Math.Round(speed.magnitude, 2).ToString();
        headingIndicator.text = Math.Round(360-gameObject.transform.rotation.eulerAngles.z, 2).ToString() + "°";
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
                SceneManager.LoadScene(1);
                break;

            default:
                print("Die mf!");
                SceneManager.LoadScene(0);
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
