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
    public bool _nightBeamStatus = false;
    public bool _highBeamStatus = false;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            _nightBeamStatus = !_nightBeamStatus;
            
            if (_nightBeamStatus)
            {
                _MainLight_LOD0.GetComponent<Renderer>().material = _lightOn;
                _nightBeamLight.SetActive(!_highBeamStatus);
                _highBeamLight.SetActive(_highBeamStatus);
            }
            else
            {
                _MainLight_LOD0.GetComponent<Renderer>().material = _lightOff;
                _nightBeamLight.SetActive(false);
                _highBeamLight.SetActive(false);
            }


        }

       

        if (Input.GetKeyDown(KeyCode.K))
        {   
            if(_nightBeamStatus){
                _highBeamStatus = _highBeamLight.activeSelf == false;
                _highBeamLight.SetActive(_highBeamStatus);
                _nightBeamLight.SetActive(!_highBeamStatus);
            }
            
        }
    

    }
}
