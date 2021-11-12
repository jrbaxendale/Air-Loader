using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightStationZero : MonoBehaviour
{
    public static GameObject FS0;
    public static GameObject FlightStation0;
    public static double Distance;

    // Start is called before the first frame update

    public void Awake()
    {

        FS0 = gameObject;
        FlightStation0 = FS0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
   
}
