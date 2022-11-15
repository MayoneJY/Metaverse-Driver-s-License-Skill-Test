using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamCar : MonoBehaviour
{
    private Exam EM;

    // Start is called before the first frame update
    void Start()
    {
        EM = transform.parent.GetComponent<Exam>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "HillCenter") {
            if(transform.name == "BodyStart"){
                EM.collisionBodyStart = true;
            }
            else if(transform.name == "BodyEnd"){
                EM.collisionBodyEnd = true;
            }
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "HillCenter") {
            if(transform.name == "BodyStart"){
                EM.collisionBodyStart = false;
            }
            else if(transform.name == "BodyEnd"){
                EM.collisionBodyEnd = false;
            }
        }
            
    }
}
