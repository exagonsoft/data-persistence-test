using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject _infoMenu;
    public Text _name;
    public void OnExit() {
        #if UNITY_EDITOR
           EditorApplication.ExitPlaymode();
        #else
           Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void OnNewGame()
    {
        _infoMenu.SetActive(true);
    }

    public void OnStartGame()
    {
        GameManager _gaManager = GameManager.gmInstance;
        _gaManager.SetName(_name.text);
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
