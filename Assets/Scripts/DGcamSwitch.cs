using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGcamSwitch : MonoBehaviour
{
    public GameObject MainCamOffset;
    public GameObject DGcam;
    public GameObject MainCanvas;
    public GameObject DGcanvas;
    public bool AmIon;
   
    public void DGcameraSwitch()
    {
        if (AmIon == false)
        {

            MainCamOffset.SetActive(false);
            MainCanvas.SetActive(false);
            DGcam.SetActive(true);
            DGcanvas.SetActive(true);
            AmIon = true;
        }
   
        else
        {
            MainCamOffset.SetActive(true);
            MainCanvas.SetActive(true);
            DGcam.SetActive(false);
            DGcanvas.SetActive(false);
            AmIon = false;


        }




    }


   

}
