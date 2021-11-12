using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpin : MonoBehaviour
{
    readonly float speed = 1.0f;


    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);


    }
}
