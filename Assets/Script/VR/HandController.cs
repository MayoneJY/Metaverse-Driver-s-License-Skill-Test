using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandController : MonoBehaviour
{
    public enum GEAR_MODE
    {
        PARK,
        REVERSE,
        NEUTRAL,
        DRIVE,
        MAX
    }

    public Transform topOfLever;

    [SerializeField] private float forwardBackwardTilt = 0;
    [SerializeField] private float sideToSideTilt = 0;

    void Update()
    {
        forwardBackwardTilt = topOfLever.rotation.eulerAngles.x;
        if(forwardBackwardTilt < 355 && forwardBackwardTilt > 290){
            forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);
        }
    }

    private GEAR_MODE GetGearMode(float angle)
    {
        GEAR_MODE result = GEAR_MODE.DRIVE;

        var intAngle = Mathf.RoundToInt(angle);

        if (intAngle < 250)
        {
            result = GEAR_MODE.PARK;
        }
        else if (intAngle < 280 && intAngle >= 250)
        {
            result = GEAR_MODE.REVERSE;
        }
        else if (intAngle < 310 && intAngle >= 280)
        {
            result = GEAR_MODE.NEUTRAL;
        }
        else 
        {
            result = GEAR_MODE.DRIVE;
        }

        return result;
    }

    private float GetGearStickAngle(GEAR_MODE gearMode)
    {
        switch (gearMode)
        {
            case GEAR_MODE.PARK:
                return 230;
            case GEAR_MODE.REVERSE:
                return 260;
            case GEAR_MODE.NEUTRAL:
                return 290;
            default:
                return 320;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            var vector = other.transform.position - transform.position;
            var angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg + 180;

            var gearMode = GetGearMode(angle);
            //transform.rotation.Set(GetGearStickAngle(gearMode), 0, 0, 0);
             transform.rotation = Quaternion.Euler(GetGearStickAngle(gearMode), -90, 0);
       }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            var vector = other.transform.position - transform.position;
            var angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg + 180;

            if (angle > 320)
            {
                angle = 320;
            }
            else if (angle < 230)
            {
                angle = 230;
            }

            transform.rotation = Quaternion.Euler(angle, -90, 0);
            //transform.LookAt(other.transform.position, transform.up);
        }
    }

}
