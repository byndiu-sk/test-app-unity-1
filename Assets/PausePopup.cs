using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePopup : Screen
{
   [SerializeField] private Button _restartButton;
   [SerializeField] private Button _closeButotn;
   [SerializeField] private Button _exitButton;
   
   private void Awake()
   {
      _restartButton.onClick.AddListener(() =>
      {
         GameController.Instance.Reset();
         StopAllCoroutines();
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         GameController.Instance.InitializeGame();
        
      });
      _closeButotn.onClick.AddListener(() => Close());
      _exitButton.onClick.AddListener(() => Application.Quit());
   }

   public override void Open()
   {
      base.Open();
      GameController.Instance.PauseGame();
   }

   public override void Close()
   {
      base.Close();
      GameController.Instance.ResumeGame();
   }
}
