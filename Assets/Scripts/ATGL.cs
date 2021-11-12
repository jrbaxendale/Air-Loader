using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ATGL : MonoBehaviour
{
    public GameObject FlightStation0;
    public static decimal Distance;
    public decimal constant;
    public decimal ATGLWeight;
    public bool Added;
    public decimal OldMoment;
    public GameObject ATGLpallet;
    public decimal moment;
    public decimal palint;
    public Image circle;
   




    private void Awake()
    {
        
        ATGLWeight = 3620;
        Added = false;



    }



    public void AddATGL()


    {
        if (Added == false)
        {
            ATGLpallet.gameObject.SetActive(true);
            PartOne.PartOneTotalWt += ATGLWeight;
            Distance = 391;
            moment = ATGLWeight * Distance;
            palint = (Math.Round(moment, 0));
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
            palint = (Math.Round(moment, 0));
            PartOne.PartOneTotalMom = PartOne.PartOneTotalMom - palint;
            Added = false;
            circle.GetComponent<Image>().color = Color.white;



        }








    }
}
