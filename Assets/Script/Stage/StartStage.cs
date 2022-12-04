using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStage : MonoBehaviour
{
    [SerializeField] private Text _uiText;
    [SerializeField] private GameObject _timerPanel;
    [SerializeField] private Text _timerText;

    private string[] _uiTextValue = new string[]{
        "VR세팅을 마치면 반짝이는 버튼을 눌러주세요.",
        "첫 스테이지를 시작합니다. 안내 지시에 잘 따라주세요.",
        "5초이내에 시동을 거세요.",
        "10초 이내에 기어를 드라이브로 넣었다가 다시 파킹으로 전환하세요.",
        "5초이내에 좌측 방향지시등을 켜세요.",
        "5초이내에 좌측 방향지시등을 끄세요.",
        "5초이내에 우측 방향지시등을 켜세요.",
        "5초이내에 우측 방향지시등을 끄세요.",
        "5초이내에 와이퍼를 작동하세요.",
        "5초이내에 와이퍼를 끄세요.",
        "5초이내에 전조등을 키세요.",
        "5초이내에 상향등으로 전환하세요.",
        "5초이내에 하향등으로 전환하세요.",
        "5초이내에 전조등을 끄세요.",
        "브레이크를 밟은 상태에서 기어를 후진기어로 바꾸세요.",
        "기어를 후진기어로 둔 상태로 악셀을 살짝 밟아 속도를 시속 이십키로미터까지 올려보세요.",
        "브레이크를 밟아 멈추세요.",
        "브레이크를 밟은 상태에서 기어를 드라이브로 바꾸세요.",
        "기어를 드라이브로 둔 상태로 악셀을 살짝 밟아 속도를 시속 삼십키로미터까지 올려보세요.",
        "핸들을 반 시계방향으로 돌리고 왼쪽으로 이동해보세요.",
        "핸들을 시계방향으로 돌리고 오른쪽으로 이동해보세요."
    };
    [SerializeField] private AudioSource[] _audioTTS = new AudioSource[21];
    private int[] _uiTextTime = new int[]{1,1,5,10,5,5,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0};
    private int[] _uiTTSTime = new int[]{5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5};
    private int _uiTextCount = 0;

    [SerializeField] private int _score = 100;

    private bool _timeCheck = false;
    [SerializeField] private float _timer = 0.0f;
    private bool _timeOver = false;
    private float _uiTimer = 0.0f;

    [SerializeField] private GameObject _carEngineStarter;
    [SerializeField] private GameObject _carBody;
    [SerializeField] private GameObject _carTurnLight;
    [SerializeField] private GameObject _carWiper;
    [SerializeField] private GameObject _carGearArrow;
    [SerializeField] private GameObject _carTurnLightArrow;
    [SerializeField] private GameObject _carUnderLightArrow;
    [SerializeField] private GameObject _carTopLightArrow;

    private GearControl _GC;
    private TurnSignal _TS;
    private WiperAction _WA;
    private NightLamp _NL;
    private controller _CR;

    //기어바꾸기
    private bool[] _gearCheck = new bool[]{false, false};
    private int _gearCheckCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _timerPanel.SetActive(false);
        _GC = _carBody.GetComponent<GearControl>();
        _TS = _carTurnLight.GetComponent<TurnSignal>();
        _WA = _carWiper.GetComponent<WiperAction>();
        _NL = _carBody.GetComponent<NightLamp>();
        _CR = _carBody.GetComponent<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_timeCheck){
            _timer += Time.deltaTime;
            if(_timeOver){
                if(5.0f < _timer){
                    _score -= 3;
                    _timer = 0.0f;
                }
            }
            else if(_uiTextTime[_uiTextCount] + _uiTTSTime[_uiTextCount] < _timer){
                _score -= 5;
                _timeOver = true;
                _timeCheck = false;
                
            }

            switch (_uiTextCount)
            {
                case 0:
                case 1:
                    if(_uiTextTime[_uiTextCount] + _uiTTSTime[_uiTextCount] < _timer)
                    {
                        _timerPanel.SetActive(false);
                        _score += 5;
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    break;
                case 2: //시동걸기
                    _timerPanel.SetActive(true);
                    _carEngineStarter.transform.GetChild(0).gameObject.SetActive(true);
                    if(_carEngineStarter.GetComponent<OnOffObject>().GetTrigger()){
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                        _carEngineStarter.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    break;

                case 3: //기어바꾸기(P > D/N > P)
                    _carGearArrow.SetActive(true);
                    _timerPanel.SetActive(true);
                    switch (_gearCheckCount)
                    {
                        case 0:
                            if(_GC.m_GearState_Now >= 2){
                                _gearCheck[_gearCheckCount] = true;
                                _gearCheckCount += 1;
                            }
                            break;

                        case 1:
                            if(_GC.m_GearState_Now == 0){
                                _gearCheck[_gearCheckCount] = true;
                                _gearCheckCount += 1;
                            }
                            break;

                        case 2:
                            _uiTextCount++;
                            _timeCheck = false;
                            _timeOver = false;
                            _carGearArrow.SetActive(false);
                            break;

                        default:
                            break;
                    }
                    break;

                case 4: //좌측방향지시등 켜기
                    _timerPanel.SetActive(true);
                    _carTurnLightArrow.SetActive(true);
                    if(_TS.leftTurnSignal){
                        _uiTextCount++;
                        _carTurnLightArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    else if(_TS.rightTurnSignal){
                        //점수깍였다고 UI내보내자
                        _score -= 5;
                    }
                break;
                
                case 5: //좌측방향지시등 끄기
                    _timerPanel.SetActive(true);
                    _carTurnLightArrow.SetActive(true);
                    if(!_TS.leftTurnSignal){
                        _uiTextCount++;
                        _carTurnLightArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    else if(_TS.rightTurnSignal){
                        //점수깍였다고 UI내보내자
                        _score -= 5;
                    }
                break;

                case 6: //좌측방향지시등 켜기
                    _timerPanel.SetActive(true);
                    _carTurnLightArrow.SetActive(true);
                    if(_TS.rightTurnSignal){
                        _uiTextCount++;
                        _carTurnLightArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    else if(_TS.leftTurnSignal){
                        //점수깍였다고 UI내보내자
                        _score -= 5;
                    }
                break;
                
                case 7: //좌측방향지시등 끄기
                    _timerPanel.SetActive(true);
                    _carTurnLightArrow.SetActive(true);
                    if(!_TS.rightTurnSignal){
                        _uiTextCount++;
                        _carTurnLightArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    else if(_TS.leftTurnSignal){
                        //점수깍였다고 UI내보내자
                        _score -= 5;
                    }
                break;

                case 8: //와이퍼 켜기
                    _timerPanel.SetActive(true);
                    if(_WA._wiperValue == WiperAction.wiperValue.Automatic){
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    //다른 버튼 눌렀을떄 감점
                break;

                case 9: //와이퍼 끄기
                    _timerPanel.SetActive(true);
                    if(_WA._wiperValue == WiperAction.wiperValue.Off){
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 10: //하향등 켜기
                    _timerPanel.SetActive(true);
                    _carUnderLightArrow.SetActive(true);
                    if(_NL._nightBeamStatus && !_NL._highBeamStatus){
                        _uiTextCount++;
                        _carUnderLightArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 11: //상향등 켜기
                    _timerPanel.SetActive(true);
                    _carTopLightArrow.SetActive(true);
                    if(_NL._nightBeamStatus && _NL._highBeamStatus){
                        _uiTextCount++;
                        _carTopLightArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 12: //상향등 끄기
                    _timerPanel.SetActive(true);
                    _carTopLightArrow.SetActive(true);
                    if(_NL._nightBeamStatus && !_NL._highBeamStatus){
                        _uiTextCount++;
                        _carTopLightArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 13: //하향등 끄기
                    _timerPanel.SetActive(true);
                    _carUnderLightArrow.SetActive(true);
                    if(!_NL._nightBeamStatus){
                        _uiTextCount++;
                        _carUnderLightArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 14: //기어 리버스로
                    _carGearArrow.SetActive(true);
                    if(_GC.m_GearState_Now == 1){
                        _uiTextCount++;
                        _carGearArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 15: //후진 20km/h
                    if(_GC.m_GearState_Now == 1 && _CR.KPH > 20){
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 16: //브레이크
                    if(_GC.m_GearState_Now == 1 && _CR.KPH < 0.01f){
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 17: //기어 드라이브로
                    _carGearArrow.SetActive(true);
                    if(_GC.m_GearState_Now == 3){
                        _uiTextCount++;
                        _carGearArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;

                case 18: //전진 30km/h
                    if(_GC.m_GearState_Now == 3 && _CR.KPH > 30){
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                    }
                break;
                
                case 19: //왼쪽 회전
                    //회전하는 게이지를 채울끼?
                    //몇 도 회전하면 끝낼끼?
                    //일단 보류
                break;

                case 20: //오른쪽 회전
                break;
                
                default:
                break;
            }
            if(_uiTextCount > 3){
                if (!_carEngineStarter.GetComponent<OnOffObject>().GetTrigger()){
                    //실격.
                }
            }
        }
        else{
            if(!_timeOver)
                _uiTimer = 0.0f;
            _uiText.text = _uiTextValue[_uiTextCount];
            _timer = 0.0f;
            _timeCheck = !_timeCheck;
        }

        //timerText
        _uiTimer += Time.deltaTime;
        int _minute = Mathf.FloorToInt(_uiTimer - _uiTTSTime[_uiTextCount]);
        int _second = Mathf.FloorToInt((_uiTimer - _uiTTSTime[_uiTextCount]) * 100) - (_minute * 100);
        if (_minute < 0){
            _minute = 0;
            _second = 0;

            _timerPanel.SetActive(false);
        }
            
        if(_minute >= _uiTextTime[_uiTextCount])
            _timerText.color = Color.red;
        else
            _timerText.color = Color.black;
        _timerText.text = ((_minute < 10)? "0" + _minute.ToString():_minute.ToString()) + " : " + _second.ToString();
    }
}
