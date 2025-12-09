using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


    public class CharacterAnimation : IAnimation
    {
        private Animator _animator;
        private bool isFall;
        public CharacterAnimation(Animator animator)
        {
            _animator = animator;
        }
        
        public void MoveAnimation(float moveSpeed)
        {
            
            float absValue = Mathf.Abs(moveSpeed);
            
            if (_animator.GetFloat("moveSpeed") == absValue)
                return;
            
            _animator.SetFloat("moveSpeed",absValue);
                
        }

        public void JumpAnimation(bool isJump)
        {
            if (_animator.GetBool("isJump") == isJump)
                return;
            
            _animator.SetBool("isJump",isJump);
        }
       
        
        public void FallAnimation(Rigidbody2D rigidbody2D, bool isGrounded)
        {
            
            if (!isFall && rigidbody2D.velocity.y < 0f && !isGrounded)
            {
                isFall = true;
                _animator.SetBool("isFall", true);
            }
                
            
            if (isFall && isGrounded)
            {
                isFall = false;
                _animator.SetBool("isFall",false);
            }

        }



    }


