using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateMachine : StateMachine
{
    public static StateMachine Instance;
    
    // Start Game Component
    [field: SerializeField] public GameObject IntroScreen { get; private set; }
    [field: SerializeField] public string LevelTarget { get; private set; }
    
    // End Game Component
    [field: SerializeField] public GameObject EndScreen { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SwitchState(new StartGameState(this));
    }

    public void LoadLevel(string level)
    {
        LevelTarget = level;
        SwitchState(new RunGameState(this));
    }

    public void EndGame()
    {
        SwitchState(new EndGameState(this));
    }

    public void ShowEndScreen()
    {
        Instantiate(EndScreen, FindObjectOfType<Canvas>().transform);
    }
}