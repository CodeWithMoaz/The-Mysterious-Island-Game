using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollector : MonoBehaviour
{

    [Header("Arrow Collect Sound")]
    [SerializeField] private AudioClip ammoCollectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<PlayerAttack>().AddBullets();
            SoundManager.instance.PlaySound(ammoCollectSound);
            gameObject.SetActive(false);
        }
    }
}
