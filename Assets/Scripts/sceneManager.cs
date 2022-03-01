using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public static void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }
    public static void Outside()
    {
        SceneManager.LoadScene("Outside", LoadSceneMode.Single);
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
