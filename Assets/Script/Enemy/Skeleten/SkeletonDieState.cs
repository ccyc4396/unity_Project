using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDieState : EnemyState
{
    private Enemy_Skeleton enemy;
    public SkeletonDieState(Enemy _enemyBass, EnemyStateMachine _stateMachine, string _ainBoolName, Enemy_Skeleton _enemy) : base(_enemyBass, _stateMachine, _ainBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
       

        enemy.rb.velocity = Vector2.zero;
        enemy.rb.gravityScale = 0;
        foreach(Collider2D c in enemy.GetComponents<Collider2D>())
        {
            c.isTrigger=true;
        }


        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
