using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;
    public GameObject _explotion;
    public AudioClip _ball_destroy;
    private AudioSource _audio_player;

    private void Start()
    {
        _audio_player = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Renderer _collition_renderer = other.gameObject.GetComponent<Renderer>();
        Renderer _explotion_renderer = _explotion.GetComponentInChildren<Renderer>();
        _explotion.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        _explotion_renderer.material = _collition_renderer.material;
        Vector3 _explotion_point = other.transform.position;
        GameObject _explotion_effect = Instantiate(_explotion, _explotion_point, Quaternion.identity);
        _audio_player.PlayOneShot(_ball_destroy);
        Destroy(_explotion_effect, 1f);
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}
