using System.Collections;
using UnityEngine;

public class Yuto3 : MonoBehaviour
{

    private bool opened =false;
    public DialougeManager dialougeManager;
    public KeyCode interactKey = KeyCode.Q; // Use lowercase 'q' to match Unity's keycodes

    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        // Check for interaction
        if (Input.GetKeyDown(interactKey) && IsPlayerInRange() && (opened == false))
        {
            opened = true;
            string[] dialogue = { "Well Done Agent-47!", "I have stolen this deadly weapon from the Terrorists.","Use it wisely,Goodluck and take care!"};
            dialougeManager.SetSentences(dialogue);
            StartCoroutine(dialougeManager.TypeDialogue());

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

