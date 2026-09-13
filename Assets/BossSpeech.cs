using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpeech : MonoBehaviour
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
            string[] dialogue = { "Finally we meet.", "You have caused me a lot of trouble.", "Time to finish you!" };
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