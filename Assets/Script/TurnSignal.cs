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
    public GameObject m_GameObject_Light_Left_Front;
    public GameObject m_GameObject_Light_Left_Rear;
    public GameObject m_GameObject_Light_Right_Front;
    public GameObject m_GameObject_Light_Right_Rear;
    private GameObject[] m_GameObject_Lights_Left;
    private GameObject[] m_GameObject_Lights_Right;
    private Renderer m_Renderer_Left;
    private Renderer m_Renderer_Right;
    private float timer;
    private int waitingTime;
    private bool leftTurnSignal = false;
    private bool leftLightBool = false;
    private bool rightTurnSignal = false;
    private bool rightLightBool = false;
    private bool doubleTurnSignal = false;
    private bool m_StartUp_Car;
    // Start is called before the first frame update
    void Start()
    {
        m_StartUp_Car = CarSystem.get_m_StartUp_Car();
        timer = 0.0f;
        waitingTime = 1;
        m_Renderer_Left = m_GameObject_Left.GetComponent<Renderer>();
        m_Renderer_Right = m_GameObject_Right.GetComponent<Renderer>();
        m_GameObject_Lights_Left = new GameObject[] { m_GameObject_Light_Left_Front, m_GameObject_Light_Left_Rear};
        m_GameObject_Lights_Right = new GameObject[] { m_GameObject_Light_Right_Front, m_GameObject_Light_Right_Rear};
    }

    // Update is called once per frame
    void Update()
    {
        m_StartUp_Car = CarSystem.get_m_StartUp_Car();
        if (m_StartUp_Car)
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
                    turnSignal(m_Renderer_Left, ref leftLightBool, m_GameObject_Lights_Left);
                }
                if (rightTurnSignal)
                {
                    turnSignal(m_Renderer_Right, ref rightLightBool, m_GameObject_Lights_Right);
                }
                if (doubleTurnSignal)
                {
                    turnSignal(m_Renderer_Right, ref rightLightBool, m_GameObject_Lights_Right);
                    turnSignal(m_Renderer_Left, ref leftLightBool, m_GameObject_Lights_Left);
                }
            }
        }
        else
        {
            turnSignalOffAll();
        }
        

    }

    private void turnSignal(Renderer trunSignal, ref bool lightBool, GameObject[] _GameObject_Lights)
    {

        if (lightBool)
        {
            trunSignal.material = m_Material_Off;
            lightBool = !lightBool;
            _GameObject_Lights[0].SetActive(false);
            _GameObject_Lights[1].SetActive(false);
            Debug.Log("Off");
        }
        else
        {
            trunSignal.material = m_Material_On;
            lightBool = !lightBool;
            _GameObject_Lights[0].SetActive(true);
            _GameObject_Lights[1].SetActive(true);
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
        m_GameObject_Light_Left_Front.SetActive(false);
        m_GameObject_Light_Left_Rear.SetActive(false);
        m_GameObject_Light_Right_Front.SetActive(false);
        m_GameObject_Light_Right_Rear.SetActive(false);
        m_Renderer_Left.material = m_Material_Off;
        m_Renderer_Right.material = m_Material_Off;
    }

    private void turnSignalOffAll()
    {
        leftTurnSignal = false;
        leftLightBool = false;
        rightTurnSignal = false;
        rightLightBool = false;
        doubleTurnSignal = false;
        m_GameObject_Light_Left_Front.SetActive(false);
        m_GameObject_Light_Left_Rear.SetActive(false);
        m_GameObject_Light_Right_Front.SetActive(false);
        m_GameObject_Light_Right_Rear.SetActive(false);
        m_Renderer_Left.material = m_Material_Off;
        m_Renderer_Right.material = m_Material_Off;
    }
}
