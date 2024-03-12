using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSetting : MonoBehaviour
{
    [SerializeField] private GameObject _carObject;
    //[SerializeField] private GameObject _TurnLightUiObject;
    [SerializeField] private GameObject _LowBeamUiObject;
    [SerializeField] private GameObject _HighBeamUiObject;
    [SerializeField] private GameObject _WiperUiObject;
    [SerializeField] private GameObject _LeftSignalObject;
    [SerializeField] private GameObject _RightSignalObject;
    [SerializeField] private TurnSignal _TS;
    [SerializeField] private NightLamp _NL;
    [SerializeField] private WiperAction _WP;
    [SerializeField] private WiperAction _WP2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "EngineStarter")
        {
            other.gameObject.GetComponent<OnOffObject>().OnTrigger();

        }
        else if(other.gameObject.name == "Warning")
        {
            
            _TS.turnSignalOnOff("DOUBLE");
            other.gameObject.GetComponent<OnOffObject>().OnTrigger();


        }
        else if(other.gameObject.name == "UnderLight")
        {
            bool result;
            result = _NL.triggerLight(true);
            if(result)
                other.gameObject.GetComponent<OnOffObject>().OnTrigger(result);
            else
                other.gameObject.GetComponent<OnOffObject>().OnTrigger(result);
            Debug.Log("UnderLight: " + result);

        }
        else if(other.gameObject.name == "TopLight")
        {
            bool result;
            result = _NL.GetTrigger();
            if (result)
                other.gameObject.GetComponent<OnOffObject>().OnTrigger();
            Debug.Log("TopLight: " + result);


        }
        else if(other.gameObject.name == "Wiper")
        {
            _WiperUiObject.GetComponent<OnOffObject>().OnTrigger();
            _WP.triggerCheck = true;
            _WP2.triggerCheck = true;
            Debug.Log("Wiper: ");

        }
        else if(other.gameObject.name == "Left")
        {
            _TS.turnSignalOnOff("LEFT");
            other.gameObject.GetComponent<OnOffObject>().OnTrigger();
            _RightSignalObject.GetComponent<OnOffObject>().OnTrigger(false);
            Debug.Log("LEFT: ");

        }
        else if(other.gameObject.name == "Right")
        {
            _TS.turnSignalOnOff("RIGHT");
            other.gameObject.GetComponent<OnOffObject>().OnTrigger();
            _LeftSignalObject.GetComponent<OnOffObject>().OnTrigger(false);
            Debug.Log("RIGHT: ");
        }

    }

}
