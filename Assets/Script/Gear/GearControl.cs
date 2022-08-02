using System.Collections;
using UnityEngine;

public class GearControl : MonoBehaviour
{

    public GameObject Gear;

    private string[] m_GearStates = { "Parking", "Return", "Nature", "Driver" };
    private int m_GearState_Now = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            GearLocationControl(0); // Parking

        if (Input.GetKeyDown(KeyCode.R))
            GearLocationControl(1); // Return

        if (Input.GetKeyDown(KeyCode.N))
            GearLocationControl(2); // Nature

        if (Input.GetKeyDown(KeyCode.D))
            GearLocationControl(3); // Drive
    }

    private void CarMove()
    {

    }

    private void GearLocationControl(int gear) 
    {
        m_GearState_Now = gear;
    }


}
