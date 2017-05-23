using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    #region Enums
    enum DirectionState
    {
        Left,
        Right
    }
    enum MoveState
    {
        Idle,
        Walk,
        Jump,
        Fall,
        Dead

    }
    #endregion

    #region Delegates
    #endregion

    #region Structures
    #endregion

    #region Classes
    #endregion

    #region Fields
    #endregion

    #region Events
    #endregion

    #region Properties
    [Header("Speeds")]
    public float WalkSpeed = 3;
    public float JumpForce = 10;
    public string _direct="right";

    private MoveState _moveState = MoveState.Idle;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    private Rigidbody2D _rigbody;
    private Animator _animatorController;
    private float _walkTime = 0, _walkCooldawn = 0.02f;

    #endregion

    #region Methods
    private void Start()
    {
        _animatorController = GetComponent<Animator>();
        _rigbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (_moveState == MoveState.Jump)
        {
            if (_rigbody.velocity == Vector2.zero)
            {
                Idle();
            }
        }
        else if (_moveState == MoveState.Walk)
        {
            _rigbody.velocity = ((_directionState == DirectionState.Right ? Vector2.right : -Vector2.right)
                * WalkSpeed * Time.deltaTime);
            _walkTime -= Time.deltaTime;
            if (_walkTime <= 0)
            {
                Idle();
            }

        }

    }
    internal void MoveRight()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Left)
            {
                _transform.localScale = new Vector3(-transform.localScale.x, _transform.localScale.y, transform.localScale.z);
                _directionState = DirectionState.Right;
                _direct = "right";
            }
            _walkTime = _walkCooldawn;
            _animatorController.Play("Walk");
        }
    }

    internal void MoveLeft()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Right)
            {
                _transform.localScale = new Vector3(-transform.localScale.x, _transform.localScale.y, transform.localScale.z);
                _directionState = DirectionState.Left;
                _direct = "left";
            }
            _walkTime = _walkCooldawn;
            _animatorController.Play("Walk");
        }
    }

    internal void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            _rigbody.velocity = (Vector3.up * JumpForce * Time.deltaTime);
            _moveState = MoveState.Jump;
            _animatorController.Play("Jump");
        }
    }

    internal void MoveDown()
    {
        return;

    }

    internal void MoveUp()
    {
        return;

    }

    private void Idle()
    {
        _moveState= MoveState.Idle;
        _animatorController.Play("Idle");
    }
    #endregion

    #region Event Handlers
    #endregion

}
