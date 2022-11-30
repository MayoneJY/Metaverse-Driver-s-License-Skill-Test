using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public enum LIGHT_TYPE
    {
        GREEN,
        YELLOW,
        RED,
        ARROW,
        MAX
    }

    [SerializeField] private LIGHT_TYPE _startType = LIGHT_TYPE.RED;
    [SerializeField] private GameObject[] _objectLights = new GameObject[(int)LIGHT_TYPE.MAX];

    [SerializeField] private float _redLightChangeSecond = 30.0f;
    [SerializeField] private float _yellowLightChangeSecond = 10.0f;
    [SerializeField] private float _greenLightChangeSecond = 30.0f;
    [SerializeField] private float _arrowLightChangeSecond = 30.0f;
    [SerializeField] private LIGHT_TYPE[] _lightTypeOrder = new LIGHT_TYPE[6];
    [SerializeField] private int[] _lightTypeTime = new int[6];
    [SerializeField] private int _lightTypeCount = 0;

    private float _deltaLight = 0.0f;

    private LIGHT_TYPE _currentLightType = LIGHT_TYPE.GREEN;

    private void SetState(LIGHT_TYPE type)
    {
        for (int i = 0; i < _objectLights.Length; ++i)
        {
            _objectLights[i].SetActive(false);
        }

        if (type == LIGHT_TYPE.ARROW)
            _objectLights[(int)LIGHT_TYPE.RED].SetActive(true);

        _objectLights[(int)type].SetActive(true);
        _currentLightType = type;
    }

    private void Start()
    {
        _currentLightType = _lightTypeOrder[_lightTypeCount];
        SetState(_currentLightType);
    }

    // Update is called once per frame
    void Update()
    {
        _deltaLight += Time.deltaTime;
        float limitLightSeconds = 0.0f;

        // switch (_currentLightType)
        // {
        //     case LIGHT_TYPE.RED:
        //         limitLightSeconds = _redLightChangeSecond;
        //         break;
        //     case LIGHT_TYPE.YELLOW:
        //         limitLightSeconds = _yellowLightChangeSecond;
        //         break;
        //     case LIGHT_TYPE.GREEN:
        //         limitLightSeconds = _greenLightChangeSecond;
        //         break;
        //     case LIGHT_TYPE.ARROW:
        //         limitLightSeconds = _arrowLightChangeSecond;
        //         break;

        // }

        limitLightSeconds = _lightTypeTime[_lightTypeCount];

        if (_deltaLight >= limitLightSeconds)
        {
            _lightTypeCount++;

            if (_lightTypeCount == _lightTypeOrder.Length   )
                _lightTypeCount = 0;

            _currentLightType = _lightTypeOrder[_lightTypeCount];

            SetState(_currentLightType);
            _deltaLight = 0.0f;
        }
    }

//	3
//1		1
//	3

//	3
//2		2
//	3

//	4
//3		3
//	3

//	2
//3		3
//	3

//	3
//3		3
//	1

//	3
//3		3
//	2
//10   5    10   5
//1�� 2�� 3�� 4ȭ

//�ܡܡܡ��ܡܡ�
//3   3   4   2   3   3
//10 5   5   5   10 5
//����ܡܡܡܡ�
//1   2   3   3   3
//10 5   10  10 5
//����ܡܡܡܡ�
//1   2   3   3   3
//10 5   10  10 5
//�ܡܡܡܡܡ���
//3   3   3   1   2
//10 5  10  10  5


//�ܡܡܡ��ܡܡ�
//3   3   4   2   3   3
//10 5   10   5   10 5
//����ܡܡܡܡ�
//1   2   3   3   3
//10 5   10  10  10
//����ܡܡܡܡ�
//1   2   3   3   3
//10 5   10  10  10
//�ܡܡܡܡܡ���
//3   3   3   1   2
//10 10  10  10  5
}
