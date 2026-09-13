using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNumber : MonoBehaviour
{
    [SerializeField]
    private Text valueText;
    private void Update()
    {
        valueText.text = "X " + FindObjectOfType<PlayerAttack>().numOfBullets;
    }
}
