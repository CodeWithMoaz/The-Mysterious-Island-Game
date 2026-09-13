using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {

            FindObjectOfType<Player>().GetComponent<health>().TakeDamage(damage);


        }

    }
}
