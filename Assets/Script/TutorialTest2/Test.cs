using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialougue
{
    [TextArea]
    public string dialogue;
}

public class Test : MonoBehaviour
{
    [SerializeField] private Image DialogueBox;
    [SerializeField] private Text txtDialogueBox;

    private bool isDialougue = false;
    private int count = 0;
    [SerializeField] private Dialogue[] dialogue; 

    public void ShowDialougue()
    {
        DialogueBox.gameObject.SetActive(true);
        txtDialogueBox.gameObject.SetActive(true);

        count = 0;
        isDialougue = true;
        NextDialouge();
    }

    private void NextDialouge()
    {
        txtDialogueBox.text = dialogue[count].dialogue;
        count++;
    }
    private void HideDialogue()
    {
        DialogueBox.gameObject.SetActive(false);
        txtDialogueBox.gameObject.SetActive(false);
        isDialougue = false;
    }

    void Update()
    {
        if (isDialougue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                    NextDialouge();
                else
                    HideDialogue();
            }
        }
    }

 
}
