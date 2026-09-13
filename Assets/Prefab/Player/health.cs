using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class health : MonoBehaviour 
{

    
    [Header ("Health")]
    
    [SerializeField]public float startingHealth;
    [SerializeField]public float lives;

    private Animator anim;
    public float currentHealth { get; private set; }
    public bool dead;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    [Header("Components")]
    [SerializeField] public Behaviour[] components;
    private bool invulnerable;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    [Header("Hurt Sound")]
    [SerializeField] private AudioClip hurtSound;




 
    private void Start()
    {
        
            FindObjectOfType<Player>().GetComponent<health>().currentHealth = Finish.currentHealth;
            FindObjectOfType<Player>().GetComponent<health>().lives = Finish.lives;
        
    }

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        

        if ( dead == true)
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            foreach (Behaviour component in components)
            {
                component.enabled = false;
                
            }
           dead = false;
            
        }   
    }

    public void Restart()
    {
        currentHealth = startingHealth;
       
        foreach (Behaviour component in components)
        {
            component.enabled = true;

        }
       
    }


    public void TakeDamage(float _damage)
    {
        
        if(invulnerable)
        {
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");

            SoundManager.instance.PlaySound(hurtSound);
            StartCoroutine(Invunerability());

            
        }
        else
        {
            if (!dead)
            {

                anim.SetTrigger("Die");

                
                lives--;

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                {
                    component.enabled = false;

                }

                dead = true;
                SoundManager.instance.PlaySound(deathSound);
                
                //public IEnumerator WaitingIdle()
                //{

                //    yield return new WaitForSeconds(5);

                //}
                
            }

        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    
    public void Addlive(float _value)
    {
        lives = Mathf.Clamp(lives + _value, 0, 100);
    }


    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(7,8,true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes));
            spriteRenderer.color=Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));

        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public IEnumerator WaitingIdle()
    {

        yield return new WaitForSeconds(2);

    }
}
