using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    private Coroutine dialogueText;
    public DialogueTrigger dialogueTrigger;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject dialoguePanel;
    public UnityEvent onEndDialogue;

    void Start()
    {
        //dialogueText = StartCoroutine(Type());
    }

    void Update()
    {
        //print(index + "   " + (sentences.Length - 1));

        if(Input.GetKeyDown(KeyCode.E) && dialogueTrigger.colliderCheck == true)
        {
            dialoguePanel.SetActive(true);
        }

        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void NextSentence()
    {
        //continueButton.SetActive(false);

        if(index == sentences.Length - 1)
        {
            GameObject.FindWithTag("Dialogue").gameObject.SetActive(false);
            //Debug.Log("Works");
            index = 0;
            onEndDialogue.Invoke();
            return;
        }
        
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            if(dialogueText != null)
            {
                StopCoroutine(dialogueText);
            }

            dialogueText = StartCoroutine(Type());
        }

        else
        {
            textDisplay.text = "";
            //onEndDialogue.Invoke();
        }
    }
}