using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float camX = 0;
    private float camY = 0;

    private void Update()
    {
        if (player.position.y >= -10.73)
        {
            camY = player.position.y;
        }
        else
        {
            camY = transform.position.y;
        }

        if (player.position.x >= 0)
        {
            camX = player.position.x;
        }
        else
        {
            camY = transform.position.y;
        }

        transform.position = new Vector3(camX, camY, transform.position.z);

    }
}
