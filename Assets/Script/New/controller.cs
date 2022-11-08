using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    internal enum driveType{
        frontWheelDrive,
        rearWheelDrive,
        allWheelDrive
    }
    
    [SerializeField] private driveType drive;

    public float totalPower;
    public AnimationCurve enginePower;

    public inputManager IM;
    //public GameObject wheelMeshs,wheelColliders;
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[16];
    private GameObject centerOfMass;
    private Rigidbody rigidbody;

    public float wheelsRPM;
    public float engineRPM;
    public float[] gears;
    public int gearNum = 0;
    public float smoothTime = 0.01f;

    public float KPH;
    public float brakePower = 3000;
    public float radius = 6;
    public float downForceValue = 50;
    public int motorTorque = 1500;
    public float steeringMax = 4;

    public float[] slip = new float[4];

    
    [SerializeField] private Transform m_StearingWheel;

    // Start is called before the first frame update
    void Start()
    {
        getObjects();
    }

    private void FixedUpdate(){
        addDownForce();
        animateWheels();
        steerVehicle();
        //getFriction();
        calculateEnginePower();
        shifter();
        HandleRotation();
    }

    private void calculateEnginePower()
    {
        wheelRPM();
        
        totalPower = enginePower.Evaluate(engineRPM) * (gears[gearNum]) * IM.vertical;
        float velocity = 0.0f;
        engineRPM = Mathf.SmoothDamp(engineRPM, 1000 + (Mathf.Abs(wheelsRPM) * 3.6f * (gears[gearNum])), ref velocity, smoothTime);
        if(GearControl.m_GearState_Now == 0){
            engineRPM = 0.0f;
        }
        moveVehicle();
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

    private void shifter(){
        if(Input.GetKeyDown(KeyCode.E)){
            gearNum++;
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            gearNum--;
        }
    }

    private void moveVehicle(){

        if(drive == driveType.allWheelDrive){
            for(int i = 0; i < wheels.Length; i++){
                wheels[i].motorTorque = totalPower / 4;
            }
        }
        else if(drive == driveType.rearWheelDrive){
            for(int i = 0; i < wheels.Length - 2; i++){
                wheels[i].motorTorque = totalPower / 2;
            }
        }
        else{
            for(int i = 2; i < wheels.Length; i++){
                wheels[i].motorTorque = totalPower / 2;
            }
        }
        KPH = rigidbody.velocity.magnitude * 3.6f;

        for(int i = 0; i < wheels.Length; i++){
            wheels[i].brakeTorque = brakePower * IM.handbrake;
        }
        
    }


    private void HandleRotation()
    {
        //m_StearingWheel.rotation = Quaternion.Euler(new Vector3(15, 0, horizontalInput * -1 * 450));
        m_StearingWheel.eulerAngles = new Vector3(15, 0, IM.horizontal * -1 * 450);
    }

    private void steerVehicle(){
        if(IM.horizontal > 0){
            wheels[3].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
            wheels[2].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * IM.horizontal;
        }
        else if(IM.horizontal < 0){
            wheels[3].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * IM.horizontal;
            wheels[2].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
        }
        else{
            wheels[3].steerAngle = 0;
            wheels[2].steerAngle = 0;
        }
    }

    void animateWheels(){
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for(int i = 0; i < 4; i++){
            for(int j = 0; j < 4; j++){
                wheels[j].GetWorldPose(out wheelPosition, out wheelRotation);
                wheelMesh[(i*4) + j].transform.position = wheelPosition;
                wheelMesh[(i*4) + j].transform.rotation = wheelRotation;

            }
            
        }
    }
    private void getObjects(){
        IM = GetComponent<inputManager>();
        rigidbody = GetComponent<Rigidbody>();

        centerOfMass = GameObject.Find("mass");
        rigidbody.centerOfMass = centerOfMass.transform.position;
    }

    private void addDownForce(){
        rigidbody.AddForce(-transform.up * downForceValue * rigidbody.velocity.magnitude);
    }

    private void getFriction(){
        for(int i = 0; i < wheels.Length; i++){
            WheelHit wheelHit;
            wheels[i].GetGroundHit(out wheelHit);

            slip[i] = wheelHit.forwardSlip;
        }
    }
}
