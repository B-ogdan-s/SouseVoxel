using UnityEngine.InputSystem;
using UnityEngine;

namespace PlayerState
{
    public class MoveState : PlayerState
    {
        Entity _entity;
        PlayerInputSystem _input;

        public MoveState(StateMachine<PlayerState> stateMachine, Entity entity, PlayerInputSystem input) : base(stateMachine)
        {
            _entity = entity;
            _input = input;
        }

        public override void Update()
        {
            _entity.Rotate();
            _entity.Move();
        }

        public override void StartState()
        {
            _entity.Animator.SetFloat("Speed", 2);

            _input.Player.Move.canceled += StartIdle;
            _input.Player.Move.performed += SetDirection;
        }
        public override void StopState()
        {
            _input.Player.Move.canceled -= StartIdle;
            _input.Player.Move.performed -= SetDirection;
        }

        private void StartIdle(InputAction.CallbackContext callback)
        {
            _stateMachine.ChangeState(typeof(IdleState));
            Debug.Log("StartIdle");
        }

        private void SetDirection(InputAction.CallbackContext callback)
        {
            Vector2 vector = callback.ReadValue<Vector2>();

            _entity.SetDirection(new Vector3(vector.x, 0, vector.y));
        }
    }
}
