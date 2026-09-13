using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform fireGunPoint;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private GameObject[] bullets; // New array for bullets
    [SerializeField] private AudioClip arrowsound;
    [SerializeField] private AudioClip gunSound; // New sound for gun
    [SerializeField] private AudioClip outgunSound; // New sound for gun
    private Player playerMovement;
    private float coolDownTimer = Mathf.Infinity;

    [SerializeField] public int numOfArrows;
    [SerializeField] public int numOfBullets; // New variable for bullets


    //=========

    private void Start()
    {
        numOfArrows = Finish.NumOfArrows;
        numOfBullets = Finish.NumOfBullets;
    }

    private void Awake()
    {
        playerMovement = GetComponent<Player>();
    }

    private void Update()
    {
        
        coolDownTimer += Time.deltaTime;

        // Example: You can call Attack() when the player presses a key for shooting bullets
        if (Input.GetKeyDown(KeyCode.Space)) // Assuming Space key for shooting bullets
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (GetComponent<Player>().holdGun == true) {
            if (numOfBullets > 0 )
            {
                numOfBullets--;
                coolDownTimer = 0;
                SoundManager.instance.PlaySound(gunSound); // Play gun sound
                bullets[FindBullet()].transform.position = fireGunPoint.position;
                bullets[FindBullet()].GetComponent<ProjectileGun>().SetDirection(Mathf.Sign(transform.localScale.x));
            }
            else
            {
                SoundManager.instance.PlaySound(outgunSound); // Play gun sound
                Debug.Log("Out of Bullets!");
            }
        }
    }

    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private void ShootArrow()
    {
        if (numOfArrows > 0)
        {
            numOfArrows--;
            coolDownTimer = 0;
            SoundManager.instance.PlaySound(arrowsound);
            arrows[FindArrow()].transform.position = firePoint.position;
            arrows[FindArrow()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        else
        {
            Debug.Log("Not Enough Arrows!");
        }
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    public void AddArrows()
    {
        numOfArrows += 3;
    }
    public void AddBullets()
    {
        numOfBullets += 30;
    }
}

