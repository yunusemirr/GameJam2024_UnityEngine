using UnityEngine;
using PlatformerGame.Abstracts.Movements;


    public class MoveTranslate : IMover
    {
        private IEntityController _entityControllers;
        private float _moveSpeed;
        
        public MoveTranslate(IEntityController entityControllers, float moveSpeed)
        {
            _entityControllers = entityControllers;
            _moveSpeed = moveSpeed;
        }

        public void Tick(float horizontal)
        {
            if (horizontal == 0f)
                return;
            
            _entityControllers.transform.Translate(Vector2.right* horizontal * _moveSpeed * Time.deltaTime);
        }
    }
