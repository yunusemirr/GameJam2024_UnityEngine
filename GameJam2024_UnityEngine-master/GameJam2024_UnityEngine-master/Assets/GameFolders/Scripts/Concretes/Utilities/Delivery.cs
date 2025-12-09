using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    LevelLoader _levelLoader;

    private void Awake()
    {
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.score == 3)
        {
            _levelLoader.LoadNextLevel(1);
        }
    }

}
