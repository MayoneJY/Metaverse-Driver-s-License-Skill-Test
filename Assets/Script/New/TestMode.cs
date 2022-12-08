using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMode : MonoBehaviour
{

    [SerializeField] private AudioClip[] _audioTTS = new AudioClip[21];
    private int[] _uiTextTime = new int[] { 1, 5, 1, 10, 5, 5, 5, 5, 1, 10, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] private float[] _uiTTSTime = new float[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
    private int _uiTextCount = 0;
    [SerializeField] private int _score = 100;
    private bool _timeCheck = false;
    private bool _boolAudioPlayed = false;
    private bool _timeOver = false;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _timer = 0.0f;
    [SerializeField] private GameObject _carEngineStarter;
    private bool[] _gearCheck = new bool[] { false, false };
    private int _gearCheckCount = 0;
    [SerializeField] private GearControl _GC;
    [SerializeField] private TurnSignal _TS;
    [SerializeField] private WiperAction _WA;
    // Start is called before the first frame update
    void OnEnable()
    {

        _uiTextCount = 0;

        _score = 100;

        _timeCheck = false;
        _timer = 0.0f;
        _timeOver = false;
        _boolAudioPlayed = false;
        _gearCheck = new bool[] { false, false };
        _gearCheckCount = 0;
        for (int i = 0; i < _audioTTS.Length; i++)
        {
            _uiTTSTime[i] = _audioTTS[i].length;
        }
        _audioSource.clip = _audioTTS[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeCheck)
        {
            _timer += Time.deltaTime;
            if (_timeOver)
            {
                if (5.0f < _timer)
                {
                    _score -= 3;
                    _timer = 0.0f;
                }
            }
            switch (_uiTextCount)
            {
                case 0:
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    if (_uiTextTime[_uiTextCount] + _uiTTSTime[_uiTextCount] < _timer)
                    {
                        _audioSource.Stop();
                        _boolAudioPlayed = false;
                        //_timerPanel.SetActive(false);
                        _score += 5;
                        _uiTextCount++;
                        _audioSource.clip = _audioTTS[_uiTextCount];
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    break;
                case 1: //시동걸기
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    //_timerPanel.SetActive(true);
                    //_carEngineStarterArrow.SetActive(true);
                    if (_carEngineStarter.GetComponent<OnOffObject>().GetTrigger())
                    {
                        _boolAudioPlayed = false;
                        _uiTextCount++;
                        _audioSource.Stop();
                        _audioSource.clip = _audioTTS[_uiTextCount];
                        _timeCheck = false;
                        _timeOver = false;
                        //_carEngineStarterArrow.SetActive(false);
                    }
                    break;
                case 2:
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    if (_uiTextTime[_uiTextCount] + _uiTTSTime[_uiTextCount] < _timer)
                    {
                        _audioSource.Stop();
                        _boolAudioPlayed = false;
                        //_timerPanel.SetActive(false);
                        _score += 5;
                        _uiTextCount++;
                        _audioSource.clip = _audioTTS[_uiTextCount];
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    break;
                case 3:
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    //_carGearArrow.SetActive(true);
                    //_timerPanel.SetActive(true);
                    switch (_gearCheckCount)
                    {
                        case 0:
                            if (_GC.m_GearState_Now >= 2)
                            {
                                _gearCheck[_gearCheckCount] = true;
                                _gearCheckCount += 1;
                            }
                            break;

                        case 1:
                            if (_GC.m_GearState_Now == 0)
                            {
                                _gearCheck[_gearCheckCount] = true;
                                _gearCheckCount += 1;
                            }
                            break;

                        case 2:
                            _uiTextCount++;
                            _boolAudioPlayed = false;
                            _audioSource.Stop();
                            _audioSource.clip = _audioTTS[_uiTextCount];
                            _timeCheck = false;
                            _timeOver = false;
                            //_carGearArrow.SetActive(false);
                            break;

                        default:
                            break;
                    }
                    break;

                case 4: //좌측방향지시등 켜기
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    //_timerPanel.SetActive(true);
                    //_carTurnLightArrow2.SetActive(true);
                    if (_TS.rightTurnSignal)
                    {
                        _uiTextCount++;
                        _boolAudioPlayed = false;
                        _audioSource.Stop();
                        _audioSource.clip = _audioTTS[_uiTextCount];
                        //_carTurnLightArrow2.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    else if (_TS.leftTurnSignal)
                    {
                        //점수깍였다고 UI내보내자
                        _score -= 5;
                    }
                    break;

                case 5: //좌측방향지시등 끄기
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    //_timerPanel.SetActive(true);
                    //_carTurnLightArrow2.SetActive(true);
                    if (!_TS.rightTurnSignal)
                    {
                        _uiTextCount++;
                        _boolAudioPlayed = false;
                        _audioSource.Stop();
                        _audioSource.clip = _audioTTS[_uiTextCount];
                        //_carTurnLightArrow2.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    else if (_TS.leftTurnSignal)
                    {
                        //점수깍였다고 UI내보내자
                        _score -= 5;
                    }
                    break;
                case 6: //와이퍼 켜기
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    //_timerPanel.SetActive(true);
                    //_carWiperArrow.SetActive(true);
                    if (_WA._wiperValue == WiperAction.wiperValue.Automatic)
                    {
                        _uiTextCount++;
                        _boolAudioPlayed = false;
                        _audioSource.Stop();
                        _audioSource.clip = _audioTTS[_uiTextCount];
                        //_carWiperArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    break;
                case 7: //와이퍼 끄기
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    //_timerPanel.SetActive(true);
                    //_carWiperArrow.SetActive(true);
                    if (_WA._wiperValue == WiperAction.wiperValue.Off)
                    {
                        _uiTextCount++;
                        _boolAudioPlayed = false;
                        _audioSource.Stop();
                        _audioSource.clip = _audioTTS[_uiTextCount];
                        //_carWiperArrow.SetActive(false);
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    break;
                case 8:
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    if (_uiTextTime[_uiTextCount] + _uiTTSTime[_uiTextCount] < _timer)
                    {
                        _audioSource.Stop();
                        _boolAudioPlayed = false;
                        _audioSource.clip = _audioTTS[_uiTextCount];
                        //_timerPanel.SetActive(false);
                        _score += 5;
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    break;
                case 9:
                    if (!_boolAudioPlayed)
                    {
                        _audioSource.Play();
                        _boolAudioPlayed = true;
                    }
                    if (_uiTextTime[_uiTextCount] + _uiTTSTime[_uiTextCount] < _timer)
                    {
                        _audioSource.Stop();
                        _boolAudioPlayed = false;
                        //_timerPanel.SetActive(false);
                        _score += 5;
                        _uiTextCount++;
                        _timeCheck = false;
                        _timeOver = false;
                    }
                    break;
            }
        }
        else
        {
           // if (!_timeOver)
            //    _uiTimer = 0.0f;
            //_uiText.text = _uiTextValue[_uiTextCount];
            _timer = 0.0f;
            _timeCheck = !_timeCheck;
        }
    }
}
