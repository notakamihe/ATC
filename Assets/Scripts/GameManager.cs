using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public bool gameIsWon = false;
    public float delay = 1;

    void Start ()
    {
        Debug.Log("GAME STARTED");
    }

    public void EndGame () {
        if (gameHasEnded == false) {
            FindObjectOfType<AudioManager>().Stop("GameMusic");
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("RestartGame", delay);
        }
    }

    public void EndGameWin () {
        if (gameIsWon == false)
        {
            FindObjectOfType<AudioManager>().Stop("GameMusic");
            FindObjectOfType<AudioManager>().Play("VictorySound");
            gameIsWon = true;
            Debug.Log("GAME WON");
            Invoke("WinGame", 2);
        }
    }

    void RestartGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void WinGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
