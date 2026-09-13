using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private Animator anim;
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject ammo;
    public bool opened;

    private void Start()
    {
        opened = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (opened && Player.guncollected==false)
        {
            gun.SetActive(true);
            ammo.SetActive(true);
        }

        anim.SetBool("Opened",opened);
    }


   
    
}
