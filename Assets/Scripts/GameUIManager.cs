using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [Header("Common Settings")]
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private GameUIMethods uiMethods;

    [Header("Pause Settings")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button continueGameButton;

    [Header("GameOver Settings")]
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Button restartLevelButton;

    [Header("Level Settings")]
    [SerializeField] private int nextIndexLevel;

    [Header("Game Logic Settings")]
    [SerializeField] private DeadZone deadZone;

    private void Start()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    private void OnEnable()
    {
        deadZone.OnPlayerDeath += HandlePlayerDeath;

        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(() => uiMethods.LoadLevel(nextIndexLevel));
        }

        if (restartLevelButton != null)
        {
            restartLevelButton.onClick.AddListener(() => uiMethods.RestartLevel());
        }

        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(() => uiMethods.OpenMenu(pauseMenu));
        }

        if (continueGameButton != null)
        {
            continueGameButton.onClick.AddListener(() => uiMethods.CloseMenu(pauseMenu));
        }
    }

    private void OnDisable()
    {
        deadZone.OnPlayerDeath += HandlePlayerDeath;

        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.RemoveAllListeners();
        }

        if (restartLevelButton != null)
        {
            restartLevelButton.onClick.RemoveAllListeners();
        }

        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
        }

        if (continueGameButton != null)
        {
            continueGameButton.onClick.RemoveAllListeners();
        }
    }

    private void Update()
    {
        // TODO: перенести на New Input System
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                uiMethods.CloseMenu(pauseMenu);
            }
            else
            {
                uiMethods.OpenMenu(pauseMenu);
            }
        }
    }

    private void HandlePlayerDeath()
    {
        uiMethods.OpenMenu(gameOverMenu);
    }
}
