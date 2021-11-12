using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{


    public GameObject Obj1;
    public GameObject Obj2;
    public decimal distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
         distance = (decimal)(Obj1.transform.position.x - Obj2.transform.position.x);
        Debug.Log(distance + "DIST");


    }
}
