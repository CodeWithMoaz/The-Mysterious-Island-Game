using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject Yuto;
    [SerializeField] private GameObject chest;
    private bool enemiesDead = false;
    private void Update()
    {
        foreach(var enemy in FindObjectsOfType<MeleeEnemy>())
        {
            if (enemy.GetComponent<health>().currentHealth > 0){
                enemiesDead=false;
                break;
            }
            else
            {
                enemiesDead = true;
            }

        }
      

        if (enemiesDead)
        {
             Yuto.SetActive(true);
            chest.GetComponent<ChestOpen>().opened = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
