using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public GameObject _explotion;
    public GameObject _brick_explotion;
    public AudioClip _brick_collide;
    public AudioClip _player_collide;
    private AudioSource _audio_player;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        _audio_player = GetComponent<AudioSource>();
    }
    
    private void OnCollisionExit(Collision other)
    {
        var velocity = m_Rigidbody.velocity;
        
        //after a collision we accelerate a bit
        velocity += velocity.normalized * 0.01f;
        
        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        //max velocity
        if (velocity.magnitude > 3.0f)
        {
            velocity = velocity.normalized * 3.0f;
        }

        m_Rigidbody.velocity = velocity;

        switch (other.gameObject.tag)
        {
            case "Brick":
                {
                    var _renderer = _brick_explotion.transform.GetChild(0).GetComponentInChildren<Renderer>();
                    Color _explotion_color = other.gameObject.GetComponent<Brick>().GetBrickColor();
                    _renderer.sharedMaterial.color = _explotion_color;

                    GameObject _effect = Instantiate(_brick_explotion, transform.position, Quaternion.identity);
                    _audio_player.PlayOneShot(_brick_collide);

                    Destroy(other.gameObject);
                    Destroy(_effect, 0.2f);
                    break;
                }
            case "Player":
                {
                    _audio_player.PlayOneShot(_player_collide);
                    break;
                }
            case "Box":
                {
                    _audio_player.PlayOneShot(_player_collide);
                    break;
                }
            default:
                break;
        }

    }

}
