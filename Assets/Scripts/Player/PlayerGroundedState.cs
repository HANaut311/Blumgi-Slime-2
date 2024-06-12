using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerGroundedState : PlayerState
{   
    public GraphicRaycaster m_Raycaster;

    public PlayerGroundedState(Player _player, PLayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        SoundManager.instance.PlaySFX(1);
    }

    public override void Update()
    {
        base.Update();


        if(!UI.instance.IsOnUI())
        {

            if(!player.IsGroundDetected())
                stateMachine.ChangeState(player.airState);

            if(player.jumpValue == 0 && player.IsGroundDetected())
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y );
            }

            if(Input.GetKey(KeyCode.Mouse0) && player.IsGroundDetected() && player.canJump && player.canHight)
            {   
                player.jumpValue += 0.8f;
                player.highValue += 0.3f;
                stateMachine.ChangeState(player.aimState);
            }

            if(Input.GetKeyDown(KeyCode.Mouse0) && player.IsGroundDetected() && player.canJump && player.canHight)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                stateMachine.ChangeState(player.aimState);
            }

            if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                if(player.IsGroundDetected())
                {
                    rb.velocity = new Vector2(player.highValue, player.jumpValue);
                    player.jumpValue = 0.0f;      
                    player.highValue = 0.0f;  
                    // stateMachine.ChangeState(player.jumpState);
                }
                player.canJump = true;
                player.canHight = true;

            }
        }

    }

    public override void Exit()
    {
        base.Exit();
        SoundManager.instance.PlaySFX(1);
    }




}
