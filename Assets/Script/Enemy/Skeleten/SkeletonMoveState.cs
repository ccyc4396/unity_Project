using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletenGroundState
{
    public SkeletonMoveState(Enemy _enemyBass, EnemyStateMachine _stateMachine, string _ainBoolName, Enemy_Skeleton _enemy) : base(_enemyBass, _stateMachine, _ainBoolName, _enemy)
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

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.states.moveSpeed * enemy.faceDir, enemy.rb.velocity.y);
        if (enemy.IsWallDdetected() || !enemy.IsGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }

    }
}
