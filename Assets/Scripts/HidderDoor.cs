using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidderDoor : MonoBehaviour
{
    [SerializeField] private GameObject room;
    [SerializeField] private BoxCollider2D bx;

    [SerializeField] private AudioClip destroySound;
    void Awake()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            Destroy(gameObject);
            room.SetActive(true);
            SoundManager.instance.PlaySound(destroySound);
            bx.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    

}
