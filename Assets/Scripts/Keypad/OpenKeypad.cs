using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeypad : MonoBehaviour
{
    public KeyCode E;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject player;



    private void Update()
    {
        if (this.GetComponent<Collider2D>().bounds.Contains(player.transform.position) && Input.GetKeyDown(E))

        {
            Debug.Log("Open Keypad");
            canvas.SetActive(true);
        }
    }


    
    
}
