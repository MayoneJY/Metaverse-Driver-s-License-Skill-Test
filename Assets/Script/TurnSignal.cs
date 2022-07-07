using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TurnSignal : MonoBehaviour
{
    public Material m_Material_On;
    public Material m_Material_Off;
    private Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Renderer.material = m_Material_On;
        Debug.Log("On");
        Thread.Sleep(1000);
        m_Renderer.material = m_Material_Off;
        Debug.Log("Off");
        Thread.Sleep(1000);
    }
}
