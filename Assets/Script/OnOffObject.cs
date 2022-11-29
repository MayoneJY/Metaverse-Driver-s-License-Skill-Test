using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffObject : MonoBehaviour
{
    [SerializeField] private bool _triggerBoolean = false;
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
    }

    public bool GetTrigger(){
        return _triggerBoolean;
    }
}
