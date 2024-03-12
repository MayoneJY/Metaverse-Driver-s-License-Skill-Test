using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private static readonly string CarSoundPref = "CarSoundPref";
    private static readonly string TTSSoundPref = "TTSSoundPref";
    private int firstPlayInt;
    public Slider[] backgroundSlider, soundEffectSlider, carSoundSlider, ttsSoundSlider; 
    private float backgroundFloat, soundEffectFloat, carSoundFloat, ttsSoundFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    public AudioSource[] carSoundAudio;
    public AudioSource[] ttsSoundAudio;

    static public AudioManager instance; 

    private void Awake()  
    {
        ContinueSettings();

        // if (instance != null)  
        // {
        //     Destroy(this.gameObject);
        //     instance = this;
        //     DontDestroyOnLoad(gameObject);

        // }
        // else
        //     instance = this;
        //     DontDestroyOnLoad(gameObject);

    }
    
    
    void Start()
    {
        try{
            Debug.Log(PlayerPrefs.GetFloat(BackgroundPref));
            
            for(int i = 0; i < backgroundSlider.Length; i++)
            {
                backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
                backgroundSlider[i].value = backgroundFloat;

                soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
                soundEffectSlider[i].value = soundEffectFloat;

                carSoundFloat = PlayerPrefs.GetFloat(CarSoundPref);
                carSoundSlider[i].value = carSoundFloat;

                ttsSoundFloat = PlayerPrefs.GetFloat(TTSSoundPref);
                ttsSoundSlider[i].value = ttsSoundFloat;
            }
             
        }
        catch (System.Exception e)
        {
            Debug.Log("사운드 세팅 초기화..");
            backgroundFloat = .125f;
            soundEffectFloat = .75f;
            carSoundFloat = .75f;
            ttsSoundFloat = .75f;
            for (int i = 0; i < backgroundSlider.Length; i++)
            {
                backgroundSlider[i].value = backgroundFloat;
                soundEffectSlider[i].value = soundEffectFloat;
                carSoundSlider[i].value = soundEffectFloat;
                ttsSoundSlider[i].value = ttsSoundFloat;
            }
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetFloat(CarSoundPref, carSoundFloat);
            PlayerPrefs.SetFloat(TTSSoundPref, ttsSoundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider[0].value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectSlider[0].value);
        PlayerPrefs.SetFloat(CarSoundPref, carSoundSlider[0].value);
        PlayerPrefs.SetFloat(TTSSoundPref, ttsSoundSlider[0].value);
        UpdateSound();
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        for (int j = 0; j < backgroundSlider.Length; j++)
        {
            backgroundAudio.volume = backgroundSlider[j].value;
            for (int i = 0; i < soundEffectsAudio.Length; i++)
            {
                soundEffectsAudio[i].volume = soundEffectSlider[j].value;
            }
            backgroundAudio.volume = backgroundSlider[j].value;
            for (int i = 0; i < carSoundAudio.Length; i++)
            {
                carSoundAudio[i].volume = carSoundSlider[j].value;
            }
            for (int i = 0; i < ttsSoundAudio.Length; i++)
            {
                ttsSoundAudio[i].volume = ttsSoundSlider[j].value;
            }
        }
    }

     private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        carSoundFloat = PlayerPrefs.GetFloat(CarSoundPref);
        ttsSoundFloat = PlayerPrefs.GetFloat(TTSSoundPref);
         
        backgroundAudio.volume = backgroundFloat;
        for (int i = 0; i < backgroundSlider.Length; i++)
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

        for (int i = 0; i < backgroundSlider.Length; i++)
        {
            backgroundSlider[i].value = backgroundFloat;
            soundEffectSlider[i].value = soundEffectFloat;
            carSoundSlider[i].value = soundEffectFloat;
            ttsSoundSlider[i].value = ttsSoundFloat;
        }
    }
    
    }
