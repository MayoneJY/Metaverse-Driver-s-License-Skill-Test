using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperAction : MonoBehaviour
{
    Animator animator;
    bool WiperM = false;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //자동
        {
            animator.SetBool("WiperA", true);
            animator.SetBool("WiperH", false);
            animator.SetBool("WiperL", false);
        }

        if (Input.GetKeyDown(KeyCode.S)) //정지
        {
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperH", false);
            animator.SetBool("WiperL", false);
        }

        if (Input.GetKeyDown(KeyCode.M)) //1회
        {
            animator.SetBool("WiperM", true);
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperH", false);
            animator.SetBool("WiperL", false);
        }


       /* if (Input.GetKey(KeyCode.M))
        {
            animator.SetTrigger("WiperRightM");
            animator.SetTrigger("WiperLeftM");
        }



        */


        if (Input.GetKeyDown(KeyCode.H)) //고속
        {
            animator.SetBool("WiperH", true);
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperL", false);
        }

        if (Input.GetKeyDown(KeyCode.L)) //저속
        {
            animator.SetBool("WiperL", true);
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperH", false);
        }
    }
}
