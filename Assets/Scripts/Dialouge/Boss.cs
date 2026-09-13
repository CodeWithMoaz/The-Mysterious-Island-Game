using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
   
    public DialougeManager dialougeManager;
    // Start is called before the first frame update

    public KeyCode Q;

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
        if (this.GetComponent<Collider2D>().bounds.Contains(player.transform.position) && Input.GetKeyDown(Q))

        {

            

                    string[] dialogue = { "You think you have won?", "HAHA", "I have planted BOMBS everywhere in the island", "You think you could run?!", "Let me see you try ", "JUST COME WITH MEE AND DIEEEE!!" };
                    dialougeManager.SetSentences(dialogue);
                    dialougeManager.StartCoroutine(dialougeManager.TypeDialogue());

                }
            }
        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
          

            string[] dialogue = { "You think you have won?", "HAHA", "I have planted BOMBS everywhere in the island", "You think you could run?!", "Let me see you try ", "JUST COME WITH MEE AND DIEEEE!!" };
            dialougeManager.SetSentences(dialogue);
            dialougeManager.StartCoroutine(dialougeManager.TypeDialogue());

          
        }
    }
}

