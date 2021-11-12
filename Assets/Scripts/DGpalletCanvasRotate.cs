using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGpalletCanvasRotate : MonoBehaviour
{

    public GameObject DGcam;


    private void Awake()
    {
        DGcam = GameObject.Find("DG Camera");
      

    }
    void Update()
    {
        
        //transform.LookAt(transform.position + DGcam.transform.rotation * Vector3.forward, DGcam.transform.rotation * Vector3.up); // This makes the PalletPanelGUI always face the active camera
       // transform.position = new Vector3(Raycast.target.position.x, Raycast.target.position.y + 3, Raycast.target.position.z);
      
    }   
}
