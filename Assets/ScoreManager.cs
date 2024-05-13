using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string SCORE_KEY = "score_key";

    [SerializeField] private float scoreModifier;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreTitleText;
    [SerializeField] private Color _regularColor;
    [SerializeField] private Color _nitroModifierColor;
    
    private float _score = 0;
    private bool _isNitroModifierActive;

    private void Update()
    {
        if (GameController.Instance.IsGameRunning)
        {
            _score += Time.deltaTime * scoreModifier;
            UpdateScoreText();
        }
    }

    public void TurnNitroModifier()
    {
        _isNitroModifierActive = !_isNitroModifierActive;

        if (_isNitroModifierActive)
        {
            _scoreText.color = _nitroModifierColor;
            _scoreTitleText.color = _nitroModifierColor;

            scoreModifier *= 2;
        }
        else
        {
            _scoreText.color = _regularColor;
            _scoreTitleText.color = _regularColor;

            scoreModifier /= 2;
        }
        
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public float CurrentScore()
    {
        return _score;
    }

    public float HighScore()
    {
        return LoadHighScore();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"{(int)_score}";
    }

    public void SaveScore()
    {
        if (_score > LoadHighScore())
        {
            PlayerPrefs.SetFloat(SCORE_KEY ,_score);
        }
    }

    private float LoadHighScore()
    {
        return PlayerPrefs.GetFloat(SCORE_KEY);
    }

}