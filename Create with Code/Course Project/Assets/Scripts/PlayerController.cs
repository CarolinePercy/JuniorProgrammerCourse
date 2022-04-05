using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 4;
    private Vector3 input;
    bool moving = false;
    private Animator animationChecker;

    private void Start()
    {
        animationChecker = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moving = false;
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (input.x != 0 || input.z != 0)
        {
            moving = true;

            transform.rotation = Quaternion.LookRotation(input);

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        //Debug.Log(1.0f / Time.deltaTime);

        animationChecker.SetBool("Moving", moving);
        animationChecker.SetFloat("Velocity Y", moving ? 1 : 0);
    }
}
