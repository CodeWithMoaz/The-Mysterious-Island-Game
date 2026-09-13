using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats 
{

    [SerializeField] private BarScript bar;

    [SerializeField] private float maxVal;
    public float MaxVal {
        get 
        { 
            return maxVal; 
        } 
        set
        {
            bar.MaxValue = value;
            this.maxVal = value; 
        } 
    }

    [SerializeField] private float curVal;

    public float CurVal
    {
        get
        {
            return curVal;
        }
        set
        {
            this.curVal = Mathf.Clamp(value,0,MaxVal);
            bar.Value = curVal;
            
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal; 
        this.CurVal=curVal;
    }

    
}
