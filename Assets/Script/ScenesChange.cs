using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Test()
    {
        SceneManager.LoadScene("Test");
    }
    public void Practice()
    {
        SceneManager.LoadScene("Practice");
    }
}
