using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public KeyCode E;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject player;



    private void Update()
    {
        Check();
    }


    void Check()
    {
        
        if (this.GetComponent<BoxCollider2D>().bounds.Contains(player.GetComponent<BoxCollider2D>().transform.position) && Input.GetKeyDown(E))

        {
            Debug.Log("Open Keypad");
            canvas.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Open Keypad");
            canvas.SetActive(true);
        }
    }
}
