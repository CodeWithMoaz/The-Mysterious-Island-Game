using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YutoIntro : MonoBehaviour
{
    public DialougeManager dialougeManager;
    // Start is called before the first frame update

    public KeyCode Q;
    private bool opened = false;
    [SerializeField] private GameObject player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }


    void Check()
    {
        if (this.GetComponent<Collider2D>().bounds.Contains(player.transform.position) && Input.GetKeyDown(Q) && (opened == false))

        {
            opened = true;
            string[] dialogue = { "Hey, my name is Yuto,", "I was lost in the events of the war.", "I have been here for more than 5 years, probably assumed dead.", "You know, this island is cursed.", "There are a lot of traps that I am going to guide you to pass them, but...", "The Seraphites are real!", "Also, there are wild people who live in a castle located on the island..","So take care; they are unfriendly." };
            dialougeManager.SetSentences(dialogue);
            dialougeManager.StartCoroutine(dialougeManager.TypeDialogue());

        }
    } 
}
