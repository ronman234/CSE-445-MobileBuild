using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform player1;
    public Vector3 offset;  // initial camera position
    public float smoothTime; // time it takes for camera to reach target
    [HideInInspector]
    public Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        transform.position = offset;
    }

    void LateUpdate()
    {
        if (player1 == null)
        {
            Debug.Log("GAMEOVER");
            FindObjectOfType<GameManager>().GameOver();
        }
        else
        {
            TrackPlayer();
        }
    }

    public float PlayerPosition()     // returns Y position of player.
    {
        return player1.position.y;   
    }

    void TrackPlayer()
    {
        if (PlayerPosition() > offset.y)
        {
            Vector3 camPosY = new Vector3(offset.x, PlayerPosition(), offset.z);
            transform.position = Vector3.SmoothDamp(transform.position, camPosY, ref velocity, smoothTime);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, offset, ref velocity, smoothTime);
        }
    }

    public Transform SetPlayer1
    {
        set
        {
            player1 = value;
        }
    }
}

