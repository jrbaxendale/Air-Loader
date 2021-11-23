using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ATGL : MonoBehaviour
{
    public GameObject FlightStation0;
    public static float Distance;
    public float constant;
    public float ATGLWeight;
    public bool Added;
    public float OldMoment;
    public GameObject ATGLpallet;
    public float moment;
    public float palint;
    public Image circle;
   




    private void Awake()
    {
        
        ATGLWeight = 3620;
        Added = false;

    }



    public void AddATGL() // this adds an ATGL to the load


    {
        if (Added == false)
        {
            ATGLpallet.gameObject.SetActive(true);
            PartOne.PartOneTotalWt += ATGLWeight;
            Distance = 391;
            moment = ATGLWeight * Distance;
            palint = (float)Math.Round(moment, 0);
            PartOne.PartOneTotalMom += palint;
            OldMoment = palint;
            circle.GetComponent<Image>().color = Color.green;

            Added = true;
            
        }



        else if (Added == true)

        {
            ATGLpallet.gameObject.SetActive(false);
            PartOne.PartOneTotalWt -= ATGLWeight;
            Distance = 391;
            moment = ATGLWeight * Distance;
            palint = (float)Math.Round(moment, 0);
            PartOne.PartOneTotalMom = PartOne.PartOneTotalMom - palint;
            Added = false;
            circle.GetComponent<Image>().color = Color.white;



        }








    }
}
