using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextName : MonoBehaviour
{
    public Text textName;

    void Start()
    {
        textName.text = "" + ReadInput.input;
    }

   
}
