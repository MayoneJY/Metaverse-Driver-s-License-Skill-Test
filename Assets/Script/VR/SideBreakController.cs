using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SideBreakController : MonoBehaviour
{
    public enum GEAR_MODE
    {
        PARK,
        NEUTRAL,
        MAX
    }

    public Transform Root;
    [SerializeField] private Transform Target;

    private GEAR_MODE GetGearMode(float angle)
    {
        GEAR_MODE result = GEAR_MODE.NEUTRAL;

        var intAngle = Mathf.RoundToInt(angle);

        if (intAngle < 80)
        {
            result = GEAR_MODE.PARK;
        }
        else 
        {
            result = GEAR_MODE.NEUTRAL;
        }

        return result;
    }

    private float GetGearStickAngle(GEAR_MODE gearMode)
    {
        switch (gearMode)
        {
            case GEAR_MODE.PARK:
                return 40;
            default:
                return 140;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            var vector = transform.position - other.transform.position;
            var angle = Vector3.Angle(Target.forward, vector);

            var gearMode = GetGearMode(angle);
            Root.localRotation = Quaternion.AngleAxis(GetGearStickAngle(gearMode) -90, Target.up);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            var vector = transform.position - other.transform.position;
            var angle = Vector3.Angle(Target.forward, vector);

            if (angle > 140)
            {
                angle = 140;
            }
            else if (angle < 40)
            {
                angle = 40;
            }
            
            Root.localRotation = Quaternion.AngleAxis(angle - 90, Target.up);
        }
    }
}
