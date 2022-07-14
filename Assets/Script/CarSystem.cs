using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSystem : MonoBehaviour
{
    [SerializeField] private GameObject m_GameObject_RearSideLights = null;
    [SerializeField] private GameObject m_GameObject_BrakeLights = null;
    [SerializeField] private GameObject m_GameObject_DayTimeLight = null;
    [SerializeField] Material m_Material_On = null;
    [SerializeField] Material m_Material_Off = null;

    static public bool m_StartUp_Car = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //시동걸기
        if (Input.GetKeyDown(KeyCode.M))
        {
            m_StartUp_Car = !m_StartUp_Car;

            if (m_StartUp_Car)
            {
                m_GameObject_RearSideLights.GetComponent<Renderer>().material = m_Material_On;
                m_GameObject_DayTimeLight.GetComponent<Renderer>().material = m_Material_On;
            }
            else
            {
                m_GameObject_RearSideLights.GetComponent<Renderer>().material = m_Material_Off;
                m_GameObject_DayTimeLight.GetComponent<Renderer>().material = m_Material_Off;
            }
        }

        //시동걸렸을 때
        if (m_StartUp_Car)
        {
            //브레이크를 밟았을 때
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.S))
            {
                m_GameObject_BrakeLights.GetComponent<Renderer>().material = m_Material_On;
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.S))
            {
                m_GameObject_BrakeLights.GetComponent<Renderer>().material = m_Material_Off;
            }
        }
    }

    static public bool get_m_StartUp_Car()
    {
        return m_StartUp_Car;
    }
}
