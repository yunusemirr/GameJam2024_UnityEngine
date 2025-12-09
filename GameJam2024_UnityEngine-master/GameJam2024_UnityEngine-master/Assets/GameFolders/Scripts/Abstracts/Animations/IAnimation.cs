using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface IAnimation
    {
        void MoveAnimation(float moveSpeed);
        void JumpAnimation(bool isJump);
        void FallAnimation(Rigidbody2D rigidbody2D, bool isGrounded);
      
    }

