using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMainToInstruction : MonoBehaviour
{
    public GameObject instructionCanvas;
    public GameObject startCanvas;

    // Update is called once per frame
    public void OpenInstruct()
    {
        instructionCanvas.SetActive(true);
        startCanvas.SetActive(false);
    }
    public void CloseInstruct()
    {
        startCanvas.SetActive(true);
        instructionCanvas.SetActive(false);
    }
}
