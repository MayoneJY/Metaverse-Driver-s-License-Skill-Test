using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BackGround");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
