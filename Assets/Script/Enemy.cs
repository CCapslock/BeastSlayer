using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float SpeedMove;

    private float _gravityForce;
    private Vector3 _moveVector3;

    private CharacterController _characterController;
    private Animator _animator;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterMove();
        GamingGravity();
    }

    private void CharacterMove()
    {
        _moveVector3 = Vector3.zero;
        _moveVector3.x = Input.GetAxis("Horizontal") * SpeedMove;
        _moveVector3.z = Input.GetAxis("Vertical") * SpeedMove;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Attake");
        }

        if (_moveVector3.x != 0 || _moveVector3.z != 0) _animator.SetBool("Run", true);
        else _animator.SetBool("Run", false);

        if (Vector3.Angle(Vector3.forward, _moveVector3) > 1f || Vector3.Angle(Vector3.forward, _moveVector3) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector3, SpeedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        _moveVector3.y = _gravityForce;
        _characterController.Move(_moveVector3 * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded) _gravityForce -= 20f * Time.deltaTime;
        else _gravityForce = -1f;
    }
}
