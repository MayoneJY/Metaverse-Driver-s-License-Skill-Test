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
        if(Controller.isController){
            if (Joystick.all[0].stick.x.ReadValue() == -1 || Joystick.all[0].stick.x.ReadValue() == 1)
                horizontalInput = 0;
            else if (Joystick.all[0].stick.x.ReadValue() < 0)
                horizontalInput = 1 - Joystick.all[0].stick.x.ReadValue() * (-1);
            else if (Joystick.all[0].stick.x.ReadValue() > 0)
                horizontalInput = (1 - Joystick.all[0].stick.x.ReadValue()) * (-1);


            if (Input.GetAxis("axel") < 0)
                verticalInput = 1 - (Input.GetAxis("axel") * (-1));
            else if (Input.GetAxis("axel") == 0)
                verticalInput = 1;
            else if (Input.GetAxis("axel") > 0)
                verticalInput = 1 + Input.GetAxis("axel");

            verticalInput = verticalInput / 2;

            if (Joystick.all[0].stick.y.ReadValue() * -1 > 0.5)
                breakingInput = 0.5f;
            else
                breakingInput = Joystick.all[0].stick.y.ReadValue() * -1;

            breakingInput *= 2;
        }
        else{
            horizontalInput = Input.GetAxis(HORIZONTAL);
            verticalInput = Input.GetAxis(VERTICAL);
            if(Input.GetKey(KeyCode.Space)){
                breakingInput = 1;
            }
            else{
                breakingInput = 0;
            }
        }
        /*for (int i = 0; i < Joystick.all[0].allControls.Count; i++)
            Debug.Log(Joystick.all[0].allControls[i].name);*/
        //Debug.Log(Input.GetAxis("axel"));
        //Debug.Log(InputSystem.FindControl("/Arduino LLC Arduino Leonardo/rx"));
        //Debug.Log(InputSystem.GetDevice("Arduino LLC Arduino Leonardo").);
        //Debug.Log(Joystick.all[0].hatswitch);
        //Debug.Log(Joystick.all[0].allControls[34].path);
        /*for (int i = 0; i < Joystick.all[0].allControls.Count; i++)
        {
            if (Joystick.all[0].allControls[i].IsPressed())
            {
                Debug.Log(Joystick.all[0].allControls[i].name);
            }
        }*/
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
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        //Debug.Log(currentbreakForce);
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
