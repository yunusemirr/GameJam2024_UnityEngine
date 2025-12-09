using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MultiJump : IJump
{
    Rigidbody2D _rigidbody2D;
    OnGround _onGround;

    float _jumpForce = 350f;
    int _maxJumpCount = 2;
    int _currentJumpCount = 0;
    public bool ForceJump { get; set; }


    public MultiJump(Rigidbody2D rigidbody2D, OnGround onGround)
    {
        _rigidbody2D = rigidbody2D;
        _onGround = onGround;
    }

    public void TickWithFixedUpdate()
    {

        if (ForceJump)
        {

            if (_currentJumpCount < _maxJumpCount)
            {
                
                Debug.Log("Multijump");
                
                _rigidbody2D.velocity = Vector2.zero;

                _rigidbody2D.AddForce(Vector2.up * _jumpForce);

                _rigidbody2D.velocity = Vector2.zero;

                _currentJumpCount++;
        

            }
            
            ForceJump = false;
        }
    }

    public void SetCurrentCount(int currentCount)
    {
        _currentJumpCount = currentCount;
    }
}

