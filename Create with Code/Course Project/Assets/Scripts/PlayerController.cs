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
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (input.x != 0 || input.z != 0)
        {
            moving = true;

            transform.rotation = Quaternion.LookRotation(input);

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        

        animation.SetBool("Moving", moving);
        animation.SetFloat("Velocity Y", moving ? 1 : 0);
    }
}
