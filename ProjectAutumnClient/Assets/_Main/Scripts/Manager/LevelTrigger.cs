using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private string targetLevel;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameStateMachine stateMachine;
    [SerializeField] private GameObject screenIn;
    [SerializeField] private GameObject screenOut;
    
    private void Awake()
    {
        screenIn.SetActive(true);
        stateMachine = FindObjectOfType<GameStateMachine>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && this.gameObject.name == "Level Trigger")
        {
            screenOut.SetActive(true);
        }

        if (col.CompareTag("Player") && this.gameObject.name == "End Trigger")
        {
            stateMachine.EndGame();
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel()
    {
        stateMachine.LoadLevel(targetLevel);
    }

    public void EndGame()
    {
        stateMachine.EndGame();
    }
}
