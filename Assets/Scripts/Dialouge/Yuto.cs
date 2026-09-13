using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuto : MonoBehaviour
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
            string[] dialogue = { "Oh, here you are again!", "I thought that you could use my help in opening that door.", "Well, it needs a pin code!", "Since you are here it means that you didn't find the hidden room yet.", "Now! Go search for it and Let's get out of here!!" };
            dialougeManager.SetSentences(dialogue);
            dialougeManager.StartCoroutine(dialougeManager.TypeDialogue());
            
        }
    }
    
}
