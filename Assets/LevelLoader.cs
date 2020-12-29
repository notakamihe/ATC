using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public void RGame () {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadTheScene(0));
    }

    IEnumerator LoadTheScene (int idx)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(idx);
    }
}
