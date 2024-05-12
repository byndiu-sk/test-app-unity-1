using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    
    
    public static GameManager Instance { get; private set; }

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
        print("countdown completed");
    }
    
    private  void Start()
    {
        InitializeGame();
    }
    
    public void LaunchGame()
    {
        OnGameStart?.Invoke();
    }
    
    public void EndGame()
    {
        OnGameFinish?.Invoke();
    }
}
