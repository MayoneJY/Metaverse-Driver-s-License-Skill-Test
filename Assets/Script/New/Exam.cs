using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam : MonoBehaviour
{
    [SerializeField] private bool hillTest = false;
    
    //탈락 체크
    [SerializeField] private bool leavingOut = false;

    private int examNumber = 0;
    public bool collisionBodyStart = false;
    public bool collisionBodyEnd = false;
    private bool collisionBody = false;
    
    private bool timeCheck = false;
    private float timer = 0.0f;

    private controller ctrl;
    // Start is called before the first frame update
    void Start()
    {
        ctrl = GetComponent<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (examNumber)
        {
            case 1:
                examHill();
                break;
            case 2:
                examTCourse();
                break;
        }


    }

    private void examTCourse(){
        if(!collisionBody) {
            // 차체가 블럭에 다 들어 왔을 때
            //Debug.Log("S:" + collisionBodyStart + ", E:" + collisionBodyEnd);
            if(collisionBodyStart && collisionBodyEnd) toggleCollisionBody();
        }
    }

    private void examHill(){

        if(!hillTest && timeCheck && !leavingOut){
            timer += Time.deltaTime;
        }


        if(!collisionBody) {
            // 차체가 언덕 블럭에 다 들어 왔을 때
            //Debug.Log("S:" + collisionBodyStart + ", E:" + collisionBodyEnd);
            if(collisionBodyStart && collisionBodyEnd) toggleCollisionBody();
            if(!collisionBodyStart && collisionBodyEnd) hillTest = false;
        }
        else{
            if(collisionBodyStart && collisionBodyEnd){
                //멈추면
                if(ctrl.KPH < 0.01f){
                    //최초 타이머 시작
                    if(!timeCheck){
                        timeCheck = !timeCheck;
                        timer = 0.0f;
                    }
                }
                //움직이면
                else{
                    Debug.Log(timer);
                    //3초 초과 30초 미만
                    if(timer > 3 && timer < 30){
                        hillTest = true;
                    }
                    else if(timer != 0.0f){
                        leavingOut = true;
                        Debug.Log("탈락");
                    }
                }
            }
            else if(!collisionBodyStart && collisionBodyEnd){
                timeCheck = false;
                //if(examNumber == 1) hillTest = true;
                //Debug.Log("성공");
            }
            else if(collisionBodyStart && !collisionBodyEnd){
                timeCheck = false;
                if(examNumber == 1) hillTest = false;
                //Debug.Log("탈락");
            }
            else if(!collisionBodyStart && !collisionBodyEnd){
                toggleCollisionBody();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            Debug.Log("�ǰ�");
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Line"))
        {
            Debug.Log("����");
        }
            
    }

    private void toggleCollisionBody(){
        collisionBody = !collisionBody;
    }

    public void setExamNumber(int number){
        if(this.examNumber != number) {
            collisionBody = false;
            collisionBodyEnd = false;
            collisionBodyStart = false;
        }
        this.examNumber = number;
    }
}
