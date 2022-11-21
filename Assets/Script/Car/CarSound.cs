using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float curretnSpeed;

    private Rigidbody carRb;
    private AudioSource carAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

    private void Start()
    {
        carAudio = GetComponent<AudioSource>();
        carRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        EnginSound();
    }

    public void EnginSound()
    {
        curretnSpeed = carRb.velocity.magnitude;
        pitchFromCar = carRb.velocity.magnitude / 50f;

        if (curretnSpeed < minSpeed)
        {
            carAudio.pitch = minPitch;
        }

        if(curretnSpeed >minSpeed && curretnSpeed < maxSpeed)
        {
            carAudio.pitch = minPitch + pitchFromCar;
        }

        if(curretnSpeed > maxSpeed)
        {
            carAudio.pitch = maxPitch;

        }
    }

}
