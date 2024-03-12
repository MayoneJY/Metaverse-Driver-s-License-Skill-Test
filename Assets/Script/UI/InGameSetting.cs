using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSetting : MonoBehaviour
{
    [SerializeField] private GameObject _oculusObject;
    [SerializeField] private GameObject _carObject;
    [SerializeField] private Exam _exam;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject mainUi;
    [SerializeField] private GameObject gameUi;
    [SerializeField] private StartStage stage;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private HandController _handController;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject caption;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer.SetActive(false);
        caption.SetActive(false);
    }


    public void clickUpButton(){
        var po = _oculusObject.transform.position;
        _oculusObject.transform.position = new Vector3(po.x, po.y + 0.01f, po.z);
    }

    public void clickDownButton(){
        var po = _oculusObject.transform.position;
        _oculusObject.transform.position = new Vector3(po.x, po.y - 0.01f, po.z);
    }

    public void clickRespawnButton(){
        _carObject.transform.position = new Vector3(0, 0, 0);
        _carObject.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void clickQuitButton(){
        // Game Exit
        Application.Quit();
    }

    public void clickRestart()
    {
        _carObject.transform.position = new Vector3(0, 0, 0);
        _carObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        if(PlayerPrefs.GetInt("Exam") == 6)
        {
            stage.enabled = false;
            stage.enabled = true;

        }
        _exam.ResetItem();
    }

    public void clickMainMenu()
    {
        clickRespawnButton();
        gameObject.transform.position = new Vector3(-1.84f, 1, -5.1f);
        gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        _oculusObject.transform.position = new Vector3(-34.308f, 0, 42.975f);
        _oculusObject.transform.localEulerAngles = new Vector3(0, -90, 0);
        stage.enabled = false;
        _exam.enabled = false;
        mainUi.SetActive(true);
        gameUi.SetActive(false);
        timer.SetActive(false);
        caption.SetActive(false);
        _audioSource.Play();
        _handController.ResetGear();
        _exam.ResetItem();

    }
}
