using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyhealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;

   
    public void UpdateHealthBar()
    {
        
        slider.value = GetComponentInParent<health>().currentHealth / GetComponentInParent<health>().startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }
}
