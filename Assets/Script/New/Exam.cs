using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam : MonoBehaviour
{
    //통과 체크
    [SerializeField] private bool hillTest = false;
    [SerializeField] private bool _tCourseTest = false;
    
    //탈락 체크
    [SerializeField] private bool leavingOut = false;

    private int _score = 100;

    private int examNumber = 0;
    private int examNumber2 = 0;
    public bool collisionBodyStart = false;
    public bool collisionBodyEnd = false;
    public bool collisionWheelEnd = false;
    private bool collisionBody = false;
    private bool _tCourseJoin = false;
    
    private bool timeCheck = false;
    private float timer = 0.0f;
    // T자코스
    private float _tCourseOverTime = 120.0f;
    private bool _tCourseCheck = false;
    private float _tCourseTimeCheck = 9999.0f;

    private controller ctrl;
    private inputManager _inputManager;
    // Start is called before the first frame update
    void Start()
    {
        ctrl = GetComponent<controller>();
        _inputManager = GetComponent<inputManager>();
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
                examTCourseStart();
                if(examNumber2 == 1){
                    examTCourse();
                }
                break;
        }


    }

    private void examTCourseStart(){
        // 입장 후 시험
        if(timeCheck && _tCourseJoin){
            timer = timer + Time.deltaTime;

            if(timer >= _tCourseOverTime){
                _tCourseOverTime += 5.0f;
                if(_tCourseOverTime == 120.0f)
                    _score -= 10;
                else
                    _score -= 3;

            }


        }

        // 첫 입장
        if(!_tCourseJoin && collisionBodyStart){
            _tCourseJoin = true;
        }

        // 퇴장
        if(_tCourseJoin && collisionBodyStart && timer > 20.0f){
            _tCourseJoin = false;
            timeCheck = false;
            if(_tCourseCheck){
                _tCourseTest = true;
            }
        }
        
        // 입장 후 타이머 작동
        if(!timeCheck && _tCourseJoin){
            timeCheck = true;   
        }

    }

    private void examTCourse(){
        if(collisionWheelEnd) {
            // 확인선을 밟았을 때

            if(ctrl.KPH < 0.01f && _inputManager.isParkingPress && !_tCourseCheck){
                // 주차브레이크 작동 했을 때
                _tCourseCheck = true;
                _tCourseTimeCheck = timer;
            }
            else if(ctrl.KPH < 0.01f && !_inputManager.isParkingPress && _tCourseCheck){
                // 주차브레이크 작동 후 주차브레이크 작동 해제 했을 때
                if(timer < _tCourseTimeCheck + 1.0f){
                    // 1초 이하 동안 작동 했을 때
                    _tCourseCheck = false;
                    _score -= 10;
                }
            }
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
            Debug.Log("실격");
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Line"))
        {
            Debug.Log("10점 감점");
        }
            
    }

    private void toggleCollisionBody(){
        collisionBody = !collisionBody;
    }

    public void setExamNumber(int number, int number2){
        if(this.examNumber != number) {
            collisionBody = false;
            collisionBodyEnd = false;
            collisionBodyStart = false;
            timer = 0.0f;
            timeCheck = false;
        }
        this.examNumber = number;
        this.examNumber2 = number2;
    }
}
