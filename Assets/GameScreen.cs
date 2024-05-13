using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameScreen : Screen
{
    [SerializeField] private GameObject _hud;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private Button _pauseButton;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(() => 
            GameController.Instance.UIController.GetScreenOfType<PausePopup>().Open());
    }

    public async Task PlayCountdownAsync()
    {
        int count = 3;
        while (count > 0)
        {
            _countdownText.text = count.ToString();
            await Task.Delay(1000);  // equivalent to 'yield return new WaitForSeconds(1)'
            count--;
        }
        _countdownText.text = "START";
      StartCoroutine(EnableGameHud(1));
    }
    
    private IEnumerator EnableGameHud(float delay)
    {
        _hud.SetActive(true);
        yield return new WaitForSeconds(delay);
        _countdownText.gameObject.SetActive(false); 
    }
    
    
}