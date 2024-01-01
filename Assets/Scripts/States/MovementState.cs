using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class MovementState : State
{   public MovementState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory): base(currentContext, playerStateFactory){}

    
    public override void EnterState()
    {
       PlayerMovement();
    }

    public override void UpdateState()
    {
       CheckSwitchState();
    }

    public override void ExitState()
    {
      
    }

    public override void CheckSwitchState()
    {
        if (!_ctx.Clicked)
        {
            _factory.Normal();
        }
    }

    public override void InitializeSubState()
    {
    
    }
    
    private void PlayerMovement()
    {
    
        if (!_ctx.Clicked)
        {
           _ctx.Impact = false;
            _ctx.Rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 0.5f, 0);
        }
        else
        {
            _ctx.Impact = true;
            _ctx.Rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 6f, 0);
        }
    }
}
