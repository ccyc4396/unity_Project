using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    public Enemy enemyBass;
    public EnemyStateMachine stateMachine;

    public string ainBoolName;
    protected bool triggerCalled;
    protected float stateTimer;
    protected Rigidbody2D rb;


    public EnemyState(Enemy _enemyBass,EnemyStateMachine _stateMachine,string _ainBoolName)
    {
        this.enemyBass = _enemyBass;
        this.stateMachine = _stateMachine;
        this.ainBoolName = _ainBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBass.rb;
        enemyBass.anim.SetBool(ainBoolName, true);
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void Exit()
    {
        enemyBass.anim.SetBool(ainBoolName, false);
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

}
