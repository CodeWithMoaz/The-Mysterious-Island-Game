using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollector : MonoBehaviour
{
    public GameObject bulletsCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bulletsCanvas.SetActive(true);
            Player.guncollected = true;
            this.gameObject.SetActive(false);
        }
    }
}
