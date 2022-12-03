using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamCollision : MonoBehaviour
{
    public int testNumber = 0;
    public int testNumber2 = 0;
    private Exam EM;

    // Start is called before the first frame update
    void Start()
    {
        EM = GameObject.Find("CivilianVehicle05").gameObject.GetComponent<Exam>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "BodyStart") {
            if(testNumber == 3 && testNumber2 == 2){
                EM._boolTrafficLightCheck = true;
            }
            else{
                EM.collisionBodyStart = true;
                EM.setExamNumber(testNumber, testNumber2);
            }
        }
        if(other.gameObject.name == "Body") {
            if(testNumber == 3 && testNumber2 == 2){
                EM._boolTrafficLightCheck = true;
            }
            else{
                EM.collisionBodyCenter = true;
            }
        }
        if(other.gameObject.name == "BodyEnd") {
            if(testNumber == 3 && testNumber2 == 2){
                EM._boolTrafficLightCheck = true;
            }
            else{
                EM.collisionBodyEnd = true;
                EM.setExamNumber(testNumber, testNumber2);
            }
        }
        if(other.gameObject.name == "WheelEnd") {
            if(testNumber == 3 && testNumber2 == 2){
                EM._boolTrafficLightCheck = true;
            }
            else{
                EM.collisionWheelEnd = true;
            }
        }
        
            
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "BodyStart") {
            if(testNumber == 3 && testNumber2 == 2){
                EM._boolTrafficLightCheck = false;
            }
            else{
                EM.collisionBodyStart = false;
                EM.setExamNumber(testNumber, testNumber2);
            }
        }
        if(other.gameObject.name == "Body") {
            if(testNumber == 3 && testNumber2 == 2){
                EM._boolTrafficLightCheck = false;
            }
            else{
                EM.collisionBodyCenter = false;
            }
        }
        if(other.gameObject.name == "BodyEnd") {
            if(testNumber == 3 && testNumber2 == 2){
                EM._boolTrafficLightCheck = false;
            }
            else{
                EM.collisionBodyEnd = false;
                EM.setExamNumber(testNumber, testNumber2);
            }
        }
        if(other.gameObject.name == "WheelEnd") {
            if(testNumber == 3 && testNumber2 == 2){
                EM._boolTrafficLightCheck = false;
            }
            else{
                EM.collisionWheelEnd = false;
            }
        }
        
    }
}
