using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 50f;
    private Vector3 position;
    private float horizontalInput;
    
    private void Start() 
    {
        position = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            position.y += speed * Time.deltaTime;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        position.x += horizontalInput * rotationSpeed * Time.deltaTime;

        transform.position = position;
    }
}