using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public static bool isController = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Joystick.all.Count; i++)
        {
            Debug.Log(Joystick.all[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( Joystick.all.Count > 0)
        {
            isController = true;
            //Debug.Log(Joystick.current.stick.ReadValue());
            //Debug.Log(Joystick.all[0].stick.x.ReadValue());
        }
        else{
            isController = false;
        }
    }

    public void asdasd(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<float>());
    }
}
