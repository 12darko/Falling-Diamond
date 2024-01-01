using System;
using UnityEngine;

namespace States
{
    public class PlayerStateMachine : MonoBehaviour
    {  
        private State _currentState;
        private PlayerStateFactory _states;
        
               
        private bool _clicked;

            
        [SerializeField] private Rigidbody rb;
        [SerializeField] private GameObject invincibleEffect;
        [SerializeField] private float currentTime;
        [SerializeField] private bool invincible;
        [SerializeField] private bool impact;
 
        public Rigidbody Rb
        {
            get => rb;
            set => rb = value;
        }

        public bool Clicked
        {
            get => _clicked;
            set => _clicked = value;
        }

        public GameObject InvincibleEffect
        {
            get => invincibleEffect;
            set => invincibleEffect = value;
        }

        public float CurrentTime
        {
            get => currentTime;
            set => currentTime = value;
        }

        public bool Invincible
        {
            get => invincible;
            set => invincible = value;
        }

        public bool Impact
        {
            get => impact;
            set => impact = value;
        }

        public State CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        private void Awake()
        {
            _states = new PlayerStateFactory(this);
            _currentState = _states.Normal();
            _currentState.EnterState();
        }

        private void Update()
        {
            _currentState.UpdateState();
        }
    }
}