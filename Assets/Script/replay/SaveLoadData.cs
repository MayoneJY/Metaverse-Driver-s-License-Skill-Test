using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ReplayData{
    public List<float> timeStamp;
    public List<Vector3> carBodyPosition;
    public List<Vector3> carBodyRotation;
    public List<Vector3> carWheelRotation;
    public List<Vector3> carSteerRotation;
}

public class SaveLoadData : MonoBehaviour
{
    [SerializeField] private GameObject _carBody;
    [SerializeField] private GameObject _carWheel;
    [SerializeField] private GameObject _carSteer;
    [SerializeField] private GameObject _topCamera;

    private List<float> _timeStamp = new List<float>();
    private List<Vector3> _carBodyPosition = new List<Vector3>();
    private List<Vector3> _carBodyRotation = new List<Vector3>();
    private List<Vector3> _carWheelRotation = new List<Vector3>();
    private List<Vector3> _carSteerRotation = new List<Vector3>();
    private inputManager IM;

    private bool _saveCheck = false;
    private bool _loadCheck = false;

    private ReplayData _loadRD;
    private int _loadCount = 0;

    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        IM = _carBody.GetComponent<inputManager>();

    }

    //json
    //car.body position, rotation
    //car.wheel rotation
    //car.steer rotation


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            //Save start
            _saveCheck = true;
            _time = 0.0f;
        }
        else if (Input.GetKeyDown(KeyCode.O)){
            //Save stop
            ReplayData _rd = new ReplayData();
            _rd.timeStamp = _timeStamp;
            _rd.carBodyPosition = _carBodyPosition;
            _rd.carBodyRotation = _carBodyRotation;
            _rd.carWheelRotation = _carWheelRotation;
            _rd.carSteerRotation = _carSteerRotation;
            string json = JsonUtility.ToJson(_rd);
            File.WriteAllText(Application.dataPath + "/data.json", json);
            Debug.Log("Replay Save!!");
            _saveCheck = false;
        }
        else if(Input.GetKeyDown(KeyCode.I)){
            _loadCheck = true;
            IM.replayCheck = true;
            _topCamera.SetActive(true);
            string json = File.ReadAllText(Application.dataPath + "/data.json");
            _loadRD = JsonUtility.FromJson<ReplayData>(json);
            _time = 0.0f;

        }


        if(_saveCheck){
            if(_time != 0.0f){
                //if (_time - _timeStamp[_timeStamp.Count - 1] > 0.1f){
                    
                _timeStamp.Add(_time);
                _carBodyPosition.Add(_carBody.transform.position);
                _carBodyRotation.Add(_carBody.transform.localEulerAngles);
                _carWheelRotation.Add(_carWheel.transform.localEulerAngles);
                _carSteerRotation.Add(_carSteer.transform.localEulerAngles);
                //}
            }
            else{

                _timeStamp.Add(_time);
                _carBodyPosition.Add(_carBody.transform.position);
                _carBodyRotation.Add(_carBody.transform.localEulerAngles);
                _carWheelRotation.Add(_carWheel.transform.localEulerAngles);
                _carSteerRotation.Add(_carSteer.transform.localEulerAngles);
            }
            _time += Time.deltaTime;
        }

        if(_loadCheck){
            if(_loadCount + 1 >= _loadRD.timeStamp.Count) {
                _loadCheck = false;
                IM.replayCheck = false;
                _topCamera.SetActive(false);
                Debug.Log("Load Succese!!");
            }
            if(_loadRD.timeStamp[_loadCount] < _time){
                //if(_loadCount == 0)
                //    _carBody.transform.position = Vector3.MoveTowards(_carBody.transform.position, _loadRD.carBodyPosition[_loadCount], Time.deltaTime * _loadRD.timeStamp[_loadCount]);
                //else
                //    _carBody.transform.position = Vector3.MoveTowards(_carBody.transform.position, _loadRD.carBodyPosition[_loadCount], Time.deltaTime * (_loadRD.timeStamp[_loadCount] - _loadRD.timeStamp[_loadCount - 1]));
                _carBody.transform.position = _loadRD.carBodyPosition[_loadCount];
                _carBody.transform.localEulerAngles = _loadRD.carBodyRotation[_loadCount];
                _carWheel.transform.localEulerAngles = _loadRD.carWheelRotation[_loadCount];
                _carSteer.transform.localEulerAngles = _loadRD.carSteerRotation[_loadCount];
                _loadCount++;
            }
            _time += Time.deltaTime;
        }

    }
    public void ShowReplay()
    {

        _loadCheck = true;
        IM.replayCheck = true;
        _topCamera.SetActive(true);
        string json = File.ReadAllText(Application.dataPath + "/data.json");
        _loadRD = JsonUtility.FromJson<ReplayData>(json);
        _time = 0.0f;
    }
}
