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
        if (Input.GetKeyDown(KeyCode.A)) //�ڵ�
        {
            animator.SetBool("New Bool", true);             
        }

        if (Input.GetKeyDown(KeyCode.S)) //����
        {
            animator.SetBool("New Bool", false);
        }

        if (Input.GetKey(KeyCode.M)) //1ȸ
        {
          
        }

            if (Input.GetKeyDown(KeyCode.H)) //���
        {
            
        }

        if (Input.GetKeyDown(KeyCode.L)) //����
        {

        }
    }
}
