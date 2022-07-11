using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperAction : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //자동
        {
            animator.SetBool("New Bool", true);             
        }

        if (Input.GetKeyDown(KeyCode.S)) //정지
        {
            animator.SetBool("New Bool", false);
        }

        if (Input.GetKey(KeyCode.M)) //1회
        {
          
        }

            if (Input.GetKeyDown(KeyCode.H)) //고속
        {
            
        }

        if (Input.GetKeyDown(KeyCode.L)) //저속
        {

        }
    }
}
