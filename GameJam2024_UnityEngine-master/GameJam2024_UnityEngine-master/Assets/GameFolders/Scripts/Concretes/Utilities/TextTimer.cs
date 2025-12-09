using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    [SerializeField] private GameObject successText;

    float _currentTime = 0;
    float _maxTime = 6f;
    public bool isSuccessed = false;

    void Update()
    {
        if (isSuccessed) 
        {
            successText.SetActive(true);
            _currentTime += Time.deltaTime;

            if (_currentTime >= _maxTime)
            {
                successText.SetActive(false);
            }
        }
       
    }

}
