using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] private GameObject Lines;
    [SerializeField] private GameObject Canvas;


    public void ShowLines()
    {
        Lines.SetActive(true);
    }
    public void Close()
    {
        Canvas.SetActive(false);
    }
}
