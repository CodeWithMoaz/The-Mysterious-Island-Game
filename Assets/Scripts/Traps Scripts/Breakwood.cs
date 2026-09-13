using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakwood : MonoBehaviour
{

    private bool woodIsHit1 = false;
    private bool woodIsHit2 = false;
    public GameObject Ball;
    public GameObject downedge;
    public GameObject upedge;
    public GameObject woodPlatform;
    public GameObject woodobject;
    [SerializeField] private AudioClip destroySound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (woodIsHit1)
        {
            if (Ball.transform.position.y <= downedge.transform.position.y)
            {
                woodIsHit1 = false;
            }
            else
            {
                Ball.transform.position += -(transform.up) * Time.deltaTime * 5f;
            }
        }


        if (woodIsHit2)
        {
            if (woodPlatform.transform.position.y >= upedge.transform.position.y)
            {
                woodIsHit2 = false;
            }
            else
            {
                woodPlatform.transform.position += (transform.up) * Time.deltaTime * 5f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            SoundManager.instance.PlaySound(destroySound);
            woodIsHit1 =true;
            woodIsHit2=true;
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled=false;
            woodobject.SetActive(false);
        }
    }

}
