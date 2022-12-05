using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject option;

    public void optionbtn()
    {
        option.SetActive(true);
    }

    public void optionexitbtn()
    {
        option.SetActive(false);
    }

    public void Scenegogo()
    {
        SceneManager.LoadScene("SoundTest");
    }

    public void Scenegoback()
    {
        SceneManager.LoadScene("CarSound");
    }

    public void test()
    {
        SceneManager.LoadScene("test2");
    }

    public void test2()
    {
        SceneManager.LoadScene("test3");
    }
}
