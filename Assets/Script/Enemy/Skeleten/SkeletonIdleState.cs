using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletenGroundState
{
    public SkeletonIdleState(Enemy _enemyBass, EnemyStateMachine _stateMachine, string _ainBoolName, Enemy_Skeleton _enemy) : base(_enemyBass, _stateMachine, _ainBoolName, _enemy)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
