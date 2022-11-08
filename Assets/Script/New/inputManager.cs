using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public float handbrake;

    private int gearStatus = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gearStatus = GearControl.m_GearState_Now;
        if(Controller.isController){
            horizontal = Input.GetAxis("Horizontal");

            if(gearStatus == 1 || gearStatus == 3){
                if (Input.GetAxis("axel") < 0)
                    vertical = 1 - (Input.GetAxis("axel") * (-1));
                else if (Input.GetAxis("axel") == 0)
                    vertical = 1;
                else if (Input.GetAxis("axel") > 0)
                    vertical = 1 + Input.GetAxis("axel");

                vertical = vertical / 2;

                handbrake = Input.GetAxis("break");
                if(handbrake < 0.1) handbrake = 0;
                if(vertical < 0.1) vertical = 0;
            }
        }
        else{
            if(gearStatus == 1 || gearStatus == 3){
                vertical = Input.GetAxis("Vertical");
            }
            horizontal = Input.GetAxis("Horizontal");
            handbrake = (Input.GetAxis("Jump") != 0)? 1 : 0;
        }

        if(gearStatus == 0) handbrake = 1;
    }
}
