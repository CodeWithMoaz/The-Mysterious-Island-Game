using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBox : MonoBehaviour
{
    public GameObject Boss;
    private void Update()
    {
        if( Boss.GetComponent<health>().currentHealth == 0) 
        { 
            this.GetComponent<BoxCollider2D>().enabled = (false);
        }
    }
}

