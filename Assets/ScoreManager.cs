using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string SCORE_KEY = "score_key"; 
    
    [SerializeField] private TextMeshProUGUI _scoreText;
    private float _score = 0;
    private float _highScore = 0;
    private bool _isRunning = false;

    private void Update()
    {
        if (!_isRunning) return;

        _score += Time.deltaTime;
        UpdateScoreText();
    }

    public void StartScore()
    {
        _isRunning = true;
    }

    public void StopScore()
    {
        _isRunning = false;
        SaveIfHighScore();
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public float CurrentScore()
    {
        return _score;
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {(int)_score}";
    }

    private void SaveIfHighScore()
    {
        if (_score > _highScore)
        {
            
        }
    }

    private void LoadHighScore()
    {
        
    }

}