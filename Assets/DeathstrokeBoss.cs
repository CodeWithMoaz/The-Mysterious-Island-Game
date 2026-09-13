using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathstrokeBoss : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject player;
    public GameObject finishHim;

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Parameters")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Attack Sound")]
    [SerializeField] private AudioClip attackSound;

    //References
    private Animator anim;
    private health playerHealth;
    private EnemyPatrol enemyPatrol;

    public bool talking = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        if (HealthPercentage() < 3)
        {
            talking = true;
            LastSpeech();
        }
        
        cooldownTimer += Time.deltaTime;


        //Attack only when player in sight
        if (PlayerInSight() && (talking==false))
        {

            if (cooldownTimer >= attackCooldown )
            {
                cooldownTimer = 0;

                if (HealthPercentage() >= 75)
                {
                    anim.SetTrigger("Attack1");
                }
                else if(HealthPercentage() >= 35)
                {
                    damage = 3;
                    anim.SetTrigger("Attack2");
                }
                else
                {
                    damage = 5;
                    anim.SetTrigger("Attack3");
                }


            }
        }
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

    }
    float HealthPercentage()
    {
        float healthpercentage = (GetComponent<health>().currentHealth/GetComponent<health>().startingHealth) * 100;
        return healthpercentage;
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {

            playerHealth = hit.transform.GetComponent<health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight() && playerHealth.currentHealth > 0)
        {
            SoundManager.instance.PlaySound(attackSound);
            playerHealth.TakeDamage(damage);
        }
    }
    public void LastSpeech()
    {
        player.GetComponent<Player>().holdGun = false;
        player.GetComponent<Player>().holdArrow = false;
        dialogue.SetActive(true);
        finishHim.SetActive(true);
    }
}