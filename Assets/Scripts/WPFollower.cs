using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2;

    private int WPCounter = 0;

    private void Update()
    {
        if (Vector2.Distance(waypoints[WPCounter].transform.position, transform.position) < 0.1)      // .Distance(position of current waypoint, position of moving platform)
        {
            WPCounter++;
            if (WPCounter >= waypoints.Length)
            {
                WPCounter = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[WPCounter].transform.position, Time.deltaTime * speed);     //.MoveTowards(current position, position to move towards, distance moved per frame
    }
}
