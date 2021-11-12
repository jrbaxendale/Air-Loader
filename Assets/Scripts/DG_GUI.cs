using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DG_GUI : MonoBehaviour
{
    public GameObject DGGUI;
    public GameObject DGcam;
    public GameObject MainCam;
    public GameObject MainCanvas;
    public bool onoff;

    private void Awake()
    {

        onoff = false;
    }

    public void SwitchOnOff()
    {
        if (onoff == false)
        {
            MainCanvas.SetActive(false);
            MainCam.SetActive(false);
            DGGUI.SetActive(true);



        }
        

    }
}


