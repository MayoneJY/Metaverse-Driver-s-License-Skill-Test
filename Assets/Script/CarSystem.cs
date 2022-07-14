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
    }

    static public bool get_m_StartUp_Car()
    {
        return m_StartUp_Car;
    }
}
