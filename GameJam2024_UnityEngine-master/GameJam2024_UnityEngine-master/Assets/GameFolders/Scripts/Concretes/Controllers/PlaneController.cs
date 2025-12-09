using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    LaunchProjectile _launchProjectile;
    Health _health;
    Animator _animator;
    Rigidbody2D _rigidbody2D;

    [SerializeField] float _moveSpeed = 18f;
    float _horizontal;
    float _vertical;
    bool _attack;

    private void Awake()
    {
        _launchProjectile = GetComponent<LaunchProjectile>();
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _attack = Input.GetButtonDown("FireJoystick");

        if (_attack)
            _launchProjectile.LaunchAction();

        if(_health.IsDead)
        {
            _animator.SetTrigger("dead");
            Destroy(gameObject, 1f);
            GameManager.Instance.LoadNextScene(0);
        }

        _animator.SetBool("isFlying", true);
    }


    private void FixedUpdate()
    {
        if (_horizontal != 0f)
            transform.Translate(Vector2.right * _moveSpeed * _horizontal * Time.fixedDeltaTime);

        if (_vertical != 0f)
            transform.Translate(Vector2.up * _vertical * _moveSpeed * Time.fixedDeltaTime);
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {   
            _animator.SetTrigger("takeHit");
            _health.TakeHit(collision.gameObject.GetComponent<IAttacker>());
        }
    }
}
