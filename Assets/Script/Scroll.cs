using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public RectTransform List; // 움직일 오브젝트
    public int count; // 나눠야할 값
    private float pos;  // LocalPosition
    private float movepos; // 움직일값
    private bool isScroll = false;  //움직임 구분
    // Start is called before the first frame update
    void Start()
    {
        pos = List.localPosition.x;
        movepos = List.rect.xMax - List.rect.xMax / count;
    }

    public void Right()
    {
        if (List.rect.xMin + List.rect.xMax / count == movepos)
        {

        }
        else
        {
            isScroll = true;
            movepos = pos - List.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());
        }
    }

    private string scroll()
    {
        throw new NotImplementedException();
    }

    public void Left()
    {
        if (List.rect.xMax + List.rect.xMax / count == movepos)
        {

        }
        else
        {
            isScroll = true;
            movepos = pos - List.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());
        }
    }
    // Update is called once per frame
    void Update()
    {
        IEnumerator scroll()
        {
            while (isScroll)
            {
                List.localPosition = Vector2.Lerp(List.localPosition, new Vector2(movepos, 0), Time.deltaTime * 5);
                if (Vector2.Distance(List.localPosition, new Vector2(movepos, 0)) < 0.1f)
                {
                    isScroll = false;
                }
                yield return null;
            }
        }
    }
}

