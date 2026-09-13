using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    [SerializeField] private health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;


    private void Start()
    {
        totalhealthBar.fillAmount = 10f;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth/10;
    }
}
