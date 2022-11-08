using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InPutManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float vertical;
    public float horizontal;
    public CarController CC;
    public Text gearNum;

    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    public void Updatena()
    {
        float temp = CC.engineRPM / 10000;

    }

    public void changeGear()
    {
        gearNum.text = CC.gearNum.ToString();
    }
}
