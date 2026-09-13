using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSounds : MonoBehaviour
{

    [SerializeField] private GameObject[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { foreach (var sound in sounds)
            {
                sound.SetActive(false);
            } }
    }
}
