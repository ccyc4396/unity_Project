using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideState : PlayerState
{
    public WallSlideState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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

        if (InputManager.jumpSpace)
        {
            player.playerStateMachine.changeState(player.playerwallJumpState);
            return;
        }



        if (yInput <0)
        {
            player.SetVelocity(0, player.rb.velocity.y);
        }
        else
        {
            player.SetVelocity(0, player.rb.velocity.y * 0.7f);
        }


        if (xInput != 0 && xInput != player.faceDir)
        {
            player.playerStateMachine.changeState(player.playerIdleState);
        }



        if (player.IsGroundDetected())
        {
            player.playerStateMachine.changeState(player.playerIdleState);
        }
    }
}
