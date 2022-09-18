using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class CarController : MonoBehaviourPunCallbacks
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private float breakingInput;

    private Vector3 currFrontLeftWheelRotation;
    private Vector3 currFrontRightWheelRotation;
    private Vector3 currRearLeftWheelRotation;
    private Vector3 currRearRightWheelRotation;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform[] frontLeftWheelTransform;
    [SerializeField] private Transform[] frontRightWheelTransform;
    [SerializeField] private Transform[] rearLeftWheelTransform;
    [SerializeField] private Transform[] rearRightWheelTransform;
    [SerializeField] private Transform m_StearingWheel;
    [SerializeField] private GameObject m_Camera;

    private void Start()
    {
        if(Controller.isController){
            if(Controller.isController){
                if (Input.GetAxis("axel") < 0)
                    verticalInput = 1 - (Input.GetAxis("axel") * (-1));
                else if (Input.GetAxis("axel") == 0)
                    verticalInput = 1;
                else if (Input.GetAxis("axel") > 0)
                    verticalInput = 1 + Input.GetAxis("axel");
            }
        }
        if(!photonView.IsMine){
            m_Camera.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(photonView.IsMine){
            GetInput();
        }
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
            //isBreaking = Input.GetKey(KeyCode.Space);
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
        //Debug.Log("axel : " + verticalInput + ", break : " + breakingInput + ", wheel : " + horizontalInput);
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
        for(int i = 0; i < frontLeftWheelTransform.Length; i++){
            if(photonView.IsMine){
                UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform[i]);
                UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform[i]);
                UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform[i]);
                UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform[i]);
            }
            else{
                frontLeftWheelTransform[i].eulerAngles = currFrontRightWheelRotation;
                frontRightWheelTransform[i].eulerAngles = currFrontRightWheelRotation;
                rearRightWheelTransform[i].eulerAngles = currFrontRightWheelRotation;
                rearLeftWheelTransform[i].eulerAngles = currFrontRightWheelRotation;
            }
        }
    }
    
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(frontLeftWheelTransform[0].eulerAngles);
            stream.SendNext(frontRightWheelTransform[0].eulerAngles);
            stream.SendNext(rearRightWheelTransform[0].eulerAngles);
            stream.SendNext(rearLeftWheelTransform[0].eulerAngles);
        }
        else{
            currFrontLeftWheelRotation = (Vector3) stream.ReceiveNext();
            currFrontRightWheelRotation = (Vector3) stream.ReceiveNext();
            currRearLeftWheelRotation = (Vector3) stream.ReceiveNext();
            currRearRightWheelRotation = (Vector3) stream.ReceiveNext();
        }
    }
}
