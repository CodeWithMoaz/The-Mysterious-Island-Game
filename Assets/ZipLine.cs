using System.Collections;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    public Transform startPoint; // The starting point of the zip line
    public Transform endPoint; // The ending point of the zip line
    public float speed = 5f; // The speed at which the player moves along the zip line
    public GameObject Activation_Zone;
    public GameObject player;
    public Animator anime;
    public KeyCode E;

    private void Start()
    {
        anime = player.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Activation_Zone.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position) && Input.GetKeyDown(E))
        {
                player.GetComponent<Rigidbody2D>().gravityScale = 0f; // Disable gravity while on the zip line
                StartCoroutine(MovePlayer(player.GetComponent<Rigidbody2D>()));

        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
    //        if (rb != null)
    //        {
              
    //        }
    //    }
    //}

    private IEnumerator MovePlayer(Rigidbody2D rb)
    {
        anime.SetBool("Zipping",true);
        Vector2 startPosition = startPoint.position;
        float distance = Vector2.Distance(startPosition, endPoint.position);
        float time = distance / speed;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            rb.MovePosition(Vector2.Lerp(startPosition, endPoint.position, elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        anime.SetBool("Zipping", false);

        rb.gravityScale = 1f; // Re-enable gravity when the player reaches the end of the zip line
    }
}
