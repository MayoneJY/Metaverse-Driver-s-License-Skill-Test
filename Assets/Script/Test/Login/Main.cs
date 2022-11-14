using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Server Server;
    void Start()
    {
        Instance = this;
        Server = GetComponent<Server>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
