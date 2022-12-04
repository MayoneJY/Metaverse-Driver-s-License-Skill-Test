using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public controller RR;
    public GameObject needle;
    public Text kph;
    private float startPosition = 205f, endPosition = -25f;
    private float desiredPosition;

    public float vehicleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        kph.text = RR.KPH.ToString("0");
        updateNeedle();
    }


    public void updateNeedle(){
        desiredPosition = startPosition - endPosition;
        float temp = RR.engineRPM / 10000;
        needle.transform.localEulerAngles = new Vector3(0,0,(startPosition - temp * desiredPosition));
    }
}
