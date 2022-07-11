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
        if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetBool("New Bool", true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("New Bool", false);
        }
    }
}
