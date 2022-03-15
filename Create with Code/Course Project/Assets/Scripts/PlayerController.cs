using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3;
    public float rotationSpeed;
    private Vector3 input;
    bool moving = false;
    private Animator animation;

    private void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (input.x != 0 || input.z != 0)
        {
            moving = true;

            //input = input.x * Vector3.right + input.z * Vector3.forward;

            transform.rotation = Quaternion.LookRotation(input);
            //transform.rotation = Quaternion.Slerp(transform.rotation,
            //Quaternion.LookRotation(input),
            //Time.deltaTime * rotationSpeed);

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        

        animation.SetBool("Moving", moving);
        animation.SetFloat("Velocity Y", oving);

        if (input != Vector3.zero)
        {

        }
    }
}
