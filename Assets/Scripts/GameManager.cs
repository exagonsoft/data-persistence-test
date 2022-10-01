using System;
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

    [System.Serializable]
    public class Settings
    {
        public float MainVolume;
        public float SFXVolume;
        public int AntiAliacingValue;
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
        //Sorting the list
        for (int ilist = 0; ilist < _listResoult.Scores.Count; ilist++)
        {
            for (int isublist = ilist +1; isublist < _listResoult.Scores.Count; isublist++)
            {
                if(Convert.ToInt32(_listResoult.Scores[isublist].Score) > Convert.ToInt32(_listResoult.Scores[ilist].Score))
                {
                    //swap
                    ScoreRecord _tempRecord = _listResoult.Scores[ilist];
                    _listResoult.Scores[ilist] = _listResoult.Scores[isublist];
                    _listResoult.Scores[isublist] = _tempRecord;
                }
            }
        }
        return _listResoult;
    }

    public void SaveSettings(float _mainVolume, float _sfxVolume, int _videoOption)
    {
        Settings _sett = new Settings();

        _sett.MainVolume = _mainVolume;
        _sett.SFXVolume = _sfxVolume;
        _sett.AntiAliacingValue = _videoOption;

        string json = JsonUtility.ToJson(_sett);
        File.WriteAllText(Application.persistentDataPath + "/settings.json", json);
    }

    public Settings GetSettings()
    {
        Settings _actualSettings = new Settings();
        string path = Application.persistentDataPath + "/settings.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            _actualSettings = JsonUtility.FromJson<Settings>(json);
        }
        else
        {
            _actualSettings.MainVolume = 1;
            _actualSettings.SFXVolume = 1;
            _actualSettings.AntiAliacingValue = 0;
        }

            return _actualSettings;
    }
}
