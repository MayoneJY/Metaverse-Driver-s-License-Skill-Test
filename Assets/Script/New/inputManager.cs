using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public float handbrake;
    public bool isAxelPress = false;
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
                if(handbrake < 0.4) handbrake = 0;
                else handbrake = (handbrake - 0.4f) * 1.67f;
                if(vertical < 0.4){
                    vertical = 0.15f;
                    isAxelPress = false;
                }
                else{
                    vertical = (vertical - 0.4f) * 1.67f;
                    isAxelPress = true;
                }
                if(handbrake > 1.0f) handbrake = 1.0f;
                if(vertical > 1.0f) vertical = 1.0f;
            }
        }
        else{
            if(gearStatus == 3){
                vertical = Input.GetAxis("Vertical");

                if(vertical < 0.1){
                    isAxelPress = false;
                }
                else{
                    vertical = (vertical - 0.4f) * 1.67f;
                    isAxelPress = true;
                }
            }
            else if(gearStatus == 1){
                vertical = Input.GetAxis("Vertical") * -1;
            }
            horizontal = Input.GetAxis("Horizontal");
            handbrake = Input.GetAxis("Jump");
            //handbrake = (Input.GetAxis("Jump") != 0)? 1 : 0;
        }

        if(gearStatus == 0) handbrake = 1;
    }
}