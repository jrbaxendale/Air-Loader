using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadPaxCL : MonoBehaviour
{
    public GameObject paxprefaboriginal;
    public bool bool1;
    public static Material colour;
    public static decimal PaxWeight;
    public Material red;
    public Material green;
    public Material blue;
    public Material cyan;
    public static GameObject FlightStation0;
    public static decimal Distance;
    public GameObject paxprefabA;
    public static Material Colour;
    public static bool PaxWeight200;
    public static bool PaxWeight210;
    public static bool PaxWeight230;
    public static bool PaxWeight250;
    public decimal ThisPaxWeight;
    public decimal constant;





    private void Start()
    {
        gameObject.tag = "selectable";
        colour = green;
        FlightStation0 = FlightStationZero.FS0.gameObject;
        constant = 39.37006151790835M;


    }




    public void Update()
    {
        Colour = LoadPax.colour;
        PaxWeight = LoadPax.PaxWeight;

    }



    void OnMouseDown()



    {
        if (transform.name.Contains("SEAT") && transform.name.Contains("L") && transform.childCount == 0)
        {

            GameObject mypaxprefab = Instantiate(paxprefabA) as GameObject;
            mypaxprefab.transform.parent = transform;
            mypaxprefab.GetComponent<Renderer>().material = Colour;
            mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = ThisPaxWeight; // This transfers the passengers weight from this script to the script on the actual passenger transform


            if (LoadPax.PaxWeight200 == true)
            {

                mypaxprefab.GetComponent<DestroyPax>().PaxWeight200 = true;
                mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = 200;

            }

            if (LoadPax.PaxWeight210 == true)
            {

                mypaxprefab.GetComponent<DestroyPax>().PaxWeight210 = true;
                mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = 210;

            }

            if (LoadPax.PaxWeight230 == true)
            {

                mypaxprefab.GetComponent<DestroyPax>().PaxWeight230 = true;
                mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = 230;

            }

            if (LoadPax.PaxWeight250 == true)
            {

                mypaxprefab.GetComponent<DestroyPax>().PaxWeight250 = true;
                mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = 250;

            }



            mypaxprefab.transform.localPosition = new Vector3(-0.17f, -0.00042f, -0.00058f);
            mypaxprefab.transform.localScale = new Vector3(0.04264f, 0.04264f, 0.04264f);
            mypaxprefab.transform.localEulerAngles = new Vector3(47.513f, -75.798f, -80.399f);
            
            mypaxprefab.tag = "loaded";
            Payload.PaxNumber = Payload.PaxNumber + 1;
            Payload.TotalPaxWt = Payload.TotalPaxWt + PaxWeight;
            Payload.TotalPayloadWt += PaxWeight;

            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Distance = Distance * constant;
            decimal moment = PaxWeight * Distance;
            decimal paxint = (Math.Round(moment, 0));
            Payload.Moment += paxint;
            mypaxprefab.GetComponent<DestroyPax>().ThisPassengerMoment = paxint;

        }

        else if (transform.name.Contains("SEAT") && transform.name.Contains("R") && transform.childCount == 0)
        {

            GameObject mypaxprefab = Instantiate(paxprefabA) as GameObject;
            mypaxprefab.transform.parent = transform;
            mypaxprefab.GetComponent<Renderer>().material = Colour;


            mypaxprefab.transform.localPosition = new Vector3(-0.00079f, -0.00042f, -0.00058f);
            mypaxprefab.transform.localScale = new Vector3(0.04264f, 0.04264f, 0.04264f);
            mypaxprefab.transform.localEulerAngles = new Vector3(-47.451f, 75.815f, 99.578F);
            
            mypaxprefab.tag = "loaded";
            Payload.PaxNumber = Payload.PaxNumber + 1;
            Payload.TotalPaxWt = Payload.TotalPaxWt + PaxWeight;
            Payload.TotalPayloadWt += PaxWeight;

            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Distance = Distance * constant;
            decimal BetterDistance = Math.Round(Distance, 0);
            decimal moment = PaxWeight * BetterDistance;
            decimal paxint = (Math.Round(moment, 0));
            Payload.Moment += paxint;
            mypaxprefab.GetComponent<DestroyPax>().ThisPassengerMoment = paxint;
        }

        
        




    }
}










