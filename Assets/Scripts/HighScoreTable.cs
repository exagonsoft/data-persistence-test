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
    public Sprite _silverStar;
    public Sprite _goldStar;
    public Sprite _bronceStar;
    public Sprite _none;

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
        string rankstring;
        float _defaultheigth = -40f;
        foreach (GameManager.ScoreRecord item in _list.Scores)
        {
            Transform _record = Instantiate(_item.transform, _container.transform);
            RectTransform _recordRect = _record.GetComponent<RectTransform>();
            _recordRect.anchoredPosition = new Vector2(0, _defaultheigth * _counter);
            switch (_counter)
            {
                case 1:
                    {
                        _record.Find("Icon").GetComponent<Image>().sprite = _goldStar;
                        rankstring = "1ST";
                        break;
                    }
                case 2:
                    {
                        _record.Find("Icon").GetComponent<Image>().sprite = _silverStar;
                        rankstring = "2ND";
                        break;
                    }
                case 3:
                    {
                        _record.Find("Icon").GetComponent<Image>().sprite = _bronceStar;
                        rankstring = "3RD";
                        break;
                    }
                default:
                    _record.Find("Icon").GetComponent<Image>().sprite = _none;
                    rankstring = _counter.ToString() + "TH";
                    break;
            }

            _record.Find("Position").GetComponent<Text>().text = rankstring;
            _record.Find("Score").GetComponent<Text>().text = item.Score.ToString();
            _record.Find("Name").GetComponent<Text>().text = item.PlayerName.ToString();

            _counter++;
        }
    }
}
