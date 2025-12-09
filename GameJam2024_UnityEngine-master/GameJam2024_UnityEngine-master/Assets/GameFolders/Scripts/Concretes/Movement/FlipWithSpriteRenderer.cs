using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class FlipWithSpriteRenderer : IFlip
    {
        SpriteRenderer _spriteRenderer;

        public FlipWithSpriteRenderer(PlayerController playerController)
        {
            
            _spriteRenderer = playerController.GetComponentInChildren<SpriteRenderer>();
            
        }


        public void FlipAction(float direction)
        {

            if (direction == 0f) return;

            if (direction > 0f)
            {

                _spriteRenderer.flipX = true;

            }

            else {

                _spriteRenderer.flipX = false;

            }

        }


    }



