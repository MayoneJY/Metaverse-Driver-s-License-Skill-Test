using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlayer = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";


    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlayer);

        if(firstPlayInt == 0)
        {
            backgroundFloat = .25f;
            soundEffectsFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlayer, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsSlider.value);
    }

    public void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for(int i=0; i<soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
}
