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
    private float breakingInput;

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
    [SerializeField] private Transform m_StearingWheel;
    private int gearStatus = 0;

    private void Start()
    {
        if(Controller.isController){
            if (Input.GetAxis("axel") < 0)
                verticalInput = 1 - (Input.GetAxis("axel") * (-1));
            else if (Input.GetAxis("axel") == 0)
                verticalInput = 1;
            else if (Input.GetAxis("axel") > 0)
                verticalInput = 1 + Input.GetAxis("axel");
        }

    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {
        //GearControl.m_GearState_Now
        //0: Parking
        //1: Return
        //2: Nature
        //3: Drive
        gearStatus = GearControl.m_GearState_Now;
        if(Controller.isController){
            horizontalInput = Input.GetAxis(HORIZONTAL);

            if(gearStatus == 1 || gearStatus == 3){
                if (Input.GetAxis("axel") < 0)
                    verticalInput = 1 - (Input.GetAxis("axel") * (-1));
                else if (Input.GetAxis("axel") == 0)
                    verticalInput = 1;
                else if (Input.GetAxis("axel") > 0)
                    verticalInput = 1 + Input.GetAxis("axel");

                verticalInput = verticalInput / 2;

                breakingInput = Input.GetAxis("break");
                if(breakingInput < 0.1) breakingInput = 0;
                if(verticalInput < 0.1) verticalInput = 0;
            }
        }
        else{
            horizontalInput = Input.GetAxis(HORIZONTAL);

            if(gearStatus == 1 || gearStatus == 3){
                verticalInput = Input.GetAxis(VERTICAL);
                if(Input.GetKey(KeyCode.Space)){
                    breakingInput = 1;
                }
                else{
                    breakingInput = 0;
                }
            }
        }
        if(gearStatus == 1) verticalInput *= -1;
        
        if(gearStatus == 0) breakingInput = 1;
        Debug.Log("axel : " + verticalInput + ", break : " + breakingInput + ", wheel : " + horizontalInput);
        HandleRotation();
    }

    private void HandleRotation()
    {
        m_StearingWheel.rotation = Quaternion.Euler(new Vector3(15, 0, horizontalInput * -1 * 450));
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = breakingInput * breakForce;
        Debug.Log("" + verticalInput * motorForce + ", " + currentbreakForce);
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        //Debug.Log(currentbreakForce);
        //frontRightWheelCollider.brakeTorque = currentbreakForce;
        //frontLeftWheelCollider.brakeTorque = currentbreakForce;
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
