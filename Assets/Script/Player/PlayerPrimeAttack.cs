using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimeAttack : PlayerState
{
    public int comboConter;

    public float lastTimeAttack;
    public float comboWindow=2;



    public PlayerPrimeAttack(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
       
        base.Enter();


        float attcakDir = player.faceDir;
        if (InputManager.xInputRaw != 0)
        {
            attcakDir = InputManager.xInputRaw;
        }


        if (comboConter > 2||Time.time>=lastTimeAttack+comboWindow)
        {
            comboConter = 0;
        }
        player.anim.SetInteger("ComboConter", comboConter);

        player.SetVelocity(player.attackMovement[comboConter].x * attcakDir, player.attackMovement[comboConter].y);



        stateTimer = 0.1f;



    }

    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine(player.BusyFor(0.15f));

        comboConter++;
        lastTimeAttack = Time.time;
    }

    public override void UpDate()
    {
        base.UpDate();
        if (stateTimer < 0)
        {
            player.rb.velocity = new Vector2(0, 0);
        }

        if (triggerCalled)
        {
            playerStateMachine.changeState(player.playerIdleState);
        }
    }
}
