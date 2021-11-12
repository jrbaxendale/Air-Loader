using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOff : MonoBehaviour
{
    public GameObject Maincanvas;


  
    public void TurnOffRaycast()
    {
        Maincanvas.GetComponent<Raycast>().enabled = !enabled;
       
        Debug.Log("Raycast off");


    }


    public void TurnOnRaycast()
    {
        Maincanvas.GetComponent<Raycast>().enabled = enabled;

        Debug.Log("Raycast on");


    }


}