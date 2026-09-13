using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTRoom : MonoBehaviour
{
    private Camera mainCamera;
    public float cameraSize;
    public float speed = 5f;
    public Vector3 cameraPosition;


    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            mainCamera.GetComponent<Camera_Follow>().enabled = false;
            mainCamera.GetComponent<Camera_Zoom>().enabled = false;

          
            
                mainCamera.orthographicSize = cameraSize;
                mainCamera.transform.position = cameraPosition;
            

        }
    }
}
