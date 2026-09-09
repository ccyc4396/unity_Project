using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpState : PlayerState
{
    public WallJumpState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.4f;
        player.SetVelocity(5 * -player.faceDir, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpDate()
    {
        base.UpDate();
        if (stateTimer < 0)
        {
            playerStateMachine.changeState(player.playerAirState);
        }
    }



}
