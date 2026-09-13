using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLimitProjectile : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private AudioClip arrowsound;
    private Player playerMovement;
    private float coolDownTimer = Mathf.Infinity;

    [SerializeField]private int numOfArrows ;

    private void Awake()
    {
        playerMovement = GetComponent<Player>();

    }

    private void Update()
    {

        coolDownTimer += Time.deltaTime;
    }
    private void Attack1()
    {
        if (numOfArrows > 0)
        {
            numOfArrows--;
            coolDownTimer = 0;
            SoundManager.instance.PlaySound(arrowsound);
            arrows[FindFireball()].transform.position = firePoint.position;
            arrows[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        else
        {
            Debug.Log("Not Enough Arrows!");
        }
    }

    private int FindFireball()
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

}
