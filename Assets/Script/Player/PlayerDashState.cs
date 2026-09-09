using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, player.rb.velocity.y);
    }

    public override void UpDate()
    {
        base.UpDate();

        player.SetVelocity(player.dashForce*player.dashDir, 0);

        if (stateTimer < 0)
        {
            player.playerStateMachine.changeState(player.playerIdleState);
        }


    }
}
