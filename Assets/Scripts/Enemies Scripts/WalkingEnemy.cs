using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : Enemies
{
 
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Flip();    
        }

        else if (collision.tag == "Enemy")
        {
            Flip();
        }
        if (collision.tag == "Player")
        {
            FindObjectOfType<Player>().GetComponent<health>().TakeDamage(damage);
            Flip();

            
        }
        
    }

  
}
