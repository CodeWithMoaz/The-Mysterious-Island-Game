using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public bool running = false;
    public float movespeed;
    public bool isFacingRight = false;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float range;

    [Header("Player Parameters")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Attack only when player in sight
        if (PlayerInSight())
        {
            running = true;
            if (!isFacingRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            running = false;

            // If player is behind, flip the enemy
            if (PlayerBehind())
            {
                Flip();
            }
        }

        anim.SetBool("Run", running);
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private bool PlayerBehind()
    {
        // Cast a raycast backwards to check if the player is behind

        if (isFacingRight)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, playerLayer);
            return hit.collider != null;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, playerLayer);
            return hit.collider != null;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        // Draw box for player detection range
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

        // Draw line for player detection behind the enemy
        if (isFacingRight)
        {
            Gizmos.DrawLine(transform.position, transform.position + Vector3.left * range);
        }
        else
        {
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * range);
        }
    }
}