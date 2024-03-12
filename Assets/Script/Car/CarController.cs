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
    // CarSpped

    private InPutManager IM;
    private Rigidbody rb;
    public float[] slip = new float[4];
    public float thrust;

    public float wheelsRPM;
    public float totalPower;
    public float engineRPM;
    public float[] gears;
    public int gearNum = 0;
    public float smoothTime = 0.01f;
    public float KM;
    public AnimationCurve enginePower;
    //감속
    [SerializeField] private float decSpeed = 20f;

    public WheelCollider[] wheels = new WheelCollider[4];

    //CarSpped

    public int m_GearState_Now = 0;
    
    private void Start()
    {
    
        getObject();
        /* GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1, 0);*/
        if(Controller.isController){
            if (Input.GetAxis("axel") < 0)
                verticalInput = 1 - (Input.GetAxis("axel") * (-1));
            else if (Input.GetAxis("axel") == 0)
                verticalInput = 1;
            else if (Input.GetAxis("axel") > 0)
                verticalInput = 1 + Input.GetAxis("axel");
        }

    }
    
    private void GetInput()
    {
        //GearControl.m_GearState_Now
        //0: Parking
        //1: Return
        //2: Nature
        //3: Drive
        //gearStatus = GearControl.m_GearState_Now;
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
        //Debug.Log("axel : " + verticalInput + ", break : " + breakingInput + ", wheel : " + horizontalInput);
        HandleRotation();
    }

    private void HandleRotation()
    {
        //m_StearingWheel.rotation = Quaternion.Euler(new Vector3(15, 0, horizontalInput * -1 * 450));
        m_StearingWheel.eulerAngles = new Vector3(15, 0, horizontalInput * -1 * 450);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = breakingInput * breakForce;
        //Debug.Log("" + verticalInput * motorForce + ", " + currentbreakForce);
        ApplyBreaking();
    }


    private void getObject()
    {
        IM = GetComponent<InPutManager>();
        rb = GetComponent<Rigidbody>();
        //Debug.Log(currentbreakForce);
        //frontRightWheelCollider.brakeTorque = currentbreakForce;
        //frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            setGearLocationControl(0); // Parking

        if (Input.GetKeyDown(KeyCode.R))
            setGearLocationControl(1); // Reverse

        if (Input.GetKeyDown(KeyCode.N))
            setGearLocationControl(2); // Nature

        if (Input.GetKeyDown(KeyCode.D))
            setGearLocationControl(3); // Drive
    }

    public void setGearLocationControl(int gear)
    {
        m_GearState_Now = gear;
    }

    private void FixedUpdate()
    {
        if (m_GearState_Now == 0)
        {
            if (Input.GetKey(KeyCode.P))
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = 0;
                }
            }

        }
        
        if (m_GearState_Now == 1)
        {
            if (Input.GetKey(KeyCode.R))
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = 0;
                }
            }
                if (Input.GetKey(KeyCode.DownArrow))
            {
                Move();
            }
        }

            if (m_GearState_Now == 2)
            {

            }

            if (m_GearState_Now == 3)
            {
            if (Input.GetKey(KeyCode.D))
            {
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = 0;
                }
            }
            if (Input.GetKey(KeyCode.UpArrow))
                {
                    Move();

                }
            }
            GetInput();
            UpdateWheels();
            HandleMotor();
            HandleSteering();
            calculateEnginePower();
        }

        private void Move()
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = totalPower / 4;
            }

            KM = rb.velocity.magnitude * 3.6f;

        }

        

        private void ApplyBreaking()
        {
            frontRightWheelCollider.brakeTorque = currentbreakForce;
            frontLeftWheelCollider.brakeTorque = currentbreakForce;
            rearLeftWheelCollider.brakeTorque = currentbreakForce;
            rearRightWheelCollider.brakeTorque = currentbreakForce;

            /* if (!Input.GetButton("Vertical"))
             {
                 rearRightWheelCollider.brakeTorque = decSpeed;
                 rearLeftWheelCollider.brakeTorque = decSpeed;
             }
             else
             {
                 rearRightWheelCollider.brakeTorque = 0;
                 rearLeftWheelCollider.brakeTorque = 0;
             }*/

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

        /* private void Friction()
         {
             for(int i=0; i<wheels.Length; i++)
             {
                 WheelHit wheelhit;
                 wheels[i].GetGroundHit(out wheelhit);

                 slip[i] = wheelhit.forwardSlip;
             }
         }*/


        private void calculateEnginePower()
        {
            wheelRPM();

            totalPower = enginePower.Evaluate(engineRPM) * (gears[gearNum]) * IM.vertical;
            float velocity = 0.0f;
            engineRPM = Mathf.SmoothDamp(engineRPM, 1000 + (Mathf.Abs(wheelsRPM) * (gears[gearNum])), ref velocity, smoothTime);

        }
        private void wheelRPM()
        {
            float sum = 0;
            int R = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += wheels[i].rpm;
                R++;
            }
            wheelsRPM = (R != 0) ? sum / R : 0;
        }
    }

