using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public KeyCode E;
    public GameObject upedge;
    public GameObject boxcolliders;
    public GameObject elevator;
    public Transform player;
    public Animator anime;
    public bool opened;

    [SerializeField] private AudioClip elevatorsound; // New sound for gun
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(E) && GetComponent<BoxCollider2D>().bounds.Contains(player.position) && elevator.transform.position.y <= upedge.transform.position.y && (!opened))
        {
            SoundManager.instance.PlaySound(elevatorsound); // Play gun sound
            boxcolliders.SetActive(true);
            opened = true;
        }

        if (opened && elevator.transform.position.y <= upedge.transform.position.y)
        {
            

            elevator.transform.position += (transform.up) * Time.deltaTime * 5f;

        }

        anime.SetBool("opened", opened);
    }
}
