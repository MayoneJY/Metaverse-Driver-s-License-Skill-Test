using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TurnSignal : MonoBehaviour
{
    public Material m_Material_On;
    public Material m_Material_Off;
    public GameObject m_GameObject_Left;
    public GameObject m_GameObject_Right;
    private Renderer m_Renderer_Left;
    private Renderer m_Renderer_Right;
    private float timer;
    private int waitingTime;
    private bool leftTurnSignal = false;
    private bool leftLightBool = false;
    private bool rightTurnSignal = false;
    private bool rightLightBool = false;
    private bool doubleTurnSignal = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 1;
        m_Renderer_Left = m_GameObject_Left.GetComponent<Renderer>();
        m_Renderer_Right = m_GameObject_Right.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            turnSignalOnOff("LEFT");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            turnSignalOnOff("RIGHT");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            turnSignalOnOff("DOUBLE");
        }
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            timer = 0;
            if (leftTurnSignal)
            {
                turnSignal(m_Renderer_Left, ref leftLightBool);
            }
            if (rightTurnSignal)
            {
                turnSignal(m_Renderer_Right, ref rightLightBool);
            }
            if (doubleTurnSignal)
            {
                turnSignal(m_Renderer_Right, ref rightLightBool);
                turnSignal(m_Renderer_Left, ref leftLightBool);
            }
        }
        

    }

    private void turnSignal(Renderer trunSignal, ref bool lightBool)
    {

        if (lightBool)
        {
            trunSignal.material = m_Material_Off;
            lightBool = !lightBool;
            Debug.Log("Off");
        }
        else
        {
            trunSignal.material = m_Material_On;
            lightBool = !lightBool;
            Debug.Log("On");
        }
    }

    private void turnSignalOnOff(string signal)
    {
        //한쪽 방향지시등이 켜져있을 때 다른 방향지시등이 꺼짐
        //비상등 켜질 때 우선 양쪽 방향지시등을 끔
        if(signal == "LEFT") leftTurnSignal = !leftTurnSignal;
        else leftTurnSignal = false;
        leftLightBool = false;
        if (signal == "RIGHT") rightTurnSignal = !rightTurnSignal;
        else rightTurnSignal = false;
        rightLightBool = false;
        if (signal == "DOUBLE") doubleTurnSignal = !doubleTurnSignal;
        else doubleTurnSignal = false;
        m_Renderer_Left.material = m_Material_Off;
        m_Renderer_Right.material = m_Material_Off;
    }
}
