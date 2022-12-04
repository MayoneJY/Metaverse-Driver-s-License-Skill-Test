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
    private int a = 220;
    private int b = 120;
    private int c;
    private int d = 60;

    private void Start()
    {
        c = (int) ((a + b) / 2);
    }

    private GEAR_MODE GetGearMode(float angle)
    {
        GEAR_MODE result = GEAR_MODE.NEUTRAL;

        var intAngle = Mathf.RoundToInt(angle);

        if (intAngle < c)
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
                return b;
            default:
                return a;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            var vector = transform.position - other.transform.position;
            var angle = Vector3.Angle(Target.forward, vector);

            var gearMode = GetGearMode(angle);
            Root.localRotation = Quaternion.AngleAxis(GetGearStickAngle(gearMode) -d, Target.up);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            var vector = transform.position - other.transform.position;
            var angle = Vector3.Angle(Target.forward, vector);

            if (angle > a)
            {
                angle = a;
            }
            else if (angle < b)
            {
                angle = b;
            }
            
            Root.localRotation = Quaternion.AngleAxis(angle - d, Target.up);
        }
    }
}
