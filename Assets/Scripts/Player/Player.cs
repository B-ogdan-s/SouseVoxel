using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [SerializeField] private CameraRotate _cameraRotate;
    private StateMachine<PlayerState.PlayerState> _stateMachine;

    private PlayerInputSystem _playerInputSystem;

    private Vector3 _globalDirection;// => _direction.z * _cameraRotate.CameraTransformY.forward + _direction.x * _cameraRotate.CameraTransformY.right;

    private void Awake()
    {
        SetValue();
        SetStateMachine();

        _playerInputSystem.Player.CameraRotation.performed += (InputAction.CallbackContext callback) =>
        {
            _cameraRotate.Rotate(callback.ReadValue<Vector2>());
        };

    }

    private void Update()
    {
        _stateMachine.State.Update();
    }

    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }

    private void SetValue()
    {
        _playerInputSystem = new PlayerInputSystem();
    }

    private void SetStateMachine()
    {
        _stateMachine = new StateMachine<PlayerState.PlayerState>();

        Dictionary<Type, PlayerState.PlayerState> stateDictionary = new()
        {
            {typeof(PlayerState.IdleState), new PlayerState.IdleState(_stateMachine, this, _playerInputSystem)},
            {typeof(PlayerState.MoveState), new PlayerState.MoveState(_stateMachine, this, _playerInputSystem)},

        };

        _stateMachine.SetInfo(stateDictionary);
        _stateMachine.ChangeState(typeof(PlayerState.IdleState));
    }
    public override void Move()
    {
        transform.Translate(_globalDirection * Time.deltaTime * _entityInfo.Speed);
    }

    public override void Rotate()
    {
        Vector3 velosyti = Vector3.zero;
        _globalDirection = Vector3.SmoothDamp(_globalDirection, _direction.z * _cameraRotate.CameraTransformY.forward + _direction.x * _cameraRotate.CameraTransformY.right, ref velosyti, _entityInfo.RotateTime);
        _entityInfo.ModelTransform.localRotation = Quaternion.LookRotation(_globalDirection, Vector3.up);
    }
}
