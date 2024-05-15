using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GasPedal : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsPressed { get; private set; } = false;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
    }
}
