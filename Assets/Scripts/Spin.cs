using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
     readonly float speed = 10.0f;

    
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);


    }
}
