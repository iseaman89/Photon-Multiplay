using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 _moveVector;

    [SerializeField] private float _moveSpeed;

    #endregion

    #region Function

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _moveVector.x = Input.GetAxisRaw("Horizontal");
        _moveVector.y = Input.GetAxisRaw("Vertical");
        if (_moveVector != Vector3.zero)
        {
            _moveVector.Normalize();
            _animator.SetFloat("moveX", _moveVector.x);
            _animator.SetFloat("moveY", _moveVector.y);
            _animator.SetBool("move", true);
            _rigidbody2D.MovePosition(transform.position + _moveVector * _moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            _animator.SetBool("move", false);
        }
    }

    #endregion
}
