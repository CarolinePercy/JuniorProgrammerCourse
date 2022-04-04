using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] float turnSpeed = 30;
    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Moves the bus on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //Rotates the bus on horizontal input
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
