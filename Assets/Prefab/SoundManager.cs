using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {  get; private set; }
    AudioSource playerSource;           //Reference to the generated player Audio Source
    public AudioClip[] walkStepClips;	//The footstep sound effects
    private AudioSource source;

    public static void PlayFootstepAudio()
    {
        //If there is no current AudioManager or the player source is already playing
        //a clip, exit 
        if (instance == null || instance.playerSource.isPlaying)
            
            return;
        
        //Pick a random footstep sound
        int index = Random.Range(0, instance.walkStepClips.Length);
        

        //Set the footstep clip and tell the source to play
        instance.playerSource.clip = instance.walkStepClips[index];
        instance.playerSource.Play();
    }
    private void Awake()
    {
        playerSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        instance = this;
        source = GetComponent<AudioSource>();

        //Keep this object even when we go to new scene 
        if(instance == null ) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }

        //Destroy Duplicate gameobjects
        else if(instance!=null && instance!=this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
 
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
    }
}
