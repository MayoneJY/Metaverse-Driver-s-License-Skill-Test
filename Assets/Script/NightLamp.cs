using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLamp : MonoBehaviour
{
    [SerializeField] private GameObject _nightBeamLight = null;
    [SerializeField] private GameObject _highBeamLight = null;
    [SerializeField] private MeshRenderer _renderer = null;
    [SerializeField] private Material _lightOn = null;
    [SerializeField] private Material _lightOff = null;
    [SerializeField] private GameObject _DayTimeLight = null;
    [SerializeField] private GameObject _MainLight_LOD0 = null;
    [SerializeField] private GameObject _Ui_Down = null;
    [SerializeField] private GameObject _Ui_Up = null;
    public bool _nightBeamStatus = false;
    public bool _highBeamStatus = false;

    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            triggerLight();
        }

       

        if (Input.GetKeyDown(KeyCode.K))
        {   
            triggerHighLight();
            
        }
    

    }

    public void triggerLight()
    {
        _nightBeamStatus = !_nightBeamStatus;

        if (_nightBeamStatus)
        {
            _MainLight_LOD0.GetComponent<Renderer>().material = _lightOn;
            _nightBeamLight.SetActive(!_highBeamStatus);
            _Ui_Down.SetActive(!_highBeamStatus);
            _highBeamLight.SetActive(_highBeamStatus);
            _Ui_Up.SetActive(_highBeamStatus);
        }
        else
        {
            _MainLight_LOD0.GetComponent<Renderer>().material = _lightOff;
            _nightBeamLight.SetActive(false);
            _highBeamLight.SetActive(false);
            _Ui_Down.SetActive(false);
            _Ui_Up.SetActive(false);
        }
    }
    public bool triggerLight(bool Check)
    {
        _nightBeamStatus = !_nightBeamStatus;

        if (_nightBeamStatus)
        {
            _MainLight_LOD0.GetComponent<Renderer>().material = _lightOn;
            _nightBeamLight.SetActive(!_highBeamStatus);
            _Ui_Down.SetActive(!_highBeamStatus);
            _highBeamLight.SetActive(_highBeamStatus);
            _Ui_Up.SetActive(_highBeamStatus);
        }
        else
        {
            _MainLight_LOD0.GetComponent<Renderer>().material = _lightOff;
            _nightBeamLight.SetActive(false);
            _highBeamLight.SetActive(false);
            _Ui_Down.SetActive(false);
            _Ui_Up.SetActive(false);
        }
        return _nightBeamLight;
    }



    public void triggerHighLight(){
        if(_nightBeamStatus){
            _highBeamStatus = _highBeamLight.activeSelf == false;
            _highBeamLight.SetActive(_highBeamStatus);
            _nightBeamLight.SetActive(!_highBeamStatus);
            _Ui_Up.SetActive(_highBeamStatus);
            _Ui_Down.SetActive(!_highBeamStatus);
        }
    }

    public bool GetTrigger()
    {
        return _nightBeamStatus;
    }
}
