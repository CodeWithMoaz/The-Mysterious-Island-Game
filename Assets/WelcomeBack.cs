using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeBack : MonoBehaviour
{
    public GameObject welcomeBack;

    public void Welcome()
    {
        if (GoToCanvas.comingFromLoad)
        {
            welcomeBack.SetActive(true);
            GoToCanvas.comingFromLoad = false;
        }
    }


    void Update()
    {
        Welcome();
    }
}
