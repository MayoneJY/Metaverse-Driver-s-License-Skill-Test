using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private static readonly string CarSoundPref = "CarSoundPref";
    private static readonly string TTSSoundPref = "TTSSoundPref";
    private float backgroundFloat, soundEffectFloat, carSoundFloat, ttsSoundFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    public AudioSource[] carSoundAudio;
    public AudioSource[] ttsSoundAudio;
    void Awake()
    {
        ContinueSettings();
    }
     
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref); 
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        carSoundFloat = PlayerPrefs.GetFloat(CarSoundPref);
        ttsSoundFloat = PlayerPrefs.GetFloat(TTSSoundPref);
         
        backgroundAudio.volume = backgroundFloat;
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectFloat;
        }

        for (int i = 0; i < carSoundAudio.Length; i++)
        {
            carSoundAudio[i].volume = carSoundFloat;
        }
        for (int i = 0; i < ttsSoundAudio.Length; i++)
        {
            ttsSoundAudio[i].volume = ttsSoundFloat;
        }
    }

}
