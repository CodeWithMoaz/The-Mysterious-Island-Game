using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spikehead : EnemyDamage
{

    [Header("SpikeHead Attributes: ")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;
    private Rigidbody2D rb;


    [Header("Spike Sound")]
    [SerializeField] private AudioClip spikeSound;




    private void OnEnable()
    {
       
        Stop();
    }


    private void Update()
    {
        //Moving spikehead to destenation:
        if (attacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay) {
                CheckForPlayer();
            }
        }

    }

    private void CheckForPlayer()
    {
        CalculateDirection();


        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null )
            {
                transform.GetComponent<Rigidbody2D>().isKinematic = true;
                transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                rb=transform.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                //SoundManager.instance.PlaySound(spikeSound);
                // rb.constraints = RigidbodyConstraints2D.FreezePositionY;

            }

        }
    }

    private void CalculateDirection()
    {
        //directions[0] = transform.right * range;  //Right
        //directions[1] = -transform.right * range; //Left
        //directions[2] = transform.up * range;     //Up
        directions[3] = transform.up * range;     //Down
    }

    private void Stop()
    {
        destination = transform.position;
        attacking = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        base.OnTriggerEnter2D(collision);
        

    }

}
