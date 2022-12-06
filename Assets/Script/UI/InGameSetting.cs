using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSetting : MonoBehaviour
{
    [SerializeField] private GameObject _oculusObject;
    [SerializeField] private GameObject _carObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void clickUpButton(){
        var po = _oculusObject.transform.position;
        _oculusObject.transform.position = new Vector3(po.x, po.y + 0.01f, po.z);
    }

    public void clickDownButton(){
        var po = _oculusObject.transform.position;
        _oculusObject.transform.position = new Vector3(po.x, po.y - 0.01f, po.z);
    }

    public void clickRespawnButton(){
        _carObject.transform.position = new Vector3(0, 0, 0);
        _carObject.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void clickQuitButton(){
        // Game Exit
        Application.Quit();
    }
}
