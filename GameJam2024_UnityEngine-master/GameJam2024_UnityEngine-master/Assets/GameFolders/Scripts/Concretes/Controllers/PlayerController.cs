using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;


public class PlayerController : MonoBehaviour, IEntityController
{
    private IInput _input;
    private IMover _mover;
    private IJump _jump;
    private IFlip _flip;
    private IAnimation _animation;
    private OnGround _onGrounded;
    private Rigidbody2D _rigidbody2D;
    private IHealth _health;
    public Image[] image;
    public GameObject deadObject;

    private float _horizontal;
    [SerializeField] private float _moveSpeed = 13f;
    [SerializeField] private float _jumpForce = 330f;

    private void Awake()
    {
        _input = new PcInputs();
        _mover = new MoveTranslate(this, _moveSpeed);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _onGrounded = GetComponent<OnGround>();
        _jump = new Jump(_rigidbody2D, _jumpForce);
        _flip = new FlipWithSpriteRenderer(this);
        _animation = new CharacterAnimation(GetComponent<Animator>());       
        _health = GetComponent<IHealth>();      
    }

    private void Update()
    {
        _horizontal = _input.Horizontal;

        if (_input.Jump && _onGrounded.IsOnGround)
        {
            _jump.ForceJump = true;
        }

        _animation.MoveAnimation(_horizontal);
        _animation.JumpAnimation(!_onGrounded.IsOnGround);
        //_animation.FallAnimation(_rigidbody2D, _onGrounded.IsGrounded);

    }

    private void FixedUpdate()
    {
        _mover.Tick(_horizontal);

        _jump.TickWithFixedUpdate();

        _flip.FlipAction(_horizontal);
    }


    [ContextMenu("Fade")]
    private void Fade(int i)
    {
        StartCoroutine(CoFade(image[i], 1, 1));
    }
    private IEnumerator CoFade(Image image, float finalValue, float duration)
    {
        var startAlpha = image.color.a;
        var alphaToAdd = finalValue - startAlpha;
        var startValue = 0f;
        var startColor = image.color;

        while (startValue < 1)
        {
            startValue += Time.deltaTime / duration;
            startColor.a = startAlpha + Mathf.Lerp(0, alphaToAdd, startValue);
            image.color = startColor;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Medicine")) 
        {
            if (GameManager.Instance.score == 1)
                Fade(0);

            if (GameManager.Instance.score == 2)
                Fade(1);

            if (GameManager.Instance.score == 3)
                Fade(2);    
        }
    }
}
