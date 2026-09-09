using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    
    #region State
    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonBattaleState battaleState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    public SkeletonDieState dieState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
       
        idleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        battaleState=new SkeletonBattaleState(this, stateMachine, "Move", this);
        attackState = new SkeletonAttackState(this, stateMachine,"Attack", this);
        dieState = new SkeletonDieState(this, stateMachine, "Die", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Ini(idleState);
        
    }

    protected override void Update()
    {
        
        base.Update();
    }





    public override void Die()
    {

        base.Die();
        //事件中心预留
        stateMachine.ChangeState(dieState);
        
    }
    
    public void GameObjectDestroy()
    {
        Destroy(gameObject);
    }
}
