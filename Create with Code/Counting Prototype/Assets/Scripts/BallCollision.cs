using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("Game Manager").GetComponent<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameController.AddToScore(other.GetComponent<AddToScore>().pointsToAdd);
    }
}
