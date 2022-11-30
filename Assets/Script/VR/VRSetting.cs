using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSetting : MonoBehaviour
{
    [SerializeField] private GameObject _oculusObject;
    [SerializeField] private GameObject _carObject;
    public GearControl GC;
    // Start is called before the first frame update
    void Start()
    {
        GC = _carObject.GetComponent<GearControl>();

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
            _oculusObject.transform.position = new Vector3(po.x, po.y + 0.01f, po.z);
        }
        else if (other.gameObject.name == "Down")
        {
            var po = _oculusObject.transform.position;
            _oculusObject.transform.position = new Vector3(po.x, po.y - 0.01f, po.z);
        }
        else if (other.gameObject.name == "Respawn")
        {
            _carObject.transform.position = new Vector3(0, 0, 0);
            _carObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if(other.gameObject.name == "Drive")
        {
            GC.m_GearState_Now = 3;

        }
        else if(other.gameObject.name == "Return")
        {
            GC.m_GearState_Now = 1;

        }

    }

}
