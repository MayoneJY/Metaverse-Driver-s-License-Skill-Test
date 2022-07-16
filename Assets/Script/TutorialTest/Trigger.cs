using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Dialogue info;

    public void Trgger1()
    {
        var system = FindObjectOfType<TutorialTalk>();
        system.Begin(info);
    }
}
