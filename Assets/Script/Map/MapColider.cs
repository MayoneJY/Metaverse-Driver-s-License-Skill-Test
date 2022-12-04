using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapColider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Car")){
            other.transform.localEulerAngles = new Vector3(0, 0, 0);
            other.transform.position = new Vector3(0, 0, 0);
            
        }
    }
}
