using Abstraction;
using UnityEngine;

namespace Core
{
    public class Player : IAttacable, IMove, IHealth, IJump
    {
        #region Fields

        public float Damage => _damage;

        public int Step => _step;

        public float Health => MaxHealth;

        public float MaxHealth => _maxHealth;


        private float _damage;
        private float _maxHealth;
        private int _step;

        #endregion

        #region Life cycle

        public Player(float damage, float maxHealth, int step)
        {
            _damage = damage;
            _maxHealth = maxHealth;
            _step = step;
        }

        #endregion

        #region Metods

        public void Attack()
        {
            Debug.Log("I attack!");
        }

        public void BowOut(string direction, Vector3 position)
        {
            
        }

        public void Jump()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}