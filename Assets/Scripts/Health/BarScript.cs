using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    
    [SerializeField]
    private float lerpSpeed;

    [SerializeField] private health playerHealth;


    [SerializeField]
    private Image content;
    
    [SerializeField]
    private Text valueText;

    public float MaxValue { get; set; }
    public float Value 
    {
        set
        {
            string[] temp = valueText.text.Split(':');
            valueText.text = temp[0] + ":  " + value;
            fillAmount = Map(value,0,MaxValue,0,1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount,playerHealth.currentHealth,Time.deltaTime*lerpSpeed);
        }
    }

    private float Map(float val,float inMin,float inMax, float outMin, float outMax)
    {
        return (val - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

        // (80 - 0) * (1 - 0) / (100-0) + 0
        // (80*1) /100 = 0.8

    }

}
