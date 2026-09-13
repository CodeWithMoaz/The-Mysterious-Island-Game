using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCanvas : MonoBehaviour
{
    static public bool comingFromLoad = false;
    static public bool thereisload;
    static public int index;

   

    public GameObject start;
  

    private void Update()
    {
       
        thereisload = DataPersistenceManager.thereIsLoad;
    }
    public void GoToIntroScene()
    {
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        this.gameObject.SetActive(false);
        start.SetActive(true);
    }

    public void BackToNewGame()
    {
        this.gameObject.SetActive(true);
        start.SetActive(false);
    }
    public void GoToFirstScene()
    {
        comingFromLoad =false;
        Time.timeScale = 1;
        Finish.NumOfArrows = 0;
        Finish.currentHealth = 10f;
        Finish.lives = 3f;
        SceneManager.LoadScene(2);
      
    }

    public void LoadLevel()
    {
        if (thereisload)
        {
            SceneManager.LoadScene(index);
            comingFromLoad = true;
        }
    }
    public void GoToStartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    } 
    //public void HTPStartScene()
    //{
    //    SceneManager.LoadScene(1);
    //}

    public void exit()
    {
        Application.Quit();
    }
    
    public void Deactivate()
    {
        this.gameObject.SetActive(false); 
    }
}
