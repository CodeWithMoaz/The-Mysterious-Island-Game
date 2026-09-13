using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liveCollectible : MonoBehaviour
{
    [SerializeField] private float liveValue;


    [Header("Health Collect Sound")]
    [SerializeField] private AudioClip livesCollectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<health>().Addlive(liveValue);
            SoundManager.instance.PlaySound(livesCollectSound);
            gameObject.SetActive(false);
        }
    }
}
