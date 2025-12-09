using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Jump : IJump
    {
        private float _jumpForce = 330f;
        private Rigidbody2D _rigidbody2D;
        
        public bool ForceJump { get; set; }
    
        public Jump(Rigidbody2D rigidbody2D, float jumpForce)
        {
            _rigidbody2D = rigidbody2D;
            _jumpForce = jumpForce;
        }


        public void TickWithFixedUpdate()
        {
            if (ForceJump)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
                _rigidbody2D.velocity = Vector2.zero;
            }

            ForceJump = false;
        }

    }


