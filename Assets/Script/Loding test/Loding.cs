using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loding : MonoBehaviour
{
    static string nextScene;
    [SerializeField]
    Image progresbar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loding");
    }

     void Start()
    {
        StartCoroutine(LoadSceneProcess());   
    }
    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f; 
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progresbar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progresbar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(progresbar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
   
}
