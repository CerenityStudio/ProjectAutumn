using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private string targetLevel;
    [SerializeField] private GameStateMachine stateMachine;
    
    private void Awake()
    {
        stateMachine = FindObjectOfType<GameStateMachine>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && this.gameObject.name == "Level Trigger")
            stateMachine.LoadLevel(targetLevel);
        
        if (col.CompareTag("Player") && this.gameObject.name == "End Trigger")
            stateMachine.EndGame();
    }
}
