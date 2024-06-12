using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimState : PlayerGroundedState
{
    public PlayerAimState(Player _player, PLayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        SoundManager.instance.PlaySFX(0);
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyUp(KeyCode.Mouse0) && player.IsGroundDetected())
            stateMachine.ChangeState(player.jumpState);
    }

    public override void Exit()
    {
        base.Exit();
        SoundManager.instance.StopSFX(0);
    }
}
