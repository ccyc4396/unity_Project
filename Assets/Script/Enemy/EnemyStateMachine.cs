using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState currentState { get; private set; }


    public void ChangeState(EnemyState _changeState)
    {
        currentState.Exit();
        currentState = _changeState;
        currentState.Enter();
    }

    public void Ini(EnemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }
}
