using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperAction : MonoBehaviour
{
    public enum wiperValue{
        Off,
        Automatic,
        Manual
    }
    Animator animator;
    bool WiperM = false;
    public wiperValue _wiperValue;
    public bool triggerCheck = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        _wiperValue = wiperValue.Off;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || triggerCheck) //�ڵ�
        {
            triggerCheck = false;
            if(!animator.GetBool("WiperA")){
                animator.SetBool("WiperA", true);
                animator.SetBool("WiperH", false);
                animator.SetBool("WiperL", false);
                _wiperValue = wiperValue.Automatic;
            }
            else{
                animator.SetBool("WiperA", false);
                animator.SetBool("WiperH", false);
                animator.SetBool("WiperL", false);
                _wiperValue = wiperValue.Off;
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) //����
        {
        }

        if (Input.GetKeyDown(KeyCode.G)) //1ȸ
        {
            _wiperValue = wiperValue.Manual;
            animator.Play("WiperRightH", -1, 0f);
            animator.Play("WiperLeftH", -1, 0f);
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperH", false);
            animator.SetBool("WiperL", false);
            _wiperValue = wiperValue.Off;
        }


       /* if (Input.GetKey(KeyCode.M))
        {
            animator.SetTrigger("WiperRightM");
            animator.SetTrigger("WiperLeftM");
        }



        */


        if (Input.GetKeyDown(KeyCode.H)) //����
        {
            animator.SetBool("WiperH", true);
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperL", false);
        }

        if (Input.GetKeyDown(KeyCode.L)) //����
        {
            animator.SetBool("WiperL", true);
            animator.SetBool("WiperA", false);
            animator.SetBool("WiperH", false);
        }
    }
}
