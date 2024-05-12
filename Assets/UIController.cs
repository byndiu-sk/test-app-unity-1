using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameScreen _gameScreen;

    public GameScreen GameScreen
    {
        get => _gameScreen;
    }
}
