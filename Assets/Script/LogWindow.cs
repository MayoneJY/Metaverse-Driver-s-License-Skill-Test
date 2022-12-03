using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogWindow : MonoBehaviour
{
    private Text logText = null;
 
    /// <summary>
    /// 스크롤바
    /// </summary>
    private ScrollRect scroll_rect = null;
 
 
    void Start () {
        logText = GameObject.Find("log_Text").GetComponent <Text> ();
        scroll_rect = GameObject.Find("Scroll_View").GetComponent<ScrollRect>();
 
        if (logText != null)
            logText.text += "Hello Log Window!" + "\n";
    }
    
    // Update is called once per frame
    void Update () {
 
        if (Input.GetMouseButtonDown(0))
        {
            // 현재 마우스의 위치를 TextUI 에추가해준다
            logText.text += "Mouse down position (" + "X : " + Input.mousePosition.x + " Y : " + Input.mousePosition.y + ")\n";
 
            // 스크롤바의 위치를 제일 아래로 내려준다 
            // 1.0이면 제일 위로 스크롤 0.0 이면 제일 아래로 스크롤이다
            scroll_rect.verticalNormalizedPosition = 0.0f;
        }
        
    }
}
