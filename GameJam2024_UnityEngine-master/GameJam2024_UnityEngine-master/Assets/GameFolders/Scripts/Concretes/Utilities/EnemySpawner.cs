using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    float _currentDelayTime;
    float _maxTime;

    float _spawnPos;

    void Start()
    {
        _maxTime = Random.Range(1f, 3f);
        _spawnPos = Random.Range(3.90f, -2.15f);
    }

    
    void Update()
    {
        _currentDelayTime += Time.deltaTime;

        if (_currentDelayTime > _maxTime)
        {
            Instantiate(enemyPrefab, new Vector3(transform.position.x, _spawnPos, transform.position.z), Quaternion.identity);
            _currentDelayTime = 0;
            _spawnPos = Random.Range(3.90f, -2.15f);
        }
    }
}
