using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinState : PlayerState
{
    public PlayerWinState(Player _player, PLayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // GameObject.Find("GameManager").GetComponent<GameManager>().SwitchOnNextScreen();
    }

    public override void Update()
    {
        base.Update();

        rb.velocity = Vector2.zero;

    }

    public override void Exit()
    {
        base.Exit();
    }


}
