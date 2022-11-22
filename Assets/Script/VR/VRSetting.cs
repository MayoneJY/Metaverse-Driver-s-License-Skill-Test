using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSetting : MonoBehaviour
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
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Up")
        {
            var po = _oculusObject.transform.position;
            _oculusObject.transform.position = new Vector3(po.x, po.y + 0.05f, po.z);
        }
        else if (other.gameObject.name == "Down")
        {
            var po = _oculusObject.transform.position;
            _oculusObject.transform.position = new Vector3(po.x, po.y - 0.05f, po.z);
        }
        else if (other.gameObject.name == "Respawn")
        {
            _carObject.transform.position = new Vector3(0, 0, 0);
        }

    }

}
