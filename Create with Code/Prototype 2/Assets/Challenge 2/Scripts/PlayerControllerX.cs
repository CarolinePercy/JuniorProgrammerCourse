using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float currentTime = 0.0f;
    private float timeBetweenDogs = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
            currentTime -= Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && currentTime <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            currentTime = timeBetweenDogs;
        }
    }
}
