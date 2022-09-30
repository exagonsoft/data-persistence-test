using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnExit() {
        #if UNITY_EDITOR
           EditorApplication.ExitPlaymode();
        #else
           Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSettings()
    {

    }

    public void OnHigthScores()
    {
        SceneManager.LoadScene(2);
    }
}
