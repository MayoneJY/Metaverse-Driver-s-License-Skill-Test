using System.Collections;
using UnityEngine;

public class GearControl : MonoBehaviour
{
    public GameObject Gear;

    //private string[] m_GearStates = { "Parking", "Return", "Nature", "Driver" };
    public static int m_GearState_Now = 0;]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
            setGearLocationControl(0); // Parking

        if (Input.GetKeyDown(KeyCode.Alpha1))
            setGearLocationControl(1); // Return

        if (Input.GetKeyDown(KeyCode.Alpha2))
            setGearLocationControl(2); // Nature

        if (Input.GetKeyDown(KeyCode.Alpha3))
            setGearLocationControl(3); // Drive
        
    }

    public void setGearLocationControl(int gear) 
    {
        m_GearState_Now = gear;
        Debug.Log(gear);
    }

}
