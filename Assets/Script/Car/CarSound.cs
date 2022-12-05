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

    private controller _CR;

    private void Start()
    {
        carAudio = GetComponent<AudioSource>();
        carRb = GetComponent<Rigidbody>();
        _CR = GetComponent<controller>();
    }

    private void Update()
    {
        EnginSound();
    }

    public void EnginSound()
    {
        float speed = _CR.KPH / 50.0f + 0.2f;
        curretnSpeed = carRb.velocity.magnitude;
        pitchFromCar = carRb.velocity.magnitude / 50f;

        if (speed < 0.2f)
            speed = 0.2f;
        //0 최소 1 최대


        carAudio.pitch = speed;


        // if (curretnSpeed < minSpeed)
        // {
        //     carAudio.pitch = minPitch;
        // }

        // if(curretnSpeed >minSpeed && curretnSpeed < maxSpeed)
        // {
        //     carAudio.pitch = minPitch + pitchFromCar;
        // }

        // if(curretnSpeed > maxSpeed)
        // {
        //     carAudio.pitch = maxPitch;

        // }
    }

}
