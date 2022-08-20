using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform_LOD0;
    [SerializeField] private Transform frontRightWheeTransform_LOD0;
    [SerializeField] private Transform rearLeftWheelTransform_LOD0;
    [SerializeField] private Transform rearRightWheelTransform_LOD0;
    [SerializeField] private Transform frontLeftWheelTransform_LOD1;
    [SerializeField] private Transform frontRightWheeTransform_LOD1;
    [SerializeField] private Transform rearLeftWheelTransform_LOD1;
    [SerializeField] private Transform rearRightWheelTransform_LOD1;
    [SerializeField] private Transform frontLeftWheelTransform_LOD2;
    [SerializeField] private Transform frontRightWheeTransform_LOD2;
    [SerializeField] private Transform rearLeftWheelTransform_LOD2;
    [SerializeField] private Transform rearRightWheelTransform_LOD2;
    [SerializeField] private Transform frontLeftWheelTransform_LOD3;
    [SerializeField] private Transform frontRightWheeTransform_LOD3;
    [SerializeField] private Transform rearLeftWheelTransform_LOD3;
    [SerializeField] private Transform rearRightWheelTransform_LOD3;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {

        if (Joystick.all[0].stick.x.ReadValue() == -1 || Joystick.all[0].stick.x.ReadValue() == 1)
            horizontalInput = 0;
        if (Joystick.all[0].stick.x.ReadValue() < 0)
            horizontalInput = 1 - Joystick.all[0].stick.x.ReadValue() * (-1);
        //horizontalInput = (1 - Joystick.all[0].stick.x.ReadValue()) * (-1);
        if (Joystick.all[0].stick.x.ReadValue() > 0)
            horizontalInput = (1 - Joystick.all[0].stick.x.ReadValue()) * (-1);
        //horizontalInput = Input.GetAxis(HORIZONTAL);
        //verticalInput = Input.GetAxis(VERTICAL);
        //isBreaking = Input.GetKey(KeyCode.Space);
        Debug.Log(horizontalInput);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform_LOD0);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform_LOD0);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform_LOD0);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform_LOD0);
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform_LOD1);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform_LOD1);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform_LOD1);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform_LOD1);
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform_LOD2);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform_LOD2);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform_LOD2);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform_LOD2);
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform_LOD3);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform_LOD3);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform_LOD3);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform_LOD3);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
