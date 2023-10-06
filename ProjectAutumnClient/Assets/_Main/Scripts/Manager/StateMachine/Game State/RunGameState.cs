using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunGameState : GameBaseState
{
    public RunGameState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        SceneManager.LoadScene(stateMachine.LevelTarget);
    }

    public override void Tick(float deltaTime)
    { 
        if (Input.GetKeyDown(KeyCode.U))
            stateMachine.SwitchState(new EndGameState(stateMachine));
    }

    public override void Exit()
    {
        Debug.Log("Exit Run State");
    }
}
