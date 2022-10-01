using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance;
    private string _name = "";
    // Start is called before the first frame update
    void Awake()
    {
        if (gmInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        gmInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetPlayerName()
    {

        return _name;
    }

    public void SetName(string sName)
    {
        _name = sName;
    }

    [System.Serializable]
    public class ScoresList
    {
        public List<ScoreRecord> Scores;
    }

    [System.Serializable]
    public class ScoreRecord
    {
        public string PlayerName;
        public string Score;
    }

    public void SaveScore(string _score)
    {
        ScoresList _actualScores = LoadScores();
        ScoreRecord newScore = new ScoreRecord();

        if (_actualScores != null)
        {
            newScore.PlayerName = _name;
            newScore.Score = _score;

            _actualScores.Scores.Add(newScore);

            string json = JsonUtility.ToJson(_actualScores);
            File.WriteAllText(Application.persistentDataPath + "/scores.json", json);
        }
        else
        {
            ScoresList _newScoreList = new ScoresList();
            _newScoreList.Scores = new List<ScoreRecord>();
            newScore.PlayerName = _name;
            newScore.Score = _score;
            _newScoreList.Scores.Add(newScore);

            string json = JsonUtility.ToJson(_newScoreList);
            File.WriteAllText(Application.persistentDataPath + "/scores.json", json);
        }
        

        
    }

    public ScoresList LoadScores()
    {
        ScoresList _listResoult = new ScoresList();

        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoresList data = JsonUtility.FromJson<ScoresList>(json);

            _listResoult = data;
        }
        else
        {
            _listResoult = null;
        }

        return _listResoult;
    }
}
