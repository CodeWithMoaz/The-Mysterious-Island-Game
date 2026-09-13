using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinalSpeech : MonoBehaviour
{
    public DialougeManager dialogueManager;
    private bool opened = false;
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        
        // Check for interaction
        if (IsPlayerInRange() && (opened == false))
        {
            opened = true;
            string[] dialogue = { "Do you think you have won??","I have planted bombs all over the island.","Join me in hell!", "HAHAHAHAA" };
            dialogueManager.SetSentences(dialogue);
            StartCoroutine(dialogueManager.TypeDialogue());

        }
    }

    bool IsPlayerInRange()
    {

        // Check if the player is within the collider bounds
        if (GetComponent<Collider2D>().bounds.Contains(player.transform.position))
        {

            return true;
        }
        return false;
    }
}
