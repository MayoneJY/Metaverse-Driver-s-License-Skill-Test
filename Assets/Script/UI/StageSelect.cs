using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{

    // select the HillCourse button
    public void SelectExamButton(int index)
    {
        // PlayerPrefs is input int
        PlayerPrefs.SetInt("Exam", index);
        // next Scene the Exam
        SceneManager.LoadScene("Exam");


    }
}
