using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerState
{
    public abstract class PlayerState : State
    {
        protected StateMachine<PlayerState> _stateMachine;

        public PlayerState(StateMachine<PlayerState> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Update() { }

    }
}
