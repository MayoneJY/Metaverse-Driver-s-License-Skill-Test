using System.Collections;
using UnityEngine;

public class GearControl : MonoBehaviour
{
    //private string[] m_GearStates = { "Parking", "Reverse", "Nature", "Driver" };
    public int m_GearState_Now = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            setGearLocationControl(0); // Parking

        if (Input.GetKeyDown(KeyCode.R))
            setGearLocationControl(1); // Reverse

        if (Input.GetKeyDown(KeyCode.N))
            setGearLocationControl(2); // Nature

        if (Input.GetKeyDown(KeyCode.D))
            setGearLocationControl(3); // Drive
    }

    public void setGearLocationControl(int gear) 
    {
        m_GearState_Now = gear;
    }

}
