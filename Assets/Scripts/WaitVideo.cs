using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitVideo : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject video;

    [SerializeField] private AudioClip music; // New sound for gun
    void Start()
    {
        SoundManager.instance.PlaySound(music); // Play gun sound
        Invoke("Wait", 15f);
        Invoke("Destroy", 16f);
    }
    private void Wait()
    {
        gameOverCanvas.SetActive(true);
    }
    private void Destroy()
    {
        video.SetActive(false);
    }

   
}
