using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestStagePass : MonoBehaviour
{
    // Start is called before the first frame update
    public void Pass()
    {
        int currentStage = SceneManager.GetActiveScene().buildIndex;

        if(currentStage > PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentStage + 1);
        }

        Debug.Log("Stage" + PlayerPrefs.GetInt("levelsUnlocked") + "UNLOCKED");
    }
}
