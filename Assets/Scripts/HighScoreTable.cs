using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public GameObject _container;
    public GameObject _item;
    GameManager.ScoresList _scores;

    private void Awake()
    {
        _scores = GameManager.gmInstance.LoadScores();
        FillScoreTable(_scores);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void FillScoreTable(GameManager.ScoresList _list)
    {
        int _counter = 1;
        foreach (GameManager.ScoreRecord item in _list.Scores)
        {
            Transform _record = Instantiate(_item.transform, _container.transform);
            _record.Find("Position").GetComponent<Text>().text = _counter.ToString();
            _record.Find("Score").GetComponent<Text>().text = item.Score.ToString();
            _record.Find("Name").GetComponent<Text>().text = item.PlayerName.ToString();
        }
    }
}
