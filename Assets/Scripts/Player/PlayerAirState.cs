using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PLayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if(player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);

        if(GameManager.instance.specials == true)
        {
            if(Input.GetKey(KeyCode.Mouse0) && !player.IsGroundDetected() && player.canJump && player.canHight)
            {   
                player.jumpValue += 0.5f;
                player.highValue += 0.2f;
                    rb.velocity = new Vector2(player.highValue, player.jumpValue);
            }

                if(Input.GetKeyUp(KeyCode.Mouse0))
                {
                    if(!player.IsGroundDetected())
                    {
                        rb.velocity = new Vector2(player.highValue, player.jumpValue);
                        player.jumpValue = 0.0f;      
                        player.highValue = 0.0f;  
                    }

                }

        }

    }

    public override void Exit()
    {
        base.Exit();
    }


}
