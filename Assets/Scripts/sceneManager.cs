using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public Animator transition;

    public void MainMenu()
    {
        UIManagerMenu.callForName.saveCharName();
        SceneManager.LoadScene("Menu_Start", LoadSceneMode.Single);
    }
    public void Outside()
    {
        levelTransitionStart();
        SceneManager.LoadScene("Outside", LoadSceneMode.Single);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void levelTransitionStart()
    {
          transition.SetTrigger("Start");
    }

    public void levelTransitionEnd()
    {
         transition.SetTrigger("End");
    }

    
}
