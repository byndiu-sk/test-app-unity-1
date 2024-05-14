using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    public float offsetLimit = 16f;
    public float borderLimit = 5;
    public BreakPedal BreakPedal;
    public GasPedal GasPedal;
    public SteeringWheel SteeringWheel;
    public float speed = 10f;
    public float speedAffector;
    public float acceleration;
    public float rotationSpeed = 50f;
    private Vector3 position;
    private float horizontalInput;

    public float offset = 0;
    private float baseSpeed;
    
    
    
    private void Start() 
    {
        position = transform.position;
        baseSpeed = speed;
    }

    private void Update()
    {
        if (GameController.Instance.IsGameRunning)
        {
            position.y += speed * Time.deltaTime;


            horizontalInput = SteeringWheel.GetClampedValue();
            position.x += horizontalInput * rotationSpeed * Time.deltaTime;

            transform.position = position;

            if (GasPedal.IsPressed && offset <= offsetLimit)
            {
                speed = baseSpeed + acceleration;
                offset += acceleration * Time.deltaTime;
            }
            else if (BreakPedal.IsPressed && offset >= -offsetLimit)
            {
                speed = baseSpeed - acceleration;
                offset -= acceleration * Time.deltaTime;
            }
            else
            {
                speed = baseSpeed;
            }

            speed += speedAffector;
        }
    }
}