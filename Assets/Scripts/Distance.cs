using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor.UIElements;
using UnityEngine;

public class Distance : MonoBehaviour
{


    public GameObject Obj1;
    public GameObject Obj2;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Update()
    {
         //distance = (decimal)(Obj1.transform.position.x - Obj2.transform.position.x);
         distance = Vector3.Distance(Obj1.transform.position, transform.position);
        Debug.Log(distance + "DIST");


    }
}
