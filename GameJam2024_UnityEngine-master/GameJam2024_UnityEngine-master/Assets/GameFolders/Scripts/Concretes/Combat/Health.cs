using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Health : MonoBehaviour,ITakeHit
{
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;

    public bool IsDead => _currentHealth < 1;

    public event System.Action<int, int> OnHealthChanged;
    public event System.Action OnDead;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeHit(IAttacker attacker)
    {

        if (IsDead)
            return;

        _currentHealth = Mathf.Max(_currentHealth -= attacker.Damage, 0);
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (IsDead)
        {
            OnDead?.Invoke();
        }
    }
}
