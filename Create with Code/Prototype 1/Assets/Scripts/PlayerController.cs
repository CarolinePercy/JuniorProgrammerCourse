using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horsePower = 20.0f;
    [SerializeField] float turnSpeed = 30;
    [SerializeField] GameObject centreOfMass;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;

    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centreOfMass.transform.position;
    }

    private void Update()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        speedometerText.SetText("Speed: " + speed + " kph");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (isOnGround())
        {
            // Moves the bus on vertical input
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);

            //Rotates the bus on horizontal input
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
            //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        }

    }

    bool isOnGround()
    {
        wheelsOnGround = 0;

        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        return wheelsOnGround > 0;
    }
}
