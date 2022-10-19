using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BtnEvent : MonoBehaviour
{
    int levelat; //현재 스테이지 번호, 오픈한 스테이지 번호
    public GameObject stageNumObject;

    void Start()
    {
        Button[] stages = stageNumObject.GetComponentsInChildren<Button>();

        levelat = PlayerPrefs.GetInt("levelReached");
        print(levelat);
        for (int i = levelat + 1; i < stages.Length; i++)
        {
            stages[i].interactable = false;
        }
    }

// Update is called once per frame
void Update()
    {
        
    }
}
