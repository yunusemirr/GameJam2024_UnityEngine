using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneController : MonoBehaviour
{
    private IAttacker _attacker;
    LevelLoader _levelLoader;
    
    private void Awake()
    {
        _attacker = GetComponent<EnemyAttacker>();
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            GameManager.Instance.deadText.SetActive(true);
            _levelLoader.LoadNextLevel(0);
        }
    }
}
