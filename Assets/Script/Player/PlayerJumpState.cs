using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpDate()
    {
        base.UpDate();
        if (player.rb.velocity.y < 0)
        {
            playerStateMachine.changeState(player.playerAirState);
        }
    }
}
