using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;


    private void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, target.position.y, gameObject.transform.position.z);
    }
}
