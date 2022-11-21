using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Audio : MonoBehaviour
{
    public enum EngineAudioOptions
    {
        Simple,
        FourChannel
    }
    public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;
    public AudioClip lowAccelClip;
    public AudioClip lowDecelClip;
    public AudioClip highAccelClip;
    public AudioClip highDecellClip;
    public float pitchMultiplier = 1f;
    public float lowPitchMin = 1f;
    public float lowPitchMax = 6f;
    public float highPitchMultiplier = 0.2f;
    public float maxRolloffDistance = 500;
    public float dopplerLevel = 1;
    public bool useDoppler = true;

    private AudioSource m_LowAccel;
    private AudioSource m_LowDecel;
    private AudioSource m_HighAccel;
    private AudioSource m_HighDecel;
    private bool m_StartedSound;

    public controller m_CarController;
    public inputManager InputManager;

    private void StartSound()
    {
        m_HighAccel = SetUpEngineAudioSource(highAccelClip);

        if (engineSoundStyle == EngineAudioOptions.FourChannel)
        {
            m_LowAccel = SetUpEngineAudioSource(lowAccelClip);
            m_LowDecel = SetUpEngineAudioSource(lowDecelClip);
            m_HighDecel = SetUpEngineAudioSource(highDecellClip);
        }
        m_StartedSound = true;
    }



    private void StopSound()
    {
        foreach (var source in GetComponents<AudioSource>())
        {
            Destroy(source);
        }
        m_StartedSound = false;
    }

    private void FixedUpdate()
    {
        // get the distance to main camera
        float camDist = (Camera.main.transform.position - transform.position).sqrMagnitude;

        // stop sound if the object is beyond the maximum roll off distance
        if (m_StartedSound && camDist > maxRolloffDistance * maxRolloffDistance)
        {
            StopSound();
        }

        // start the sound if not playing and it is nearer than the maximum distance
        if (!m_StartedSound && camDist < maxRolloffDistance * maxRolloffDistance)
        {
            StartSound();
        }

        if (m_StartedSound)
        {
            // The pitch is interpolated between the min and max values, according to the car's revs.
            float pitch = ULerp(lowPitchMin, lowPitchMax, m_CarController.engineRPM / m_CarController.motorTorque);

            // clamp to minimum pitch (note, not clamped to max for high revs while burning out)
            pitch = Mathf.Min(lowPitchMax, pitch);

            if (engineSoundStyle == EngineAudioOptions.Simple)
            {
                // for 1 channel engine sound, it's oh so simple:
                m_HighAccel.pitch = pitch * pitchMultiplier * highPitchMultiplier;
                m_HighAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_HighAccel.volume = 1;
            }
            else
            {
                // for 4 channel engine sound, it's a little more complex:

                // adjust the pitches based on the multipliers
                m_LowAccel.pitch = pitch * pitchMultiplier;
                m_LowDecel.pitch = pitch * pitchMultiplier;
                m_HighAccel.pitch = pitch * highPitchMultiplier * pitchMultiplier;
                m_HighDecel.pitch = pitch * highPitchMultiplier * pitchMultiplier;
                float accFade = 0;
                // get values for fading the sounds based on the acceleration

                accFade = Mathf.Abs((InputManager.vertical > 0 ) ? InputManager.vertical : 0);

                float decFade = 1 - accFade;

                // get the high fade value based on the cars revs
                float highFade = Mathf.InverseLerp(0.2f, 0.8f, m_CarController.engineRPM / 10000);
                float lowFade = 1 - highFade;

                // adjust the values to be more realistic
                highFade = 1 - ((1 - highFade) * (1 - highFade));
                lowFade = 1 - ((1 - lowFade) * (1 - lowFade));
                accFade = 1 - ((1 - accFade) * (1 - accFade));
                decFade = 1 - ((1 - decFade) * (1 - decFade));

                // adjust the source volumes based on the fade values
                m_LowAccel.volume = lowFade * accFade;
                m_LowDecel.volume = lowFade * decFade;
                m_HighAccel.volume = highFade * accFade;
                m_HighDecel.volume = highFade * decFade;

                // adjust the doppler levels
                m_HighAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_LowAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_HighDecel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_LowDecel.dopplerLevel = useDoppler ? dopplerLevel : 0;
            }
        }
    }


    // sets up and adds new audio source to the gane object
    private AudioSource SetUpEngineAudioSource(AudioClip clip)
    {
        // create the new audio source component on the game object and set up its properties
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 0;
        source.spatialBlend = 1;
        source.loop = true;

        // start the clip from a random point
        source.time = Random.Range(0f, clip.length);
        source.Play();
        source.minDistance = 5;
        source.maxDistance = maxRolloffDistance;
        source.dopplerLevel = 0;
        return source;
    }


    // unclamped versions of Lerp and Inverse Lerp, to allow value to exceed the from-to range
    private static float ULerp(float from, float to, float value)
    {
        return (1.0f - value) * from + value * to;
    }
}
