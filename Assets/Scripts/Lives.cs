using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private Text valueText;
    private void Update()
    {
        valueText.text = "" + FindObjectOfType<Player>().GetComponent<health>().lives;
    }
}
