using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private Player _player;
    [SerializeField] private Police _police;
    
    
    public static GameController Instance { get; private set; }

    public Action OnGameStart;
    public Action OnGameFinish;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public async void InitializeGame()
    {
        await _uiController.GameScreen.PlayCountdownAsync();
        LaunchGame();
     //   SpawnPoliceCar();
        print("countdown completed");
    }
    
    private  void Start()
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
        OnGameStart?.Invoke();
    }

    public void RestartGame()
    {
        print("game restarted");
    }
    
    public void EndGame()
    {
        OnGameFinish?.Invoke();
    }
}
