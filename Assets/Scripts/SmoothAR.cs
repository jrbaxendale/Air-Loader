using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothAR : MonoBehaviour
{
    public GameObject ARcam;
    private float x;
    private float y;
    private float z;


   
    void Update()
    {
        Vector3 pos = ARcam.transform.position;
        x = x + ((pos.x - x) / 8);
        y = y + ((pos.y - y) / 8);
        z = z + ((pos.z - z) / 8);
        Vector3 cam = transform.position;
        cam.x = x;
        cam.y = y;
        cam.z = z;
        transform.position = cam;

    }
}
