using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpDate()
    {
        base.UpDate();

        if (player.IsWallDdetected())
        {
            playerStateMachine.changeState(player.playerWallSlideState);
        }


        if (player.IsGroundDetected())
        {
            playerStateMachine.changeState(player.playerIdleState);
        }

        if(InputManager.xInputRaw!=0)
        {
            player.SetVelocity(InputManager.xInputRaw * 0.8f*player.states.moveSpeed, player.rb.velocity.y);
        }
    }
}
