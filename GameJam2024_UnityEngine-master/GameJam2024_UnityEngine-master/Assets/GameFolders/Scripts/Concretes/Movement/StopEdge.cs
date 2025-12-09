using System;
using System.Collections;
using System.Collections.Generic;
using PlatformerGame.Abstracts.Movements;
using Unity.VisualScripting;
using UnityEngine;

namespace PlatformerGame.Movements
{
    public class StopEdge : MonoBehaviour, IStopEdge
    {

        [SerializeField] private float _distance;
        [SerializeField] private LayerMask _layerMask;

        private Collider2D _collider2D;
        private float _direction;
        
        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _direction = transform.localScale.x;
        }
        
        
        public bool ReachedEdge()
        {
            float x = GetXPosition();
            float y = _collider2D.bounds.min.y;

            Vector2 origin = new Vector2(x, y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, _distance, _layerMask);
            Debug.DrawRay(origin, Vector2.down * _distance, Color.blue);

            if (hit.collider != null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }


        private float GetXPosition()
        {
            return _direction == 1f ? _collider2D.bounds.max.x + _distance : _collider2D.bounds.min.x - _distance;
        }
        
    }    
}

