using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLamp : MonoBehaviour
{
    [SerializeField] private GameObject _nightBeamLight = null;
    [SerializeField] private GameObject _highBeamLight = null;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            bool isActive = _nightBeamLight.activeSelf == false;
            _nightBeamLight.SetActive(isActive);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            bool isActive = _highBeamLight.activeSelf == false;
            _highBeamLight.SetActive(isActive);
        }
    }
}
