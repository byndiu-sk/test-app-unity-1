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
    public float speed = 10f;
    public float speedEffector;
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
            
            position.x = Mathf.Clamp(position.x, -borderLimit, borderLimit);

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

            speed += speedEffector;
        }
    }
}