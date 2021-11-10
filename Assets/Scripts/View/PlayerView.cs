using UnityEngine;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _step;
        [SerializeField] private GameObject _target;

        private Quaternion _startPosition;
        private bool _isRotation;
        private float _stepDirection;

        #endregion

        #region Life cycle

        public void Start()
        {
            _startPosition = transform.rotation;
            _isRotation = false;
        }

        public void Update()
        {
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) && !_isRotation)
            {
                _isRotation = true;

                if (Input.GetKeyDown(KeyCode.D)) _stepDirection = -_step;
                else _stepDirection = _step;
            }

            if (_isRotation)
            {
                var angle = Quaternion.Angle(_startPosition, transform.rotation);
                Debug.Log(angle);

                if (angle <= _step) transform.RotateAround(_target.transform.position, Vector3.up,
                    _stepDirection * Time.deltaTime);
                else
                {
                    _isRotation = false;
                    _startPosition = transform.rotation;
                }
            }
        }

        #endregion
    }
}