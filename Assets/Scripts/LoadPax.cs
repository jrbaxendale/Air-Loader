using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadPax : MonoBehaviour
{
    public GameObject paxprefaboriginal;
    public bool bool1;
    public static Material colour;
    public static float PaxWeight;
    public Material red;
    public Material green;
    public Material blue;
    public Material cyan;
    public static GameObject FlightStation0;
    public static float Distance;
    public float constant;
    public static bool PaxWeight200;
    public static bool PaxWeight210;
    public static bool PaxWeight230;
    public static bool PaxWeight250;
  

    public void Awake()
    {
        
       

       // Vector3 newpos = transform.position;
       // newpos.x -= 0.2870337084f; // why does this work while 'transform.position.x += 5.0f;' doesn't?
        //transform.position = newpos;




    }

    public void Pax200()
    {

        colour = red;
        PaxWeight = 200;
        Debug.Log("red colour");
        PaxWeight200 = true;
        PaxWeight210 = false;
        PaxWeight230 = false;
        PaxWeight250 = false;
       

    }

   public void Pax210()
    {
        colour = green;
        PaxWeight = 210;
        Debug.Log("cyan colour");
        PaxWeight200 = false;
        PaxWeight210 = true;
        PaxWeight230 = false;
        PaxWeight250 = false;
    }

   public void Pax230()
    {
       colour = cyan;
        PaxWeight = 230;
        PaxWeight200 = false;
        PaxWeight210 = false;
        PaxWeight230 = true;
        PaxWeight250 = false;
        
    }

   public void Pax250()
    {
       colour = blue;
        PaxWeight = 250;
        PaxWeight200 = false;
        PaxWeight210 = false;
        PaxWeight230 = false;
        PaxWeight250 = true;
    }




    private void Start()
    {
        gameObject.tag = "selectable";
        colour = green;
        FlightStation0 = FlightStationZero.FS0.gameObject;
        constant = 39.37006151790835f;


    }

   public void OnMouseDown()

            

        {
            if (transform.name.Contains("SEAT") && transform.name.Contains("R") && transform.childCount == 0)
            {

                GameObject mypaxprefab = Instantiate(paxprefaboriginal);
                mypaxprefab.transform.parent = transform;
                mypaxprefab.GetComponent<Renderer>().material = colour;
               
           
                if (PaxWeight200 == true)
                {
               
                mypaxprefab.GetComponent<DestroyPax>().PaxWeight200 = true;
                mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = 200;
            }

                if (PaxWeight210 == true)
                {
               
                mypaxprefab.GetComponent<DestroyPax>().PaxWeight210 = true;
                mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = 210;


            }

                if (PaxWeight230 == true)
                {
               
                mypaxprefab.GetComponent<DestroyPax>().PaxWeight230 = true;
                mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = 230;

            }

                if (PaxWeight250 == true)
                {
               
                mypaxprefab.GetComponent<DestroyPax>().PaxWeight250 = true;
                mypaxprefab.GetComponent<DestroyPax>().ThisPassengerWt = 250;

            }


                mypaxprefab.transform.localPosition = new Vector3(-0.00079f, -0.00042f, -0.00058f);
                mypaxprefab.transform.localScale = new Vector3(0.00025f, 0.00025f, 0.00025f);
                mypaxprefab.transform.localEulerAngles = new Vector3(47.513f, -75.798f, -80.399f);

               
                mypaxprefab.tag = "loaded";
               Payload.PaxNumber += 1;
               Payload.TotalPaxWt += PaxWeight;
               Payload.TotalPayloadWt += PaxWeight;
                

               Distance = transform.position.x - FlightStation0.transform.position.x;
               Distance = Distance * constant;
               float moment = PaxWeight * Distance;
               float paxint = (float)Math.Round(moment, 0);
               Payload.Moment += paxint;
               mypaxprefab.GetComponent<DestroyPax>().ThisPassengerMoment = paxint;


        }

        else if (transform.name.Contains("SEAT") && transform.name.Contains("L") && transform.childCount == 0)
        {

            GameObject mypaxprefab = Instantiate(paxprefaboriginal) as GameObject;
            mypaxprefab.transform.parent = transform;
            mypaxprefab.GetComponent<Renderer>().material = colour;



            mypaxprefab.transform.localPosition = new Vector3(-0.00079f, -0.00042f, -0.00058f);
            mypaxprefab.transform.localScale = new Vector3(0.00025f, 0.00025f, 0.00025f);
            mypaxprefab.transform.localEulerAngles = new Vector3(-47.451f, 75.815f, 99.578F);

            
            mypaxprefab.tag = "loaded";
            Payload.PaxNumber += 1;
            Payload.TotalPaxWt += PaxWeight;

            Distance = transform.position.x - FlightStation0.transform.position.x;
            Distance = Distance * constant;
            float BetterDistance = (float)Math.Round(Distance, 0);
            float moment = PaxWeight * BetterDistance;
            float paxint = (float)Math.Round(moment, 0);
            Payload.Moment += paxint;
            Payload.TotalPayloadWt += PaxWeight;
            mypaxprefab.GetComponent<DestroyPax>().ThisPassengerMoment = paxint;




        }

    










    }

    









}










