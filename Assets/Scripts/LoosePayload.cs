using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class LoosePayload : MonoBehaviour
{
    public TextMeshProUGUI WeightDisplay;
    public TextMeshProUGUI FSdisplay;

    public decimal constant;
    public decimal palletint;
    public decimal TheMoment;

    public GameObject MainCanvas;
    public static decimal weightint;
    public static decimal Distance;
    public static GameObject FlightStation0;
    public bool Added;

    public decimal OldMoment;
    public decimal NewMoment;

    public void Awake()
    {
        Added = false;
        FlightStation0 = FlightStationZero.FS0.gameObject; // this is Flight Station Zero for measurments
        MainCanvas = GameObject.Find("MainCanvas");
        GameObject obj = MainCanvas.transform.GetChild(0).transform.GetChild(1).gameObject;  // this is the weight input field on maincanvas, Tpu Panel
        Debug.Log("Loose Payload is .." + obj.name);
        weightint = Int32.Parse(obj.GetComponent<TMP_InputField>().text.ToString()); //This converts the weight text OBJ from the input field into a number
        WeightDisplay.text = weightint.ToString(); // this displays the weight in the tpu ui;

        constant = 39.37006151790835M; // this converts from Unity measurements to inches.

        Distance = (decimal)Vector2.Distance(transform.position, FlightStation0.transform.position);


    }

    public void Update() // this continously recalculates the moment. The MakeTPU script adds the weight to the payload panel.
    {
        if (Added == false)
        {

            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Debug.Log("THE Loose addedfalse DISTANCE =  ..." + Distance);
            Distance = Distance * constant;
            decimal BetterDistance = Math.Round(Distance, 0);
            decimal moment = weightint * BetterDistance;
            Debug.Log("Added Loose addedfalse false moment ..." + moment);
            Payload.Moment += moment;
            OldMoment = moment;
            Added = true;
            FSdisplay.text = BetterDistance.ToString();


        }



        if (Added == true)

        {

            Payload.Moment -= OldMoment;
            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Debug.Log("THE added loose true DISTANCE =  ..." + Distance);
            Distance = Distance * constant;
            decimal BetterDistance = Math.Round(Distance, 0);
            decimal moment = weightint * BetterDistance;
            Debug.Log("Added loose true moment ..." + moment);
            Payload.Moment += moment;
            OldMoment = moment;
            Added = true;
            FSdisplay.text = BetterDistance.ToString();


        }






    }

}
