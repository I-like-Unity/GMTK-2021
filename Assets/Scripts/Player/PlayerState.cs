using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pintos.FiniteStateMachine;

namespace Pintos.Player
{
    public abstract class PlayerState : FiniteState
    {
        protected PlayerState(string animBoolName, FiniteController controller, FiniteStateMachine.FiniteStateMachine stateMachine) : base(animBoolName, controller, stateMachine)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}

