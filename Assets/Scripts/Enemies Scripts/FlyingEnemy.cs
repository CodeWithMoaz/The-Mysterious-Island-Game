using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemies
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float amplitude;
    public float pos;

    private Vector3 temp_pos;


    // Start is called before the first frame update
    void Start()
    {
        temp_pos = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isFacingRight)
        {
            temp_pos.x += HorizontalSpeed * Time.deltaTime;
            temp_pos.y = (Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude) - pos;
            transform.position = temp_pos;
        }
        else
        {
            temp_pos.x -= HorizontalSpeed * Time.deltaTime;
            temp_pos.y = (Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude) - pos;
            transform.position = temp_pos;
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
        if (collision.tag == "Player" && FindObjectOfType<Player>().GetComponent<health>().currentHealth > 0)
        {
            collision.GetComponent<health>().TakeDamage(1);


            Flip();
        }


    }
   
}
