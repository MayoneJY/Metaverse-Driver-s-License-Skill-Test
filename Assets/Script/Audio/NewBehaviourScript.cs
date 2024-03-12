using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject option;
    private AudioManager _audioManager;

    public void Start()
    {
        _audioManager = GetComponent<AudioManager>();
    }

    public void optionbtn()
    {
        SaveAudioSettings();
        option.SetActive(true);
    }

    public void optionexitbtn()
    {
        SaveAudioSettings();
        option.SetActive(false);
    }

    public void Scenegogo()
    {
        SaveAudioSettings();
        SceneManager.LoadScene("SoundTest");
    }

    public void Scenegoback()
    {
        SaveAudioSettings();
        SceneManager.LoadScene("CarSound");
    }

    public void test()
    {
        SaveAudioSettings();
        SceneManager.LoadScene("test2");
    }

    public void test2()
    {
        SaveAudioSettings();
        SceneManager.LoadScene("test3");
    }


    private void SaveAudioSettings(){
        _audioManager.SaveSoundSettings();
    }
}
