using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBreak : MonoBehaviour
{
    public GameObject Light;

    public float nowTime;
    public AudioSource audiosource;
    public bool test;

    private bool audioStart = false;
    void Start()
    {
        test = false;
        
        audiosource.loop = true;
    }

    public void Update()
    {
        
        
        if (test)
        {
            nowTime += Time.deltaTime;
            if (nowTime < 5)
            {
                Light.SetActive(true);
                Debug.Log(Light.name);
                if(audioStart == false)
                {
                    audiosource.Play();
                    audioStart = true;
                }
                

            }
            else
            {
                Light.SetActive(false);
                nowTime = 0;
                test = false;
                audiosource.Stop();
                audioStart = false;
            }
        }
       

    }


}