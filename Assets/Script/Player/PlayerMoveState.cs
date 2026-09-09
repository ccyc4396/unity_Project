using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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
        if (xInput == 0)
        {
            playerStateMachine.changeState(player.playerIdleState);
        }
        player.SetVelocity(player.states.moveSpeed*xInput,player.rb.velocity.y);

    }
}
