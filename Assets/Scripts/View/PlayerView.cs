using Core;
using UnityEngine;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        #region Fields

        [Space(10)]

        [Header("Parameters")]

        [SerializeField] private float _step;
        [SerializeField] private float _speed;
        [SerializeField] private float _force;
        [SerializeField] private float _inpulsJumping;

        [Space(10)]

        [Header("Links")]

        [SerializeField] private GameObject _target;

        private Animator _animator;
        private Rigidbody _rigidbody;
        private Quaternion _startPosition;

        private float _stepDirection;
        private bool _isRotation;
        private bool _isGround;

        #endregion

        #region Metods

        public void Start()
        {
            _startPosition = transform.rotation;
            _isRotation = false;
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
                
            _animator.SetBool("IsBowOut", _isRotation);

            if (!_isRotation && _isGround)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    _isRotation = true;
                    _stepDirection = -_step;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    _isRotation = true;
                    _stepDirection = _step;
                }
            }

            if (Input.GetKeyDown(KeyCode.W) && !_isRotation)
            {
                Debug.Log("I Attack!");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(_isGround);
            }
        }

        public void FixedUpdate()
        {
            if (_isRotation)
            {
                var angle = Quaternion.Angle(_startPosition, transform.rotation);

                if (angle <= _step)
                {
                    transform.RotateAround(_target.transform.position, Vector3.up,
                      _stepDirection * _speed * Time.fixedDeltaTime);
                }
                else
                {
                    _isRotation = false;
                    Debug.Log(angle);
                    _startPosition = transform.rotation;
                }
            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            var ground = collision.gameObject.CompareTag("Ground");
            if (ground) _isGround = true;
            _animator.SetBool("IsJump", false);
        }

        public void OnCollisionExit(Collision collision)
        {
            var ground = collision.gameObject.CompareTag("Ground");
            if (ground) _isGround = false;
            _animator.SetBool("IsJump", true);
        }

        public void Jump(bool isGround)
        {
            if (isGround) _rigidbody.AddForce(Vector3.up * _inpulsJumping, ForceMode.Impulse);
        }

        #endregion

    }
}