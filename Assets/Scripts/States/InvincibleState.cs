using UnityEngine;

namespace States
{
    public class InvincibleState : State
    {
        public InvincibleState(PlayerStateMachine currentContext, PlayerStateFactory currentFactory) : base(currentContext, currentFactory)
        {
        }

        public override void EnterState()
        {
           PlayerInvincible();
        }

        public override void UpdateState()
        {
           CheckSwitchState();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override void CheckSwitchState()
        {
            if (_ctx.Invincible)
            {
                _factory.Normal();
            }
        }

        public override void InitializeSubState()
        {
            throw new System.NotImplementedException();
        }
        
        private void PlayerInvincible()
        {
            if (_ctx.Invincible)
            {
                _ctx.CurrentTime -= Time.deltaTime * .35f;
                if (!_ctx.InvincibleEffect.activeInHierarchy)
                {
                    _ctx.InvincibleEffect.SetActive(true);
                }
            }
            else
            {
                if (_ctx.InvincibleEffect.activeInHierarchy)
                {
                    _ctx.InvincibleEffect.SetActive(false);
                }

                if (_ctx.Impact)
                {
                    _ctx.CurrentTime += Time.deltaTime * 0.8f;
                }
                else
                {
                    _ctx.CurrentTime -= Time.deltaTime * 0.5f;
                }
            }
            
            TimeController();
        }

        private void TimeController()
        {
            if (_ctx.CurrentTime >= 2)
            {
                _ctx.CurrentTime = 2;
                _ctx.Invincible = true;
            }
            else if (_ctx.CurrentTime <= 0)
            {
                _ctx.CurrentTime = 0;
                _ctx.Invincible = false;
            }
        }
    }
}