using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public GameObject CurrentCheckPoint;
    public GameObject Player;
    //public Transform enemy;
   
    private bool spawned = false;

    public void Update()
    {
        if (FindObjectOfType<Player>().GetComponent<health>().currentHealth == 0)
        {
            Invoke("RespawnPlayer", 2);
            FindObjectOfType<Player>().GetComponent<health>().dead=false;
        }

      
    }

   // public void RespawnEnemy()
   // {
    //    if (spawned == false)
     //   {
     //       Instantiate(enemy, transform.position, transform.rotation);
     //       spawned = true;
     //   }
   // }

    public void RespawnPlayer()
    {
        if (FindObjectOfType<Player>().GetComponent<health>().currentHealth == 0)
        {

            FindObjectOfType<Player>().GetComponent<health>().Restart();
            Player.transform.position = CurrentCheckPoint.transform.position;
        }
    }


   
}