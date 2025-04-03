using System.Collections;
using System.Collections.Generic;
using CustomEventBus;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private GameObject _endGamePanel;
    private int Score;
    void OnEnable()
    {
        EventBus.addPoints += OnAddPoints;
        EventBus.endGame += OnEndGame;
    }
    void OnDisable()
    {
        EventBus.endGame -= OnEndGame;
        EventBus.addPoints -= OnAddPoints;
    }
    public void Init()
    {
        _scoreText.text = $"{Score}";
        _bestScoreText.text = $"{PlayerPrefs.GetInt("BestScore", 0)}";
    }
    private void OnAddPoints(int points)
    {
        Score += points;
        _scoreText.text = $"{Score}";
    }
    
    private void OnEndGame()
    {
        _endGamePanel.SetActive(true);
        if(Score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", Score);
            _bestScoreText.text = $"{Score}";
        }
        PlayerPrefs.Save();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
    public void ShareResult()
    {

    }
    public void AddToWorldList()
    {

    }
}
