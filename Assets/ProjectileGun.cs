using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifeTime;
    private BoxCollider2D boxCollider;


    private void Awake()
    {

        boxCollider = GetComponent<BoxCollider2D>();
    }



    private void Update()
    {
        if (hit) { return; }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 1)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        if(collision.tag == "Enemy" && collision.name == "Boss")
        {
            if(collision.GetComponent<DeathstrokeBoss>().talking ==false)
            {
                collision.GetComponent<health>().TakeDamage(2);
            }
        }
        else if (collision.tag == "Enemy")
        {
            collision.GetComponent<health>().TakeDamage(2);
        }

        if (collision)
        {
            Deactivate();
        }
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }



    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
