using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public Player player;
    public PlayerStateMachine playerStateMachine;
    public string animBoolName;
    public float xInput;
    public float yInput;
    public float stateTimer;
    protected bool triggerCalled;

    
    public PlayerState(Player _player,PlayerStateMachine _playerStateMachine,string _animBoolName)
    {
        this.player = _player;
        this.playerStateMachine = _playerStateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void UpDate()
    {
        xInput = InputManager.xInputRaw;
        yInput = InputManager.yInputRaw;
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    } 
}
