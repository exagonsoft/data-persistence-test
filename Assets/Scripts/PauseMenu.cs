using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void ResetLevel()
    {
        MainManager _manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        _manager.ResetLevel();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
