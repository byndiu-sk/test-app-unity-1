using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public CarController CarController;

    private void Update()
    {
        var currentPosition = gameObject.transform.position;

        var newPosition = new Vector3(currentPosition.x, target.position.y - CarController.offset, currentPosition.z);
        transform.position = newPosition;
    }
}
