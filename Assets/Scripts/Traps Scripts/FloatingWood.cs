using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingWood : MonoBehaviour
{
    private bool floating = false;
    public KeyCode E;
    [SerializeField] private GameObject player;
    public GameObject upedge;
    public GameObject woodPlatform;
    [SerializeField] private AudioClip waterSound;
    public GameObject popupMsg; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Collider2D>().bounds.Contains(player.transform.position))
        {
            popupMsg.SetActive(true);
        }
        else
        {
            popupMsg.SetActive(false);
        }

        if (this.GetComponent<Collider2D>().bounds.Contains(player.transform.position) && Input.GetKeyDown(E))

        {
            SoundManager.instance.PlaySound(waterSound);
            
            floating = true;
        }
            if (floating)
            {

                if (woodPlatform.transform.position.y >= upedge.transform.position.y)
                {
                    floating = false;
                }
                else
                {
                    woodPlatform.transform.position += (transform.up) * Time.deltaTime * 2f;
                }
            }
        
    }
   
}
