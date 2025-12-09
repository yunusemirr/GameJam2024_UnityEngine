using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    TextMeshProUGUI _timeText;
    LevelLoader _levelLoader;

    float _overTime = 0f;
    [SerializeField] float _startingTime = 30f;
    bool _isOver = false;

    private void Awake()
    {
        _timeText = GetComponent<TextMeshProUGUI>();
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    void Update()
    {
        if (_startingTime > 0) 
        {
            _startingTime -= Time.deltaTime;
        }
      
        int floorSecond = Mathf.FloorToInt(_startingTime);
        _timeText.text = floorSecond.ToString();
        bool isCalled = false;

        if (floorSecond == 0)
        {
            _isOver = true;
        }

        if (_isOver && !isCalled)
        {
            GameManager.Instance.LoadNextScene(1);
            isCalled = true;           
        }
    }

}
