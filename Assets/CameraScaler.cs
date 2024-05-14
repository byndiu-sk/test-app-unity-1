using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float roadWidth = 10f; // Set this as the desired width for your game
    private Camera camera; // The camera

    void Start()
    {
        camera = GetComponent<Camera>();
        ScaleCamera();
    }

    private void ScaleCamera()
    {
        float unitsPerPixel = roadWidth / camera.pixelWidth;
        float desiredHalfHeight = 0.5f * unitsPerPixel * camera.pixelHeight;
        
        camera.orthographicSize = desiredHalfHeight;
    }
}