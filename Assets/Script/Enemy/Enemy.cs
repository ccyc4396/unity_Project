using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    [SerializeField]protected LayerMask whatIsPlayer;
    [HideInInspector]public float lastTimeAttacked;
    [Header("Attack info")]
    public float attackDistance;
    public float attackCoolDown;
    public float battleTime;
 

    [Header("Move info")]
    public float moveSpeed;
    public float idleTime;
    
    public EnemyStateMachine stateMachine;
    protected override void Awake()
    {
        base.Awake();
        stateMachine=new EnemyStateMachine();
    }

    protected override void  Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();

     
    }
    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * faceDir, 50, whatIsPlayer);
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x  + attackDistance * faceDir, transform.position.y));
    }
}
