using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverScreen : Screen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _yourScoreText;

    private void Awake()
    {
        _restartButton.onClick.AddListener(() =>
        {
            StopAllCoroutines();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        
        _exitButton.onClick.AddListener(Application.Quit);
    }

    public override void Open()
    {
        base.Open();

        var scoreManager = GameController.Instance.ScoreManager;
        
        scoreManager.SaveScore();
        
        _bestScoreText.text = $"{(int)scoreManager.HighScore()}";
        _yourScoreText.text = $"{(int)scoreManager.CurrentScore()}";
    }
}
