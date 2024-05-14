using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    [FormerlySerializedAs("CarController")] public PlayerCarController playerCarController;

    
    private void Update()
    {
        var currentPosition = gameObject.transform.position;

        var newPosition = new Vector3(currentPosition.x, target.position.y - playerCarController.Offset, currentPosition.z);
        transform.position = newPosition;
    }
}
