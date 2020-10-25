using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Current cam 's position
        Vector3 temp = transform.position;

        //Now we set cam 's x pos to Player 's x & y Pos
        temp.x = player.position.x;
        temp.y = player.position.y;

        //Now we will set back the Cam's position back
        transform.position = temp;
    }
}
