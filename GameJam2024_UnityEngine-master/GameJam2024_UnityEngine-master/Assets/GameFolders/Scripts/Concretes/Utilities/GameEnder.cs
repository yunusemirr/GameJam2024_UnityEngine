using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{

    TextTimer timer;

    private void Awake()
    {
        timer = FindObjectOfType<TextTimer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            timer.isSuccessed = true;
        }


    }
}
