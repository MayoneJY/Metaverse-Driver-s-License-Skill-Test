using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn : MonoBehaviour
{
    public GameObject image, btn1;
    public Button btnimage;
    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
        btn1.SetActive(false);
        btnimage.onClick.AddListener(ShowImage);
    }

    private void ShowImage()
    {
        image.SetActive(true);
        btn1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
