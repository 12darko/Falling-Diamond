using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public abstract class State
{
   protected PlayerStateMachine _ctx;
   protected PlayerStateFactory _factory;

   public State(PlayerStateMachine currentContext, PlayerStateFactory currentFactory)
   {
      _ctx = currentContext;
      _factory = currentFactory;
   }
   public abstract void EnterState();
   public abstract void UpdateState();
   public abstract void ExitState();
   public abstract void CheckSwitchState();
   public abstract void InitializeSubState();

   void UpdateStates(){}

   protected void SwitchState(State newState)
   {
      ExitState();
      
      newState.EnterState();

      _ctx.CurrentState = newState;

   }
   protected void SetSuperState(){}
   protected void SetSubState(){}
}