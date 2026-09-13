using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollector : MonoBehaviour
{
    [SerializeField] private string id;
    private bool collected;

    

    [Header("Arrow Collect Sound")]
    [SerializeField] private AudioClip arrowCollectSound;

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<PlayerAttack>().AddArrows();
            SoundManager.instance.PlaySound(arrowCollectSound);
            gameObject.SetActive(false);
            collected = true;
        }
    }
}
