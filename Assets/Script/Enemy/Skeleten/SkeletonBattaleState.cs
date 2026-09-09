using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattaleState : EnemyState
{
    private Transform player;
    private int MoveDir;

    private Enemy_Skeleton enemy;
    public SkeletonBattaleState(Enemy _enemyBass, EnemyStateMachine _stateMachine, string _ainBoolName,Enemy_Skeleton _enemy) : base(_enemyBass, _stateMachine, _ainBoolName)
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
        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if(CanAttack())
                stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if (stateTimer < 0 ||Vector2.Distance(player.transform.position,enemy.transform.position)>5)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }



        if (player.position.x > enemy.transform.position.x)
        {
            MoveDir = 1;
        }else if(player.position.x < enemy.transform.position.x)
        {
            MoveDir = -1;
        }

        enemy.SetVelocity(enemy.states.moveSpeed * MoveDir, rb.velocity.y);
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCoolDown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }


}
