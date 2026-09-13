using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class FallingStep : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InvokeRepeating("NewSprite", .5f,0.5f);
        }
    }

    void NewSprite()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<SpriteRenderer>().color = new Color(.5f, 0, 0);
    }
 
}
