using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<Screen> _gameScreen;

    public T GetScreenOfType<T>() where T : Screen
    {
        return _gameScreen.OfType<T>().FirstOrDefault();
    }
}