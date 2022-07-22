using System.Collections;
using UnityEngine;

public class GearControl : MonoBehaviour
{
    private string[] GearState = { "Paking", "Return", "Nature", "Drive" };
    private int GearIndex;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGearIndex(int GearIndex){
        this.GearIndex = GearIndex;
    }

    public string getGearState(){
        return GearState[GearIndex];
    }

    
}
