using System.Collections;
using UnityEngine;

public class Yuto2 : MonoBehaviour
{
    private bool opened = false;
    public DialougeManager dialogueManager;
    public KeyCode interactKey = KeyCode.Q; // Use lowercase 'q' to match Unity's keycodes

    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        // Check for interaction
        if (Input.GetKeyDown(interactKey) && IsPlayerInRange() && (opened == false))
        {
            opened = true;
            string[] dialogue = { "Nice to meet you again!", "Well, looks like you are a bit confused about which path to take", "So, keep your head up.", "Good luck my friend." };
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
