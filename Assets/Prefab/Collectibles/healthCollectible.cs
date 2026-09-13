using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCollectible : MonoBehaviour
{
    [SerializeField] private string id;
    private bool collected;

    [SerializeField]private float healthValue;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [Header("Health Collect Sound")]
    [SerializeField] private AudioClip healthCollectSound;

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<health>().AddHealth(healthValue);
            SoundManager.instance.PlaySound(healthCollectSound);
            gameObject.SetActive(false);
            collected = true;
        }
    }

}
