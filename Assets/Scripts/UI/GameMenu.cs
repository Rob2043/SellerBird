using System.Collections;
using System.Collections.Generic;
using CustomEventBus;
using TMPro;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text _scoreText;
    private int Score;
    void OnEnable()
    {
        EventBus.addPoints += OnAddPoints;
    }
    void OnDisable()
    {
        EventBus.addPoints -= OnAddPoints;
    }
    public void Init()
    {
        _scoreText.text = $"{Score}";
    }
    private void OnAddPoints(int points)
    {
        Score += points;
        _scoreText.text = $"{Score}";
    }
}
