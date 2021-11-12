using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ACP_PayloadDBL : MonoBehaviour
{
    [SerializeField]
    public string Title;

    [SerializeField]
    public bool Locks;

    [SerializeField]
    public bool weight;

    [SerializeField]
    public bool location;

    [SerializeField]
    public bool dg;

    [SerializeField]
    public bool Checked;

    public static Vector3 PalletPosition;
    public GameObject WeightPallet;
    public TextMeshProUGUI Moment;
    public TMP_Text weighttext;
    public decimal constant;
    public decimal palletint;
    public decimal palletintAFT;
    public decimal TheMoment;
    public GameObject Button;
    public GameObject MainCanvas;
    public static decimal weightint;
    public static decimal weightintAFT;
    public static decimal Distance;
    public static GameObject FlightStation0;
    public bool Added;
    public bool Initial;
    public decimal OldMoment;
    public decimal NewMoment;
    public GameObject OriginalPosition;
    public GameObject CurrentPosition;
    public static decimal PalletWeight;
    public GameObject OBJ;
    public GameObject OBJ2;
    public GameObject StartPos;





    private void Awake()
    {
        Added = false;
        FlightStation0 = FlightStationZero.FS0;
        MainCanvas = GameObject.Find("MainCanvas");
        OBJ = MainCanvas.transform.GetChild(2).transform.GetChild(4).gameObject;
        weightint = Int32.Parse(OBJ.GetComponent<TMP_InputField>().text.ToString()); // this is the fwd weight of the pallet
        Debug.Log("SOS" + weightint);
        PalletWeight = weightint; // this is static version of the pallet weight;

        OBJ2 = MainCanvas.transform.GetChild(2).transform.GetChild(1).gameObject; 
        weightintAFT = Int32.Parse(OBJ2.GetComponent<TMP_InputField>().text.ToString()); // this is the AFT weight of the pallet
        palletintAFT = weightintAFT;
        



        constant = 39.37006151790835M;

        Distance = (decimal)Vector2.Distance(transform.position, FlightStation0.transform.position);

        Locks = false;
        weight = false;
        location = false;
        dg = false;
        Checked = false;

        palletint = weightint;




    }

    public void Update()  // this continously recalculates the moment. The MakeACP script adds the weight to the payload panel.
    {
        if (Added == false)
        {

            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Debug.Log("THE DISTANCE =  ..." + Distance);
            Distance = Distance * constant;
            decimal moment = palletint * Distance;
            decimal palint = (Math.Round(moment, 0));
            Payload.Moment += palint;
            Debug.Log("FACE" + Payload.Moment);
            OldMoment = palint;
            Added = true;


        }



        if (Added == true)

        {

            Payload.Moment -= OldMoment;
            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Debug.Log("THE DISTANCE =  ..." + Distance);
            Distance = Distance * constant;
            decimal BetterDistance = Math.Round(Distance, 0);
            decimal moment = palletint * BetterDistance;
            decimal palint = (Math.Round(moment, 0));
            Payload.Moment += palint;
            OldMoment = palint;
            Added = true;


        }

        if (gameObject.transform.parent != null)
        {

            OriginalPosition = gameObject.transform.parent.transform.gameObject;
        }




    }



    public void GetTitle()
    {
        Title = gameObject.transform.parent.transform.parent.transform.gameObject.name; // gets the name of the pallet position i.e ADS 1


    }






}
