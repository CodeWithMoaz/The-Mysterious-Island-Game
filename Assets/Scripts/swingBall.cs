using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingBall : MonoBehaviour
{
    [Header("Swing Sound")]
    [SerializeField] private AudioClip swingSound;

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("delay");
        
    }

    private IEnumerator delay()
    {
        SoundManager.instance.PlaySound(swingSound);
        yield return new WaitForSeconds(2);
        SoundManager.instance.PlaySound(swingSound);
        yield return new WaitForSeconds(2);
    }

}
