using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _textObject;   
    
    float _currentTime = 0f;
    public float _maxTime = 13f;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxTime)
        {
            _textObject.SetActive(true);
        }
    }   
}
