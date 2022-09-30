using System.Collections;
using System.Collections.Generic;
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

    public string Test()
    {
        return "";
    }
}
