using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam : MonoBehaviour
{
    public bool collisionBodyStart = false;
    public bool collisionBodyEnd = false;
    private bool collisionBody = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!collisionBody) {
            // 차체가 언덕 블럭에 다 들어 왔을 때
            //Debug.Log("S:" + collisionBodyStart + ", E:" + collisionBodyEnd);
            if(collisionBodyStart && collisionBodyEnd) toggleCollisionBody();
            if(!collisionBodyStart && collisionBodyEnd) Debug.Log("왜 뒤로가");
        }
        else{
            if(!collisionBodyStart && collisionBodyEnd){
                Debug.Log("성공");
            }
            else if(collisionBodyStart && !collisionBodyEnd){
                Debug.Log("탈락");
            }
            else if(!collisionBodyStart && !collisionBodyEnd){
                toggleCollisionBody();
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            Debug.Log("�ǰ�");
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Line"))
        {
            Debug.Log("����");
        }
            
    }

    private void toggleCollisionBody(){
        collisionBody = !collisionBody;
    }
}
