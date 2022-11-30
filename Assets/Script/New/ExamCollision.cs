using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamCollision : MonoBehaviour
{
    public int testNumber = 0;
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
            EM.collisionBodyStart = true;
            EM.setExamNumber(testNumber);
        }
        if(other.gameObject.name == "BodyEnd") {
            EM.collisionBodyEnd = true;
            EM.setExamNumber(testNumber);
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "BodyStart") {
            EM.collisionBodyStart = false;
            EM.setExamNumber(testNumber);
        }
        if(other.gameObject.name == "BodyEnd") {
            EM.collisionBodyEnd = false;
            EM.setExamNumber(testNumber);
        }
    }
}
