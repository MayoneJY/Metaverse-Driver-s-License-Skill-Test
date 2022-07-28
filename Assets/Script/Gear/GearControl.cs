using System.Collections;
using UnityEngine;

public class GearControl : MonoBehaviour
{

    public GameObject Gear;

    private bool ParkingLocation = false;
    private bool ReturnLocation = false;
    private bool NatureLocation = false;
    private bool DriveLocation = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GearLocationControl("Parking");
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GearLocationControl("Return");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            GearLocationControl("Nature");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GearLocationControl("Drive");
        }
    }

    private void CarMove()
    {
        if(ParkingLocation == true)
        {
           
        }

        if (ReturnLocation == true)
        {

        }

        if (NatureLocation == true)
        {

        }

        if (DriveLocation == true)
        {

        }
    }

    private void GearLocationControl(string gear) 
    { 
        if(gear == "Parking")
        {
            ParkingLocation = true;
            ReturnLocation = false;
            NatureLocation = false;
            DriveLocation = false;
        }

        if (gear == "Return")
        {
            ReturnLocation = true;
            ParkingLocation = false;
            NatureLocation = false;
            DriveLocation = false;
        }

        if (gear == "Nature")
        {
            NatureLocation = true;
            ReturnLocation = false;
            ParkingLocation = false;
            DriveLocation = false;
        }

        if (gear == "Drive")
        {
            DriveLocation = true;
            ReturnLocation = false;
            NatureLocation = false;
            ParkingLocation = false;
        }
    }


}
