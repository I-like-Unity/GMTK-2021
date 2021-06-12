using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pintos.FiniteStateMachine
    {
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public abstract class FiniteController : MonoBehaviour
    {
        public FiniteStateMachine StateMachine { get; private set; }

        public FiniteState startState;

        public Animator Anim { get; private set; }
        public Rigidbody2D RB { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }
        public Vector2 workspace;

        private void Awake()
        {
            StateMachine = new FiniteStateMachine();

            Initialize();
        }

        private void Start()
        {
            Anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();

            StateMachine.Initialize(startState);
        }

        public abstract void Initialize();

        private void Update()
        {
            CurrentVelocity = RB.velocity;
            StateMachine.CurrentState.LogicUpdate();

            LogicUpdate();
        }

        public abstract void LogicUpdate();

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        public void SetVelocity(float velocityX, float velocityY)
        {
            workspace.Set(velocityX, velocityY);
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }
    }
}