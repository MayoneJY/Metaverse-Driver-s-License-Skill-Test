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

    [SerializeField] private GearControl _GC;
    public Transform Root;
    [SerializeField] private Transform Target;

    private void Start()
    {
        Root.localRotation = Quaternion.AngleAxis(GetGearStickAngle(GEAR_MODE.PARK) - 90, Target.up);

    }
    private GEAR_MODE GetGearMode(float angle)
    {
        GEAR_MODE result = GEAR_MODE.DRIVE;

        var intAngle = Mathf.RoundToInt(angle);

        if (intAngle < 60)
        {
            result = GEAR_MODE.PARK;
            _GC.m_GearState_Now = 0;
            Debug.Log(0);
        }
        else if (intAngle < 80 && intAngle >= 60)
        {
            result = GEAR_MODE.REVERSE;
            _GC.m_GearState_Now = 1;
        }
        else if (intAngle < 110 && intAngle >= 80)
        {
            result = GEAR_MODE.NEUTRAL;
            _GC.m_GearState_Now = 2;
        }
        else 
        {
            result = GEAR_MODE.DRIVE;
            _GC.m_GearState_Now = 3;
        }

        return result;
    }

    private float GetGearStickAngle(GEAR_MODE gearMode)
    {
        switch (gearMode)
        {
            case GEAR_MODE.PARK:
                return 50;
            case GEAR_MODE.REVERSE:
                return 70;
            case GEAR_MODE.NEUTRAL:
                return 100;
            default:
                return 130;
        }
    }

    public void ResetGear()
    {
        var gearMode = GetGearMode(40.0f);
        Root.localRotation = Quaternion.AngleAxis(GetGearStickAngle(gearMode) - 90, Target.up);
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

            if (angle > 130)
            {
                angle = 130;
            }
            else if (angle < 50)
            {
                angle = 50;
            }
            
            Root.localRotation = Quaternion.AngleAxis(angle - 90, Target.up);
        }
    }
}