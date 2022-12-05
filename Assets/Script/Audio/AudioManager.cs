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
    public Slider backgroundSlider, soundEffectSlider, carSoundSlider, ttsSoundSlider; 
    private float backgroundFloat, soundEffectFloat, carSoundFloat, ttsSoundFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    public AudioSource[] carSoundAudio;
    public AudioSource[] ttsSoundAudio;

    static public AudioManager instance; 

    private void Awake()  
    {
       
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
            
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
             
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectSlider.value = soundEffectFloat;

            carSoundFloat = PlayerPrefs.GetFloat(CarSoundPref);
            carSoundSlider.value = carSoundFloat;

            ttsSoundFloat = PlayerPrefs.GetFloat(TTSSoundPref);
            ttsSoundSlider.value = ttsSoundFloat;
        }
        catch (System.Exception e)
        {
            Debug.Log("사운드 세팅 초기화..");
            backgroundFloat = .125f;
            soundEffectFloat = .75f;
            carSoundFloat = .75f;
            ttsSoundFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value = soundEffectFloat;
            carSoundSlider.value = soundEffectFloat;
            ttsSoundSlider.value = ttsSoundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetFloat(CarSoundPref, carSoundFloat);
            PlayerPrefs.SetFloat(TTSSoundPref, ttsSoundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectSlider.value);
        PlayerPrefs.SetFloat(CarSoundPref, carSoundSlider.value);
        PlayerPrefs.SetFloat(TTSSoundPref, ttsSoundSlider.value);
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
        backgroundAudio.volume = backgroundSlider.value;
        for(int i =0; i<soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectSlider.value;
        }
        backgroundAudio.volume = backgroundSlider.value;
        for (int i = 0; i < carSoundAudio.Length; i++)
        {
            carSoundAudio[i].volume = carSoundSlider.value;
        }      
        for (int i = 0; i < ttsSoundAudio.Length; i++)
        {
            ttsSoundAudio[i].volume = ttsSoundSlider.value;
        }
    }

    
    }
