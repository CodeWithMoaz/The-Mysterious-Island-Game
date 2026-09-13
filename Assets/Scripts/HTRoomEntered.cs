using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HTRoomEntered : MonoBehaviour
{

    private bool RoomEntered=false;
    public GameObject door;
    public GameObject downedge;
    [SerializeField] private GameObject canvas;
    [SerializeField] private AudioClip closeSound;




    private void Start()
    {

    }

    private void Update()
    {
        if (RoomEntered == true)
        {
            if (door.transform.position.y <= downedge.transform.position.y)
            {
                
            }
            else
            {
                door.transform.position += -(transform.up) * Time.deltaTime * 5f;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            canvas.SetActive(false);
            if (RoomEntered == false)
            {
                SoundManager.instance.PlaySound(closeSound);
            }
            RoomEntered = true;
            
    
           
       
        }
      
    }
}
