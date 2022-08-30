using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float degrees;
    private void Update()
    {
        transform.Rotate(0, 0, degrees * speed * Time.deltaTime);
    }
}
