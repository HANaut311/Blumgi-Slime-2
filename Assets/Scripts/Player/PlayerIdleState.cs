using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PLayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // rb.velocity = Vector2.zero;
    }

    public override void Update()
    {   
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }


}
