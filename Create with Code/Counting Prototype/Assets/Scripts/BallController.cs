using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject ball;
    private GameObject currentBall;
    int ballsShot;
    private Rigidbody ballRb;
    private Vector3 shotPower = new Vector3(0, 300, 0);
    private float powerBehindHold;
    private bool holdingButtonDown;

    public void HoldButton()
    {
        currentBall = Instantiate(ball);
        ballRb = currentBall.GetComponent<Rigidbody>();
        powerBehindHold = 0;
        holdingButtonDown = true;
    }

    private void Update()
    {
        if (holdingButtonDown)
        {
            powerBehindHold += Time.deltaTime * 100;
        }
    }

    public void LetGoOfButton()
    {
        holdingButtonDown = false;
        ballRb.AddForce(shotPower + new Vector3(0, powerBehindHold, 0), ForceMode.Impulse);
    }


}
