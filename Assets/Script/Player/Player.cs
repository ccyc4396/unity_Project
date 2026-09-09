using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    

    [Header("Attack details")]
    public Vector2[] attackMovement;



    public bool isBusy { get; private set; }

    [Header("Invincible info")]
    public float invincibleTime;
    public bool isInvincible { get; private set; }


    [Header("Move info")]
    public float jumpForce;


    [Header("Dash info")]
    public float dashForce;
    public float dashCoolDown;
    public float dashTimer;
    public float dashDuration;
    public float dashDir;

    [Header("UI info")]
    public GameObject RestartPanel;
    #region States
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerIdleState playerIdleState { get; private set; }
    public PlayerMoveState playerMoveState { get; private set; } 
    public PlayerJumpState playerJumpState { get; private set; }
    public PlayerAirState playerAirState { get; private set; }
    public PlayerDashState playerDashState { get; private set; }
    public WallSlideState playerWallSlideState { get; private set; }
    public WallJumpState playerwallJumpState { get; private set; }

    public PlayerPrimeAttack playerPrimeAttack { get; private set; }
    public PlayerDieState PlayerDieState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        playerStateMachine = new PlayerStateMachine();
        playerIdleState = new PlayerIdleState(this,playerStateMachine,"Idle");
        playerMoveState = new PlayerMoveState(this,playerStateMachine, "Move");
        playerJumpState = new PlayerJumpState(this, playerStateMachine, "Jump");
        playerAirState  = new PlayerAirState(this, playerStateMachine, "Jump");
        playerDashState = new PlayerDashState(this, playerStateMachine, "Dash");
        playerWallSlideState = new WallSlideState(this, playerStateMachine, "WallSlide");
        playerwallJumpState = new WallJumpState(this, playerStateMachine, "Jump");

        playerPrimeAttack = new PlayerPrimeAttack(this, playerStateMachine, "Attack");
        PlayerDieState = new PlayerDieState(this, playerStateMachine, "Die");
    }

    protected override void Start()
    {
        base.Start();

        playerStateMachine.Initialize(playerIdleState);

    }

    protected override void Update()
    {
        base.Update();
        playerStateMachine.currentState.UpDate();

        IntoDashState();

     
    }


    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        
        yield return new WaitForSeconds(_seconds);
        
        isBusy=false;
    }

    public void AnimationTrigger() => playerStateMachine.currentState.AnimationFinishTrigger();

    
    public void IntoDashState()
    {
        dashDir = InputManager.xInputRaw;
        if(dashDir==0)
        {
            dashDir = faceDir;
        }

        dashTimer -= Time.deltaTime;
        if (dashTimer<0&&InputManager.DashLeftShift)
        {
            dashTimer = dashCoolDown;
            playerStateMachine.changeState(playerDashState);
        }
    }

    public override void Die()
    {
        base.Die();
        playerStateMachine.changeState(PlayerDieState);
    }

    public override void Damage(int damagePower)
    {
        if (isInvincible) { return; }
        StartCoroutine(Invincible(invincibleTime));
        base.Damage(damagePower);
    }

    IEnumerator Invincible(float time)
    {
        isInvincible = true;
        yield return new WaitForSeconds(time);
        isInvincible = false;
    }

    public void FreezeMove()
    {
        isKnock = true;
    }
    public void UnFreezeMove()
    {
        isKnock = false;
    }

    public void OpenRestartPanel()
    {
        RestartPanel.SetActive(true);
    }
}
