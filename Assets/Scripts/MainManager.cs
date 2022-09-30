using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text LevelText;
    public Text DificultText;
    public Text GameOverInfoText;
    public Text GameWinInfoText;
    public GameObject GameOverText;
    public GameObject LevelClearPanel;
    public GameObject PauseMenuPanel;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;
    private bool m_GameWin = false;
    private int _bricks_left;
    private int _current_level = 1;
    private float _dificult_level = 1.25f;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    void CreateLevel()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        _bricks_left = perLine * LineCount;
        LevelText.text = $"Current Level : {_current_level.ToString()}" ;
        DificultText.text = $"Current Dificult : {_dificult_level.ToString("0.00")}" ;

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i] * _current_level;
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        m_Started = false;
    }

    private void Awake()
    {
        CreateLevel();
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ClearScene();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                m_GameOver = false;
                m_Started = false;
            }
        }else if (m_GameWin)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject _player = GameObject.FindGameObjectWithTag("Player");
                _player.transform.position = new Vector3(0f, _player.transform.position.y, _player.transform.position.z);
                CreateLevel();
                m_GameWin = false;
                m_Started = false;
            }
        }

        if(!m_GameWin && !m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                PauseMenuPanel.SetActive(true);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void CheckWin()
    {
        _bricks_left--;
        if(_bricks_left <= 0)
        {
            GameWin();
        }
    }

    private void GameWin()
    {
        GetComponent<EffectsManager>().OnWin();
        GameWinInfoText.text = $"Actual Score : {m_Points}";
        Ball _ball = GameObject.Find("Ball").GetComponent<Ball>();
        _ball.ResetPosition();
        _current_level++;
        m_GameWin = true;
        LevelClearPanel.SetActive(false);
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverInfoText.text = $"Your Score : {m_Points}";
        GameOverText.SetActive(true);
    }

    public bool GetGameState()
    {
        return m_GameOver;
    }

    void ClearScene()
    {
        GameObject[] _bricks_left = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject _brick in _bricks_left)
        {
            Destroy(_brick);
        }
    }

    public float GetDificulty()
    {
        return _dificult_level;
    }

    public void ResetLevel()
    {
        ClearScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        m_GameOver = false;
        m_Started = false;
    }
}
