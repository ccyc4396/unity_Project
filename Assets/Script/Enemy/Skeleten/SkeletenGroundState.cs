using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletenGroundState : EnemyState
{
    protected Enemy_Skeleton enemy;

    protected Transform player;
    public SkeletenGroundState(Enemy _enemyBass, EnemyStateMachine _stateMachine, string _ainBoolName, Enemy_Skeleton _enemy) : base(_enemyBass, _stateMachine, _ainBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected()||Vector2.Distance(enemy.transform.position,player.position)<2)
        {
            stateMachine.ChangeState(enemy.battaleState);
        }
    }
}
