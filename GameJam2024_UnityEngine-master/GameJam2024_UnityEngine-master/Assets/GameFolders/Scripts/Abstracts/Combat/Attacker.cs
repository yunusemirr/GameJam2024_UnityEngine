using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGame.Concretes.Combat
{
    public abstract class Attacker : MonoBehaviour ,IAttacker
    {
        [SerializeField] int _damage = 1;
        public int Damage => _damage;

        public virtual void Attack(ITakeHit takeHit)
        {
            takeHit.TakeHit(this);
        }
        
    }
}

