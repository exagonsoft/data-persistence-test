using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public GameObject _lava_spark_effect;
    public GameObject _lava_river;
    private float _spawn_delay = 3f;
    private float _spawn_interval;
    void Start()
    {
        _spawn_interval = Random.Range(1, 6);
        InvokeRepeating("SpawnLavaSpark", _spawn_delay, _spawn_interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLavaSpark()
    {
        if (_lava_river != null)
        {
            Vector3 _start_position = _lava_river.transform.position;
            float _x_axys = Random.Range(_start_position.x - 2.16f, _start_position.x + 2.16f);
            GameObject _effect = Instantiate(_lava_spark_effect, new Vector3(_x_axys, _start_position.y, _start_position.z), Quaternion.identity);
            Destroy(_effect, 1f);
        }
        
    }
}
