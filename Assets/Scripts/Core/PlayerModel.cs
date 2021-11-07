using Abstraction;
using UnityEngine;

namespace Core
{
    public class PlayerModel : IAttacable, IMove, IHealth
    {
        public float Damage => _damage;

        public int Step => _step;

        public float Health => MaxHealth;

        public float MaxHealth => _maxHealth;


        private float _damage;
        private float _maxHealth;
        private int _step;

        public PlayerModel(float damage, float maxHealth, int step)
        {
            _damage = damage;
            _maxHealth = maxHealth;
            _step = step;
        }

        public void Attack()
        {
            Debug.Log("I attack!");
        }

        public Vector3 BowOut(string direction, Vector3 position)
        {
            Debug.Log($"I bow out {direction}!");
            position.z += _step;
            return position;
        }
    }
}