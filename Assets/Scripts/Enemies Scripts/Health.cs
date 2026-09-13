using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 6;
    public int lives = 3;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    private bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    public int coinsCollected = 0;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if(immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }

        }

    }

    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerDuration + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {


        if (this.isImmune == false)
        {
            this.health = this.health - damage;

            if (health < 0)
            {
                this.health = 0;
            }

            if (this.lives > 0 && this.health == 0)
            {
                this.health = 6;
                this.lives--;
            }

            else if (this.lives == 0 && this.health == 0)
            {
                Debug.Log("GameOver");
                Destroy(this.gameObject);
            }

            Debug.Log("Player Health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());

        }
        PlayHitReaction();



    }
    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
}
