using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TurnSignal : MonoBehaviour
{
    public Material m_Material_On;
    public Material m_Material_Off;
    public GameObject m_GameObject_Left;
    public GameObject m_GameObject_Right;
    public GameObject m_GameObject_Light_Left_Front;
    public GameObject m_GameObject_Light_Left_Rear;
    public GameObject m_GameObject_Light_Right_Front;
    public GameObject m_GameObject_Light_Right_Rear;
    private GameObject[] m_GameObject_Lights_Left;
    private GameObject[] m_GameObject_Lights_Right;
    private Renderer m_Renderer_Left;
    private Renderer m_Renderer_Right;
    [SerializeField] private GameObject m_GameObject_Left_Ui;
    [SerializeField] private GameObject m_GameObject_Right_Ui;

    // 출처 링크 : https://gongu.copyright.or.kr/gongu/wrt/wrt/view.do?wrtSn=13288073&menuNo=200026

    // <img id="wrtImg" src="https://gongu.copyright.or.kr/gongu/wrt/cmmn/wrtFileImageView.do?wrtSn=13288073&filePath=L2Rpc2sxL25ld2RhdGEvMjAyMS8wMS9DTFMxMDAwMi8xMzI4ODA3M19XUlRfMDFfQ0xTMTAwMDJfMjAyMTA5MDNfMQ==&thumbAt=Y&thumbSe=b_tbumb&wrtTy=10002">
    // <p style="font-size: 0.9rem;font-style: italic;">
    // <span>
    // title : <a href="https://gongu.copyright.or.kr/gongu/wrt/wrt/view.do?wrtSn=13288073&menuNo=200026"> 승합차_카니발_내부_방향지시등_비상등_Ambeo_ST_192</a>
    // authr : <a href="https://gongu.copyright.or.kr/gongu/wrt/wrt/view.do?wrtSn=13288073&menuNo=200026"> (재)전주정보문화산업진흥원</a>by
    // site : <a href="https://gongu.copyright.or.kr/gongu/main/main.do">공유마당 저작권 위원회</a></span> <br>
    // is licensed under
    // <img src="https://gongu.copyright.or.kr/static/gongu/img/common/img_license01.png" alt="KOGL 출처표시, 상업적, 비상업적 이용가능, 변형 등 2차적 저작물 작성 가능" class="img_cc">

    // </p>
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audio1;
    [SerializeField] private AudioClip _audio2;


    private float timer;
    private float waitingTime;
    public bool leftTurnSignal = false;
    public bool leftLightBool = false;
    public bool rightTurnSignal = false;
    public bool rightLightBool = false;
    public bool doubleTurnSignal = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 0.5f;
        m_Renderer_Left = m_GameObject_Left.GetComponent<Renderer>();
        m_Renderer_Right = m_GameObject_Right.GetComponent<Renderer>();
        m_GameObject_Lights_Left = new GameObject[] { m_GameObject_Light_Left_Front, m_GameObject_Light_Left_Rear};
        m_GameObject_Lights_Right = new GameObject[] { m_GameObject_Light_Right_Front, m_GameObject_Light_Right_Rear};
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            turnSignalOnOff("LEFT");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            turnSignalOnOff("RIGHT");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            turnSignalOnOff("DOUBLE");
        }
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            timer = 0;
            if (leftTurnSignal)
            {
                turnSignal(m_Renderer_Left, ref leftLightBool, m_GameObject_Lights_Left, m_GameObject_Left_Ui);
            }
            if (rightTurnSignal)
            {
                turnSignal(m_Renderer_Right, ref rightLightBool, m_GameObject_Lights_Right, m_GameObject_Right_Ui);
            }
            if (doubleTurnSignal)
            {
                turnSignal(m_Renderer_Right, ref rightLightBool, m_GameObject_Lights_Right, m_GameObject_Right_Ui);
                turnSignal(m_Renderer_Left, ref leftLightBool, m_GameObject_Lights_Left, m_GameObject_Left_Ui);
            }
        }
        

    }

    private void turnSignal(Renderer trunSignal, ref bool lightBool, GameObject[] _GameObject_Lights, GameObject _GameObject_Lights_Arrow)
    {

        if (lightBool)
        {
            trunSignal.material = m_Material_Off;
            lightBool = !lightBool;
            _GameObject_Lights[0].SetActive(false);
            _GameObject_Lights[1].SetActive(false);
            _GameObject_Lights_Arrow.SetActive(false);
            Debug.Log("Off");
            _audioSource.clip = _audio2;
            _audioSource.Play();
        }
        else
        {
            trunSignal.material = m_Material_On;
            lightBool = !lightBool;
            _GameObject_Lights[0].SetActive(true);
            _GameObject_Lights[1].SetActive(true);
            _GameObject_Lights_Arrow.SetActive(true);
            _audioSource.clip = _audio1;
            _audioSource.Play();
            Debug.Log("On");
        }
    }

    public void turnSignalOnOff(string signal)
    {
        //���� �������õ��� �������� �� �ٸ� �������õ��� ����
        //���� ���� �� �켱 ���� �������õ��� ��
        if(signal == "LEFT") leftTurnSignal = !leftTurnSignal;
        else leftTurnSignal = false;
        leftLightBool = false;
        if (signal == "RIGHT") rightTurnSignal = !rightTurnSignal;
        else rightTurnSignal = false;
        rightLightBool = false;
        if (signal == "DOUBLE") doubleTurnSignal = !doubleTurnSignal;
        else doubleTurnSignal = false;
        m_GameObject_Light_Left_Front.SetActive(false);
        m_GameObject_Light_Left_Rear.SetActive(false);
        m_GameObject_Light_Right_Front.SetActive(false);
        m_GameObject_Light_Right_Rear.SetActive(false);
        m_GameObject_Left_Ui.SetActive(false);
        m_GameObject_Right_Ui.SetActive(false);
        m_Renderer_Left.material = m_Material_Off;
        m_Renderer_Right.material = m_Material_Off;
    }
}
