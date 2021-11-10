using Core;
using UnityEngine;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _step;
        [SerializeField] private GameObject _target;
        [SerializeField] private float _speed;
        [SerializeField] private float _force;

        private Player _playerModel;
        private Quaternion _startPosition;
        private float _stepDirection;

        private bool _isRotation;
        private bool _isJump;

        #endregion

        #region Metods

        public void Start()
        {
            _startPosition = transform.rotation;
            _isRotation = false;
            _isJump = false;
        }

        public void Update()
        {
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) && !_isRotation)
            {
                _isRotation = true;

                if (Input.GetKeyDown(KeyCode.D)) _stepDirection = -_step;
                else _stepDirection = _step;
            }

            if (Input.GetKeyDown(KeyCode.W) && !_isRotation) Debug.Log("I Attack!");

            if (Input.GetKeyDown(KeyCode.Space) && !_isJump) _isJump = true;

            if (_isJump)
            {
                if (transform.position.y != 0.6f)
                {
                    var positionY = Mathf.Sqrt(_force -= 0.1f);
                    transform.position = new Vector3(0, positionY);
                }
                else _isJump = false;    
            }
        }

        public void FixedUpdate()
        {
            if (_isRotation)
            {
                var angle = Quaternion.Angle(_startPosition, transform.rotation);

                if (angle <= _step) transform.RotateAround(_target.transform.position, Vector3.up,
                    _stepDirection * _speed * Time.fixedDeltaTime);
                else
                {
                    _isRotation = false;
                    Debug.Log(angle);
                    _startPosition = transform.rotation;
                }
            }
        }

        #endregion
    }
}