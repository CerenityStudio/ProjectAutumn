using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StartGameState : GameBaseState
{
    public StartGameState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.IntroScreen.SetActive(true);
    }

    public override void Tick(float deltaTime)
    {
        
    }

    public override void Exit()
    {
        Debug.Log("Exit Start State");
    }
}
