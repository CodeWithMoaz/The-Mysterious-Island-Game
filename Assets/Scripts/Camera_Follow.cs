using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform Target;
    public float Cameraspeed;
    public float minX, maxX, minY, maxY;
    public float aboveYaxis;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * Cameraspeed);
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY) + aboveYaxis;
            if (Target.GetComponent<Player>().isFacingRight == true)
            {
                transform.position = new Vector3(ClampX + 0.3f, ClampY, -10f);
            }
            else
            {
                transform.position = new Vector3(ClampX - 0.3f, ClampY, -10f);
            }
        }
    }
}