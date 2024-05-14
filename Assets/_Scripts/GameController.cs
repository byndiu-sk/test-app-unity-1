using System;
using System.Collections;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private Player _player;
    [SerializeField] private Police _police;
    [SerializeField] private ScoreManager _scoreManager;

    private bool _isGameRunning;
    
    public static GameController Instance { get; private set; }

    public bool IsGameRunning => _isGameRunning;
    public ScoreManager ScoreManager => _scoreManager;
    public UIController UIController => _uiController;
    
    public Player Player => _player;
    
    public Action OnGameStart;
    public Action OnGameFinish;

    private void Awake()
    {
        Instance = this;
    }
    
    public async void InitializeGame()
    {
        await _uiController.GetScreenOfType<GameScreen>().PlayCountdownAsync();
        LaunchGame();
        
        _isGameRunning = true;
        print("countdown completed");
    }
    
    private  void OnEnable()
    {
        InitializeGame();
    }

    public void SpawnPoliceCar()
    {
        _police.SpawnCar();
        _police.ActivePoliceCar.SetTarget(_player.PlayerCar);
    }
    
    public void LaunchGame()
    {
        InvokeRepeating("SpawnPoliceCar", 0f, 60f);
        OnGameStart?.Invoke();
    }
    
    public void EndGame()
    {
        _isGameRunning = false;
        _uiController.GetScreenOfType<GameoverScreen>().Open();
        OnGameFinish?.Invoke();
    }
    

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}