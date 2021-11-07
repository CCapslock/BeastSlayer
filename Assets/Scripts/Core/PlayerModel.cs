using Abstraction;
using UnityEngine;

namespace Core
{
    public class PlayerModel : IAttacable, IMove
    {
        public float Damage => _damage;

        public int Step => _step;

        private float _damage;
        private int _step;

        public PlayerModel(float damage, int step)
        {
            _damage = damage;
            _step = step;
        }

        public void Attack()
        {
            Debug.Log("I attack!");
        }

        public void BowOut()
        {
            Debug.Log("I bow out!");
        }
    }
}
