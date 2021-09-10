using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public bool Follow;
    GameObject Player;
    public float cameraSpeed;
    public Vector3 playerPosition;

    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        playerPosition = Player.transform.position;
        playerPosition.z = -10;

        if (Follow)
        {
              gameObject.transform.position = Vector3.Lerp(transform.position, playerPosition, cameraSpeed * Time.deltaTime);
//            gameObject.transform.position = new Vector3(playerPosition.x, playerPosition.y, -10f);
        }
    }
}
