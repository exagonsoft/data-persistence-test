using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SttingsManager : MonoBehaviour
{
    private float _mainVolume;
    private float _sfxVolume;
    private int _videoOption;

    private Transform _mainController;
    private Transform _sfxController;
    private Transform _videoController;

    private Text _mainvoltext;
    private Text _sfxvoltext;

    private GameManager.Settings _actualSettings;

    // Start is called before the first frame update
    void Start()
    {
        _mainController = GameObject.Find("MainVolControler").transform;
        _sfxController = GameObject.Find("SfxVolControler").transform;
        _videoController = GameObject.Find("VideoValue").transform;

        _mainvoltext = GameObject.Find("MainValue").GetComponent<Text>();
        _sfxvoltext = GameObject.Find("SfxValue").GetComponent<Text>();

        LoadActualData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadActualData()
    {
        GameManager.Settings _actualSettings = GameManager.gmInstance.GetSettings();
        _mainController.GetComponent<Slider>().value = _actualSettings.MainVolume;
        _sfxController.GetComponent<Slider>().value = _actualSettings.SFXVolume;
        _videoController.GetComponent<Dropdown>().value = _actualSettings.AntiAliacingValue;
    }

    public void OnMainVolumeChange()
    {
        float _value = _mainController.GetComponent<Slider>().value;
        _mainvoltext.text = (_value * 100).ToString("00");
        _mainVolume = _value;
    }

    public void OnSfxVolumeChange()
    {
        float _value = _sfxController.GetComponent<Slider>().value;
        _sfxvoltext.text = (_value * 100).ToString("00");
        _sfxVolume = _value;
    }

    public void OnVideoChange()
    {
        _videoOption = _videoController.GetComponent<Dropdown>().value; 
    }

    public void OnAccept()
    {
        GameManager.gmInstance.SaveSettings(_mainVolume, _sfxVolume, _videoOption);
        gameObject.SetActive(false);
    }
}
