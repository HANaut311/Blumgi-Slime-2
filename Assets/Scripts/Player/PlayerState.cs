using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState 
{   
    protected PLayerStateMachine stateMachine;
    protected Player player;

    private string animBoolName;
    protected Rigidbody2D rb;

    protected float stateTimer;

    protected float xInput;
    

    public PlayerState(Player _player, PLayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {   
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;   
        xInput = Input.GetAxisRaw("Horizontal");


        player.anim.SetFloat("yVelocity", rb.velocity.y);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }


}
