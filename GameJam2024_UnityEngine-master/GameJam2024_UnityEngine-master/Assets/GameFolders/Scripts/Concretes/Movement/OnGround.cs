using System;
using System.Collections.Generic;
using UnityEngine;



    public class OnGround : MonoBehaviour
    {

        [SerializeField] Transform[] transforms;
        [SerializeField] float maxDistance = 0.4f;
        [SerializeField] LayerMask layerMask;

        bool _isOnGround;
        public bool IsOnGround => _isOnGround;
        private void Update()
        {
            foreach (Transform footTransform in transforms)
            {
                CheckFootOnGround(footTransform);

                if (_isOnGround) 
                    break;
            }
        }

        private void CheckFootOnGround(Transform footTransform)
        {

            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, layerMask);
            Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);

            if (hit.collider != null)
            {
                _isOnGround = true;
            }

            else
            {
                _isOnGround = false;
            }
        }
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transforms.Length; i++)
        {
            Debug.DrawRay(transforms[i].position, transforms[i].forward * maxDistance, Color.red);
        }
        }


}


