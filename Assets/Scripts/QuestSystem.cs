using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{
    [Header("Pickup Goals Settings")]
    [SerializeField] private int pickupCoinsGoal = 1;
    [SerializeField] private int pickupDiamondsGoal = 1;

    [Header("Quest Completion Settings")]
    [SerializeField] private string questName = "Collect Items";
    [SerializeField] private string nameNextLevel = "Scene";

    [Header("Reference Settings")]
    [SerializeField] private GameObject questCompleteUI;
    [SerializeField] private Pickuper pickuper;
    [SerializeField] private GameUIMethods gameUIMethods;

    private Button _nextLevelButton;

    private void OnEnable()
    {
        pickuper.OnCoinsChanged += UpdateCoinsText;
        pickuper.OnDiamondsChanged += UpdateDiamondsText;

        _nextLevelButton = questCompleteUI.GetComponent<Button>();
        _nextLevelButton.onClick.AddListener(() => gameUIMethods.LoadLevel(nameNextLevel));
    }

    private void Start()
    {
        questCompleteUI.SetActive(false);
    }

    private void OnDisable()
    {
        pickuper.OnCoinsChanged -= UpdateCoinsText;
        pickuper.OnDiamondsChanged -= UpdateDiamondsText;

        _nextLevelButton.onClick.RemoveAllListeners();
    }

    private void UpdateCoinsText(int coins)
    {
        if (coins >= pickupCoinsGoal)
        {
            CheckQuestCompletion();
        }
    }

    private void UpdateDiamondsText(int diamonds)
    {
        if (diamonds >= pickupDiamondsGoal)
        {
            CheckQuestCompletion();
        }
    }

    private void CheckQuestCompletion()
    {
        if (pickuper.Coins >= pickupCoinsGoal &&
        pickuper.Diamonds >= pickupDiamondsGoal)
        {
            questCompleteUI.SetActive(true);
            // Time.timeScale = 0f; - If Needed Pause the game
        }
    }
}
