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

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            bool isActive = _nightBeamLight.activeSelf == false;
            _nightBeamLight.SetActive(isActive);
            
            if (isActive)
            {
                _MainLight_LOD0.GetComponent<Renderer>().material = _lightOn;
            }
            else
            {
                _MainLight_LOD0.GetComponent<Renderer>().material = _lightOff;
            }


        }

       

        if (Input.GetKeyDown(KeyCode.K))
        {
            bool isActive = _highBeamLight.activeSelf == false;
            _highBeamLight.SetActive(isActive);

            if (isActive)
            {
                _MainLight_LOD0.GetComponent<Renderer>().material = _lightOn;
            }
            else
            {
                _MainLight_LOD0.GetComponent<Renderer>().material = _lightOff;
            }
        }
    

    }
}
