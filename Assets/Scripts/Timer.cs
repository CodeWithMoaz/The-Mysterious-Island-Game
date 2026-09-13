using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject gameOver;
    public float _timer;
    private float ttimer;
    private int _time;
    public Text _timer_text;
    // Start is called before the first frame update
    void Start()
    {
        ttimer = _timer;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        _time = (int)_timer;
        _timer_text.text="" + _time.ToString();

        if(_timer <= 0 && FindObjectOfType<Player>().GetComponent<health>().lives >-1)
        {
            _timer = 0;
            FindObjectOfType<Player>().transform.position=gameOver.transform.position;
            FindObjectOfType<Player>().GetComponent<health>().lives--;
            _timer = ttimer;
            _timer_text.text = "" + _time.ToString();

        }
        else if(_timer<=0)
        {
            _timer = 0;
        }
    }
}
