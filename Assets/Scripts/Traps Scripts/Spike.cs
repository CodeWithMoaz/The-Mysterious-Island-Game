using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<health>().currentHealth!=0)
        {

            collision.GetComponent<health>().TakeDamage(damage);
        }
    }



}
