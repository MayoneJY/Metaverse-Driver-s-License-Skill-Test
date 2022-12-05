using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam : MonoBehaviour
{
    [Header("통과 체크")]
    [SerializeField] private bool hillTest = false;
    [SerializeField] private bool _tCourseTest = false;
    
    [Header("탈락 체크")]
    [SerializeField] private bool leavingOut = false;

    [Header("점수")]
    [SerializeField] private int _score = 100;

    [Header("기타 확인")]
    [SerializeField] private int examNumber = 0;
    [SerializeField] private int examNumber2 = 0;
    public bool collisionBodyStart = false;
    public bool collisionBodyCenter = false;
    public bool collisionBodyEnd = false;
    public bool collisionWheelEnd = false;
    private bool collisionBody = false;
    private bool _tCourseJoin = false;
    private bool _boolWarningCheck = false;
    private bool _boolWarningCheck2 = false;
    private bool _boolWarningCheck3 = false;
    
    private bool timeCheck = false;
    private float timer = 0.0f;

    [Header("T자 코스")]
    private float _tCourseOverTime = 120.0f;
    private bool _tCourseCheck = false;
    private float _tCourseTimeCheck = 9999.0f;

    [Header("신호등 코스")]
    [SerializeField] private TrafficLightController _TLC_1;
    [SerializeField] private TrafficLightController _TLC_2;
    public bool _boolTrafficLightCheck = false;
    [SerializeField] private float _floatTrafficLightStopTime = 0.0f;
    [SerializeField] private TurnSignal _turnSignal;

    [Header("돌발 상황")]
    [SerializeField] private bool _boolWarringStopCheck = false;
    [SerializeField] private float _floatWarringStopTime = 0.0f;
    [SerializeField] private float _floatWarringTimeOver = 0.0f;
    [SerializeField] private int _intWarringRandom = 0;

    private controller ctrl;
    private inputManager _inputManager;
    // Start is called before the first frame update
    void Start()
    {
        ctrl = GetComponent<controller>();
        _inputManager = GetComponent<inputManager>();
        _intWarringRandom = Random.Range(1, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if(!collisionBodyStart && !collisionBodyCenter && !collisionBodyEnd){
            examNumber = 0;
            examNumber2 = 0;
        }
        if(examNumber == 0 && examNumber2 == 0){
            if(_turnSignal.doubleTurnSignal && !_boolWarningCheck){
                // 돌발상황 지시 전 비상등을 작동한 경우 10점 감점
                Debug.Log("돌발상황: 돌발상황 지시 전 비상등을 작동함 (-10)");
                _score -= 10;
                _boolWarningCheck = true;
            }
            else if(!_turnSignal.doubleTurnSignal && _boolWarningCheck){
                _boolWarningCheck = false;
            }
        }
        switch (examNumber)
        {
            case 1:
                //언덕코스
                examHill();
                break;
            case 2:
                //T코스
                examTCourseStart();
                if(examNumber2 == 1){
                    examTCourse();
                }
                break;
            case 3:
                //신호등 코스
                examTrafficLight();
                break;
            case 4:
                //돌발 상황
                if(_intWarringRandom == examNumber2)
                    examWarring();
                break;
            case 5:
                //가속 구간
                examFast();
                break;
                
        }


    }

    private void examFast(){
        // 가속 구간
        if(ctrl.KPH <= 20.0f)
        {

        }
    }

    private void examWarring(){
        // 돌발생황
        timer += Time.deltaTime;
        if(timer > 2.0f && !_boolWarringStopCheck){
            // 2초이내에 정지하지 못 한 경우 10점 감점
            Debug.Log("돌발상황: 2초이내 정지 못함 (-10)");
            _score -= 10;
        }

        if(!_boolWarringStopCheck && ctrl.KPH < 0.01f){
            _boolWarringStopCheck = true;
            _floatWarringStopTime = timer;
        }
        if(_boolWarringStopCheck){
            if(timer - _floatWarringStopTime > 3.0f){
                if(!_turnSignal.doubleTurnSignal && !_boolWarningCheck2){
                    // 정지후 3초이내에 비상등을 작동 못 한 경우 10점 감점
                    Debug.Log("돌발상황: 3초이내에 비상등을 작동 못함 (-10)");
                    _score -= 10;
                    _boolWarningCheck2 = true;
                }

            }
        }
        if(_turnSignal.doubleTurnSignal && ctrl.KPH > 3.0f && !_boolWarningCheck3){
            // 비상등을 끄지 않고 1m이상 주행 한 경우 10점 감점
            Debug.Log("돌발상황: 비상등을 끄지 않고 주행 (-10)");
            _score -= 10;
            _boolWarningCheck3 = true;
        }

        // 정해진 시간을 지키지 못 한 경우  5초마다 3점씩 감점
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
    }

    private void examTrafficLight(){
        // 신호등 코스
        if(_boolTrafficLightCheck){
            //신호등 코스 공통
            timer += Time.deltaTime;

            if(!timeCheck && ctrl.KPH < 0.01f){
                //정지선 넘어서 멈췄을 때
                _floatTrafficLightStopTime += Time.deltaTime;
            }
            if(_floatTrafficLightStopTime > 3.0f){
                // 3초이상 멈췄을 때
                Debug.Log("신호등: 정지선 이후에 3초이상 멈춤 (-5)");
                _score -= 5;
            }
            if(timer > 20.0f){
                // 20초 이상 30초 이내에 통과 했을 경우
                Debug.Log("신호등: 20초 이상 30초 이내에 통과했을 경우 (-5)");
                _score -= 5;
            }
            if(timer > 30.0f){
                // 30초 이상 통과하지 못 했을 경우
                Debug.Log("신호등: 30초 이상 통과하지 못 했을 경우 (실격)");
                leavingOut = true;
            }
        }
        switch (examNumber2)
        {
            case 1:
                //첫 신호등, 두 번째 신호등

                if(_TLC_1._currentLightType == TrafficLightController.LIGHT_TYPE.RED){
                    // 빨간불일 때 정지선 넘으면 바로 탈락
                    Debug.Log("신호등: 빨간불에 정지선 통과 (실격)");
                    leavingOut = true;
                }
                break;
            case 2:
                //신호등 공통
                break;
        }
    }

    private void examTCourseStart(){
        // 입장 후 시험
        if(timeCheck && _tCourseJoin){
            timer = timer + Time.deltaTime;

            if(timer >= _tCourseOverTime){
                _tCourseOverTime += 5.0f;
                if(_tCourseOverTime == 120.0f){
                    Debug.Log("T코스: 제한시간 2분 초과 (-10)");
                    _score -= 10;
                }
                else{
                    Debug.Log("T코스: 제한시간 2분 초과 이후 5초 초과 (-3)");
                    _score -= 3;
                }

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
                    Debug.Log("T코스: 주차브레이크 1초 이상 하지 않음 (-10)");
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
                    //Debug.Log(timer);
                    //3초 초과 30초 미만
                    if(timer > 3 && timer < 30){
                        hillTest = true;
                    }
                    else{
                        Debug.Log("언덕코스: 30초 이내에 정지선 통과 못함 / 정지하지 않고 통과 (실격)");
                        leavingOut = true;
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
                if(examNumber == 1) {
                    Debug.Log("언덕코스: 후방으로 밀림 (실격)");
                    leavingOut = true;
                }
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
            Debug.Log("공통: 연석/보도블럭을 침범 (실격)");
            leavingOut = true;
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Line"))
        {
            Debug.Log("공통: 차선/중앙선을 침범 (-15) : " + other.gameObject.name);
            _score -= 15;
        }
            
    }

    private void toggleCollisionBody(){
        collisionBody = !collisionBody;
    }

    public void setExamNumber(int number, int number2){
        if(this.examNumber != number || this.examNumber2 != number2) {
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
