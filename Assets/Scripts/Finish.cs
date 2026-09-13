using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public static int NumOfArrows = 0;
    public static int NumOfBullets = 0;
    public static float currentHealth = 10f;
    public static float lives=3f;


 public Animator transition;
    public float transitionTime = 1f;   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            GoToCanvas.comingFromLoad = false;
            NumOfArrows = FindObjectOfType<Player>().GetComponent<PlayerAttack>().numOfArrows;
            NumOfBullets = FindObjectOfType<Player>().GetComponent <PlayerAttack>().numOfBullets;
            currentHealth = FindObjectOfType<Player>().GetComponent<health>().currentHealth;
            lives = FindObjectOfType<Player>().GetComponent<health>().lives;
            CompleteLevel();
        }
    }

    public void CompleteLevel()
    {
        StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadedLevel()
    {
        StartCoroutine(LoadLevel(GoToCanvas.index));
    }

 IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

}
