using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGlabelControl : MonoBehaviour
{
    public Vector3 centerPosition;
    public GameObject DGPallet;
    public Vector3 PanelPosition;
    public float radius;
    public float distance;
    public Vector3 fromOriginToObject;

    private void Awake()
    {
        DGPallet = GameObject.Find("DGpallet");
        radius = 55; //radius of *black circle*
        centerPosition = DGPallet.transform.position; //center of *black circle*


    }

    private void Update()
    {

        PanelPosition = transform.position;



         distance = Vector3.Distance(PanelPosition, centerPosition); //distance from ~green object~ to *black circle*

        if (distance > radius) //If the distance is less than the radius, it is already within the circle.
        {
            Debug.Log("Distance is greater than Radius");
            
            
            fromOriginToObject = PanelPosition - centerPosition; //~GreenPosition~ - *BlackCenter*
            fromOriginToObject *= radius / distance; //Multiply by radius //Divide by Distance
            transform.position = centerPosition + fromOriginToObject; //*BlackCenter* + all that Math
        }

    }





}
