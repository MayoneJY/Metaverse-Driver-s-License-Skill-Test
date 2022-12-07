using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject[] guardrail;
    [SerializeField] private GameObject mainUi;
    [SerializeField] private Exam exam;
    [SerializeField] private StartStage stage;
    //Defualt position rotation
    //-1.84, 1, -5.1, 0, -90, 0
    //Start
    //6, -1.84, 128.4, -5.1, 0, -90, 0
    //Warning
    //0, -1.84, 1, -5.1, 0, -90, 0
    //Hill
    //1, -1.84, 1, -35.12, 0, -90, 0
    //Turn
    //2, -1.84, 1, -83.02, 0, -90, 0
    //Traffic
    //3, -37.08, 1, 85.87, 0, 90, 0
    //TCourse
    //4, -37.08, 1, 34.5, 0, 90, 0
    //fast
    //5, -71.29, 1, 88.08, 0, 90, 0

    //VR -0.3899994 0 0.3 0 0 0
    //   -34.308 0 42.975 0 -90 0
    // select the HillCourse button
    public void SelectExamButton(string index)
    {
        GetComponent<WallManager>().enabled = false;
        string[] result2 = index.Split(',');
        float[] result = new float[7];
        for (int i = 0; i < result2.Length; i++)
            result[i] = float.Parse(result2[i]);

        for (int i = 0; i < guardrail.Length; i++)
        {
            if ((int) result[0] != i)
            {
                for (int j = 0; j < guardrail[i].transform.childCount; j++)
                {
                    if(guardrail[i].transform.GetChild(j).name == "Temp")
                    {
                        guardrail[i].transform.GetChild(j).gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                for (int j = 0; j < guardrail[i].transform.childCount; j++)
                {
                    if (guardrail[i].transform.GetChild(j).name == "Temp")
                    {
                        guardrail[i].transform.GetChild(j).gameObject.SetActive(true);
                    }
                }
            }
        }
        // PlayerPrefs is input int
        PlayerPrefs.SetInt("Exam", (int) result[0]);
        PlayerPrefs.SetFloat("ExamX", result[1]);
        PlayerPrefs.SetFloat("ExamY", result[2]);
        PlayerPrefs.SetFloat("ExamZ", result[3]);
        PlayerPrefs.SetFloat("ExamTX", result[4]);
        PlayerPrefs.SetFloat("ExamTY", result[5]);
        PlayerPrefs.SetFloat("ExamTZ", result[6]);
        // next Scene the Exam
        //SceneManager.LoadScene("Exam");

        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("ExamX"), PlayerPrefs.GetFloat("ExamY"), PlayerPrefs.GetFloat("ExamZ"));
        gameObject.transform.rotation = Quaternion.Euler(PlayerPrefs.GetFloat("ExamTX"), PlayerPrefs.GetFloat("ExamTY"), PlayerPrefs.GetFloat("ExamTZ"));

        GetComponent<WallManager>().enabled = true;
        //gameObject.SetActive(false);
        camera.transform.position = new Vector3(-0.3899994f, 0, 0.3f);
        camera.transform.localEulerAngles = new Vector3(0, 0, 0);
        mainUi.SetActive(false);
        exam._stageMode = true;
        if ((int)result[0] == 6)
        {
            stage.enabled = true;
        }

    }

    public void SelectStartStageButton()
    {
        SceneManager.LoadScene("StartStage");


    }
}
