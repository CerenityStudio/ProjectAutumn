using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameState : GameBaseState
{
    public EndGameState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.ShowEndScreen();
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("End Game");
    }

    public override void Exit()
    {
        
    }
}
