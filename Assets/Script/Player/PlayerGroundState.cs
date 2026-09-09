using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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

        if (InputManager.mouse0)
        {
            player.playerStateMachine.changeState(player.playerPrimeAttack);
        }

        if (!player.IsGroundDetected())
        {
            player.playerStateMachine.changeState(player.playerAirState);
        }


        if (InputManager.jumpSpace&&player.IsGroundDetected())
        {
            playerStateMachine.changeState(player.playerJumpState);
        }
    }
}
