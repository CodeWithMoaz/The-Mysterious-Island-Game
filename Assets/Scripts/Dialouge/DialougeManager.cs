using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialogueSentences;
    private int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject dialogueBox;
    public Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator TypeDialogue()
    {
        dialogueBox.SetActive(true);
        playerRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        foreach(char c in dialogueSentences[index].ToCharArray())
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(typingSpeed);

            if(textDisplay.text == dialogueSentences[index])
            {
                continueButton.SetActive(true);

            }
        }
    }
    public void SetSentences(string[] sentences)
    {
        this.dialogueSentences = sentences;
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < dialogueSentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.dialogueSentences = null;
            index = 0;
            playerRB.constraints = RigidbodyConstraints2D.None;
            playerRB.constraints = RigidbodyConstraints2D.FreezeRotation; ;

        }
    }

}
