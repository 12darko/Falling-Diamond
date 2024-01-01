using System.Collections;
using System.Collections.Generic;
using States;
using Unity.VisualScripting;
using UnityEngine;

public class NormalState : State
{
    public NormalState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}
    

    public override void EnterState()
    {
       PlayerKeyDown();
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
        if (_ctx.Clicked)
        {
            _factory.Click();
        }
    }

    public override void InitializeSubState()
    {
        throw new System.NotImplementedException();
    }
 

    private void PlayerKeyDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ctx.Clicked = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _ctx.Clicked = false;
        }
    }
}
