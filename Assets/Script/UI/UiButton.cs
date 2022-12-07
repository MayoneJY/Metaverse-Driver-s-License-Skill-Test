using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    [SerializeField] private TurnSignal _TS;
    [SerializeField] private NightLamp _NL;
    [SerializeField] private WiperAction _WP;
    [SerializeField] private WiperAction _WP2;
    [SerializeField] private OnOffObject _OOO;

    [SerializeField] private GameObject Left, Right, Double;
    [SerializeField] private GameObject Low, High;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickLeft(bool check)
    {
        _TS.turnSignalOnOff("LEFT");
    }
    public void clickRight(bool check)
    {
        _TS.turnSignalOnOff("RIGHT");
    }
    public void clickDouble(bool check)
    {
        _TS.turnSignalOnOff("DOUBLE");
    }

    public void clickLowLight(bool check)
    {
        _NL.triggerLight();
        bool result;
        result = _NL.GetTrigger();
        if (!check)
        {
            High.GetComponent<Toggle>().isOn = false;
            _NL.triggerHighLightOff();
        }
            

    }
    public void clickHighLight(bool check)
    {
        bool result;
        result = _NL.triggerHighLight();
        if (!result)
            High.GetComponent<Toggle>().isOn = false;
    }

    public void clickWiper(bool check)
    {
        _WP.triggerCheck = true;
        _WP2.triggerCheck = true;
    }

    public void clickEngineStart(bool check)
    {
        _OOO.GetComponent<OnOffObject>().OnTrigger(check);
    }
}
