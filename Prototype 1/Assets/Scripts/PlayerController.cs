using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour 
{
   
    private Rigidbody playerRb;

     [SerializeField]private float horsePower = 25.0f;

    private float horizontalInput;

    private float verticalInput;

    public int vehicleWheels=4;

    [SerializeField] float turnSpeed = 5.0f;

    [SerializeField] float speed;

    [SerializeField] float rpm;

    [SerializeField] int wheelsOnGround;

    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedometerText;

    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;

   
   
   
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        playerRb.centerOfMass = centerOfMass.transform.position;
    }

   
    void FixedUpdate()
    {

        PlayerInput();

        if (isOnGround())
        {
            CarMovement();

            Speedometer();

            Rpm();
        }
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == vehicleWheels)
            {
                return true;
            }
            else
            {
                return false;
            }
        
    }

    private void CarMovement()
    {
        //playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

        playerRb.AddRelativeForce(Vector3.forward * horsePower*verticalInput );
        
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
    }

    private void Speedometer()
    {
        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);//3.6 for kph
        speedometerText.SetText("Speed: " + speed + " mph");
    }

    private void Rpm()
    {
        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("Rpm: " + rpm);
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    
}
