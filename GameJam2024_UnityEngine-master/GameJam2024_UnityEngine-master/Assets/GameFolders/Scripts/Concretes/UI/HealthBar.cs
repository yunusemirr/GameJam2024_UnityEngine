using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    SpriteRenderer[] _spriteRenderer;
    Health _health;

    private void Awake()
    {
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        _health = FindObjectOfType<PlaneController>().GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnHealthChanged += HandleHealthChanged;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
        _spriteRenderer[currentHealth].transform.localScale = new Vector3(0, 0, 0);
    }

}
