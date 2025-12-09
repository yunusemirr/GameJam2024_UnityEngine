using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Flip : IFlip
    {
        private IEntityController _entity;
    
        public Flip(IEntityController entity)
        {
            _entity = entity;
        }

        public void FlipAction(float horizontal)
        {
            if (horizontal == 0f)
                return;

            float mathValue = Mathf.Sign(horizontal);

            if (mathValue != _entity.transform.localScale.x)
            {
                _entity.transform.localScale = new Vector2(mathValue, 1);
            }
        }

    }



