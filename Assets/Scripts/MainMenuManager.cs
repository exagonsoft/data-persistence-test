using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject _infoMenu;
    public GameObject _settingsMenu;
    public Text _name;
    private AudioSource _player;

    private void Start()
    {
        _player = GetComponent<AudioSource>();
        OnChangeSettings();
    }

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
        _settingsMenu.SetActive(true);
    }

    public void OnHigthScores()
    {
        SceneManager.LoadScene(2);
    }

    public void OnInfoCancel()
    {
        _infoMenu.SetActive(false);
    }

    public void OnSettingsCancel()
    {
        _settingsMenu.SetActive(false);
    }

    public void OnSettingsAccept()
    {
    }

    public void OnChangeSettings()
    {
        GameManager.Settings settings = GameManager.gmInstance.GetSettings();
        _player.volume = settings.MainVolume;
    }
}
