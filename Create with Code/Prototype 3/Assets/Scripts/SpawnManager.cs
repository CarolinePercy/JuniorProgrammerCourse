using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScriptRef;

    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScriptRef =
         GameObject.Find("Player").GetComponent<PlayerController>();

        //Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }

    void SpawnObstacle()
    {
        if (playerControllerScriptRef.gameOver == false)
        {
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }
}
