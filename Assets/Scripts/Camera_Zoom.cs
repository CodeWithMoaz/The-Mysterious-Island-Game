using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{

    private Camera Cam;

    //Key Camera Zoom
    public float ZommSpeed;
    public float minY;
    public float maxX;
    public float minX;
    public float maxY;

    private float dminY;
    private float dmaxX;
    private float dminX;
    private float dmaxY;

    public KeyCode Zbutton;

    //Mouse Camera Zoom
    //public float TargetZoom = 3;
    //private float ScrollData;
    //public float ZoomSpeedMouse = 3;


    void Start()
    {
        dminY=FindObjectOfType<Camera_Follow>().minY;
        dmaxX = FindObjectOfType<Camera_Follow>().maxX;
        dminX = FindObjectOfType<Camera_Follow>().minX;
        dmaxY = FindObjectOfType<Camera_Follow>().maxY;
        Cam = GetComponent<Camera>();
        //TargetZoom = Cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse Camera Zoom
        //ScrollData = Input.GetAxis("Mouse ScrollWheel");
        //TargetZoom = TargetZoom - ScrollData;
        //TargetZoom = Mathf.Clamp(TargetZoom, 3, 6);
        //Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeedMouse);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(Zbutton))
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 11, Time.deltaTime * ZommSpeed);
            FindObjectOfType<Camera_Follow>().minY = this.minY;
            FindObjectOfType<Camera_Follow>().maxX = this.maxX;
            FindObjectOfType<Camera_Follow>().minX = this.minX;
            FindObjectOfType<Camera_Follow>().maxY = this.maxY;
        }
        else
        {
            FindObjectOfType<Camera_Follow>().minY = dminY;
            FindObjectOfType<Camera_Follow>().maxX = dmaxX;
            FindObjectOfType<Camera_Follow>().minX = dminX;
            FindObjectOfType<Camera_Follow>().maxY = dmaxY;
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5, Time.deltaTime * ZommSpeed);
        }
    }
}