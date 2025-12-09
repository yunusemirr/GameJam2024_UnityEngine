using PlatformerGame.Concretes.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 15f;
    LaunchProjectile _launchProjectile;
    Animator _animator;
    Health _health;
    bool _isDead;

    float _currentTime = 0f;
    float _maxTime = 4f;

    private void Awake()
    {
        _launchProjectile = GetComponent<LaunchProjectile>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    void Update()
    {
        if (_health.IsDead) 
        {
            _animator.SetTrigger("dead");
            Destroy(gameObject, 1f);
        }
            

        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        _launchProjectile.LaunchAction();
        _animator.SetBool("isFlying",true);

        

        _currentTime += Time.deltaTime;
        if (_currentTime >= _maxTime)
        {   
            _currentTime = 0f;
            Destroy(gameObject);
        }      
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IAttacker attacker = collision.gameObject.GetComponent<IAttacker>();

        if (attacker != null)
        {
            _health.TakeHit(attacker);
        }
    }
}
