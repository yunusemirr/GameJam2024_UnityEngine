using UnityEngine;
using UnityEngine.UI; 
using DG.Tweening;
using System.Collections;


public class ScoreController : MonoBehaviour
{
    private int score = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IncreaseScore(score);
            Destroy(gameObject);           
        }
    }
    
}

