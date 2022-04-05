using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 6.72f, -11.76f);

    // Update is called once per frame
    void LateUpdate()
    {
        //has camera move after player
        transform.position = player.transform.position + offset; 
    }
}
