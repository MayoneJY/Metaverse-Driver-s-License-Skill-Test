using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBreak : MonoBehaviour
{
    public Light Light;
    public Light Light2;
    public Light Light3;


    public float MinTime;
    public float MaxTime;
    public float Timer;


    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        Lighton();
    }

    void Lighton()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Light.enabled = !Light.enabled;
            Light2.enabled = !Light2.enabled;
            Light3.enabled = !Light3.enabled;

            Timer = Random.Range(MinTime, MaxTime);
        }
    }
}