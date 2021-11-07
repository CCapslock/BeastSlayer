using Core;
using UnityEngine;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private int _step;
        [SerializeField] private float _maxHealth;
        
        private PlayerModel _playerModel;

        public void Start()
        {
            _playerModel = new PlayerModel(_damage, _maxHealth, _step);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D)) _playerModel.BowOut("Right", transform.position);
            else if (Input.GetKeyDown(KeyCode.A)) _playerModel.BowOut("Left", transform.position);
            else if (Input.GetKeyDown(KeyCode.Space)) _playerModel.Attack();
        }
    }
}