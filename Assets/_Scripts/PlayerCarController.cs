using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCarController : MonoBehaviour
{
    [SerializeField] private float offsetLimit = 16f;
    [SerializeField] private float borderLimit = 5;
    [SerializeField] private BreakPedal BreakPedal;
    [SerializeField] private GasPedal GasPedal;
    [SerializeField] private SteeringWheel SteeringWheel;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float acceleration;
    [SerializeField] private float rotationSpeed = 50f;
    
    private Vector3 position;
    private float horizontalInput;
    
    private float baseSpeed;

    public float SpeedEffector { get; set; }
    public float Offset { get; set; } = 0;

    public PlayerCarController(float speedEffector)
     {
         this.SpeedEffector = speedEffector;
     }

     private void Start() 
    {
        position = transform.position;
        baseSpeed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    private void Update()
    {
        if (GameController.Instance.IsGameRunning)
        {
            position.y += speed * Time.deltaTime;


            horizontalInput = SteeringWheel.GetClampedValue();
            position.x += horizontalInput * rotationSpeed * Time.deltaTime;

            transform.position = position;

            if (GasPedal.IsPressed && Offset <= offsetLimit)
            {
                speed = baseSpeed + acceleration;
                Offset += acceleration * Time.deltaTime;
            }
            else if (BreakPedal.IsPressed && Offset >= -offsetLimit)
            {
                speed = baseSpeed - acceleration;
                Offset -= acceleration * Time.deltaTime;
            }
            else
            {
                speed = baseSpeed;
            }

            speed += SpeedEffector;
        }
    }
}