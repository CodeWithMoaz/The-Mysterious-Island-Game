using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDetect : MonoBehaviour
{
    [Header("Spiketrap timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    [SerializeField] private float damage;
    private Animator anim;
   

    private bool triggered;
    private bool active;

    [Header("Spike Sound")]
    [SerializeField] private AudioClip spikeSound;

    private health playerHealth;
    private void Awake()
    {
        anim = GetComponent<Animator>();
       

    }

    private void Update()
    {
        if (playerHealth != null && active && playerHealth.currentHealth>0)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<health>();
            if (!triggered)
            {
                StartCoroutine(ActivateFireTrap());
            }
            if (active)
            {
                collision.GetComponent<health>().TakeDamage(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = null;
        }

    }

    private IEnumerator ActivateFireTrap()
    {
        //turn the sprite red to notify the player and the trigger the trap
        triggered = true;
       

        //Wait for delay , activate trap, turn on animation , return color back to normal
        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(spikeSound);
       

        active = true;
        anim.SetBool("activated", true);


        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
