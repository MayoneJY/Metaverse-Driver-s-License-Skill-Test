using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TurnSignal : MonoBehaviour
{
    public Material m_Material_On;
    public Material m_Material_Off;
    private Renderer m_Renderer;
    private float timer;
    private int waitingTime;
    private bool lightBool = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 1;
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            //Action
            timer = 0;
            if (lightBool)
            {
                m_Renderer.material = m_Material_Off;
                Debug.Log("Off");
                lightBool = !lightBool;
            }
            else
            {
                m_Renderer.material = m_Material_On;
                Debug.Log("On");
                lightBool = !lightBool;
            }
        }
    }
}
