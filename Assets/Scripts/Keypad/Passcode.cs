using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    string Code = "4422";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;
    [SerializeField] private GameObject canvas;
    public GameObject door;
    public GameObject upedge;

    private bool OpenDoor = false;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip openDoorSound;

    private void Update()
    {
        if (OpenDoor == true)
        {
            
            if (door.transform.position.y >= upedge.transform.position.y)
            {
                OpenDoor = false;
            }
            else
            {
                door.transform.position += transform.up * Time.deltaTime * 1.2f;
            }
        }
    }
    public void CodeFunction(string Numbers) 
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("it's working");
            SoundManager.instance.PlaySound(openDoorSound);
            canvas.GetComponent<Canvas>().enabled = false;
            OpenDoor = true;

        }
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }

    public void Exit()
    {
        canvas.SetActive(false);
    }

 
}
