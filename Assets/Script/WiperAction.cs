using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperAction : MonoBehaviour
{
    Animator animator;
    float time;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //�ڵ�
        {
            animator.SetBool("WiperA", true);
            animator.SetBool("WiperH", false);
            animator.SetBool("WiperL", false);
            animator.SetBool("WiperM", false);
            
        }

        if (Input.GetKeyDown(KeyCode.S)) //����
        {
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperH", false);
            animator.SetBool("WiperL", false);
            animator.SetBool("WiperM", false);
        }

        if (Input.GetKeyDown(KeyCode.M)) //1ȸ
        {
            animator.SetBool("WiperM", true);
        }
        if (Input.GetKeyUp(KeyCode.M)) //1ȸ
        {
            animator.SetBool("WiperM", false);
        }

        /*        if (Input.GetKeyDown(KeyCode.M))
                {
                    animator.SetTrigger("WiperRightM");
                    animator.SetTrigger("WiperLeftM"); 
                }*/






        if (Input.GetKeyDown(KeyCode.H)) //���
        {
            animator.SetBool("WiperH", true);
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperL", false);
            animator.SetBool("WiperM", false);
        }

        if (Input.GetKeyDown(KeyCode.L)) //����
        {
            animator.SetBool("WiperL", true);
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperH", false);
            animator.SetBool("WiperM", false);
        }
    }
}
