using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameoverScreen : Screen
{
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _yourScoreText;

    public override void Open()
    {
        base.Open();

        var scoreManager = GameController.Instance.ScoreManager;
        
        scoreManager.SaveScore();
        
        _bestScoreText.text = $"{(int)scoreManager.HighScore()}";
        _yourScoreText.text = $"{(int)scoreManager.CurrentScore()}";
    }
}
