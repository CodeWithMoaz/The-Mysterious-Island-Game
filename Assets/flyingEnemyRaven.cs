using UnityEngine;


public class flyingEnemyRaven : MonoBehaviour
{

    public Transform pointA; // Starting point
    public Transform pointB; // Ending point
    public float speed = 2f; // Movement speed
    public GameObject range; // Reference to the range GameObject
    public Transform player; // Reference to the player's Transform

    private Vector3 startPos;
    private Transform targetPoint;
    private bool followingPlayer = false; // Flag to indicate if the enemy is following the player

    void Start()
    {
        startPos = transform.position;
        targetPoint = pointB; // Start by moving towards point B
    }

    void Update()
    {
        if (range.GetComponent<BoxCollider2D>().bounds.Contains(player.position))
        {
            // Player is within range, start following the player
            followingPlayer = true;
            targetPoint = player;
            FlipToPlayer();
        }
        else
        {
            // Player is not within range
            followingPlayer = false;
        }

        // Update movement based on whether the enemy is following the player or not
        if (followingPlayer)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        }
        else
        {
            // Move towards the target point (either point A or point B)
            PatrolBetweenPoints();
        }
    }

    void PatrolBetweenPoints()
    {
        // Move towards the target point (either point A or point B)
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // If the enemy reaches the target point, switch direction
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            if (targetPoint == pointA)
            {
                targetPoint = pointB;
                Vector3 scale = transform.localScale;
                scale.x = 1;
                transform.localScale = scale;
            }
            else
            {
                targetPoint = pointA;
                Vector3 scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale;
            }
        }
    }


    void FlipToPlayer()
    {
        // Flip the enemy's scale to face the player
        if (player.position.x > transform.position.x)
        {
            // Player is on the right side of the enemy
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // Player is on the left side of the enemy
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && FindObjectOfType<Player>().GetComponent<health>().currentHealth>0)
        {
            collision.GetComponent<health>().TakeDamage(1);
        }

    }
}