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
        YELLOW_2,
        MAX
    }

    [SerializeField] private LIGHT_TYPE _startType = LIGHT_TYPE.RED;
    [SerializeField] private GameObject[] _objectLights = new GameObject[(int)LIGHT_TYPE.MAX];

    [SerializeField] private float _redLightChangeSecond = 30.0f;
    [SerializeField] private float _yellowLightChangeSecond = 10.0f;
    [SerializeField] private float _greenLightChangeSecond = 30.0f;
    [SerializeField] private float _arrowLightChangeSecond = 30.0f;

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
        SetState(_startType);
    }

    // Update is called once per frame
    void Update()
    {
        _deltaLight += Time.deltaTime;
        float limitLightSeconds = 0.0f;

        switch (_currentLightType)
        {
            case LIGHT_TYPE.RED:
                limitLightSeconds = _redLightChangeSecond;
                break;
            case LIGHT_TYPE.YELLOW:
            case LIGHT_TYPE.YELLOW_2:
                limitLightSeconds = _yellowLightChangeSecond;
                break;
            case LIGHT_TYPE.GREEN:
                limitLightSeconds = _greenLightChangeSecond;
                break;
            case LIGHT_TYPE.ARROW:
                limitLightSeconds = _arrowLightChangeSecond;
                break;

        }

        if (_deltaLight >= limitLightSeconds)
        {
            _currentLightType = (LIGHT_TYPE)((int)_currentLightType + 1);

            if (_currentLightType == LIGHT_TYPE.MAX)
                _currentLightType = LIGHT_TYPE.GREEN;

            SetState(_currentLightType);
            _deltaLight = 0.0f;
        }
    }
}
