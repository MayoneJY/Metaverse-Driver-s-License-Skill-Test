using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffObject : MonoBehaviour
{
    [SerializeField] private bool _triggerBoolean = false;
    [SerializeField] private Material _materialOff;
    [SerializeField] private Material _materialOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTrigger(){
        _triggerBoolean = !_triggerBoolean;
        if(_triggerBoolean){
            gameObject.GetComponent<Renderer>().material = _materialOn;
        }
        else{
            gameObject.GetComponent<Renderer>().material = _materialOff;
        }
    }

    public bool GetTrigger(){
        return _triggerBoolean;
    }
}
