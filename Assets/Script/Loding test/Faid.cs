using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Faid : MonoBehaviour
{
    private Image image;
    // Start is called before the first frame update
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        Color color = image.color;

        /*if (color.a > 0)  // 페이드인
        { 
            color.a -= Time.deltaTime;
        }*/

        if (color.a <1)  // 페이드아웃
        {
            color.a += Time.deltaTime;
        }

        image.color = color;
    }
}
