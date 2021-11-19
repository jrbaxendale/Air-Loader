using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using JetBrains.Annotations;

public class ACP_PayloadDBL : MonoBehaviour
{
    [SerializeField] public string Title;

    [SerializeField] public bool Locks;

    [SerializeField] public bool weight;

    [SerializeField] public bool location;

    [SerializeField] public bool dg;

    [SerializeField] public bool Checked;

    public static Vector3 PalletPosition;
    public GameObject WeightPallet;
    
    public TMP_Text weighttext;
    public float constant;
   
    public GameObject Button;
    public GameObject MainCanvas;
    public static float fwdWeight;
    public static float aftWeight;
    
   
    public bool Added;
    public bool Initial;
    public decimal OldMoment;

    public GameObject OriginalPosition;
    public GameObject CurrentPosition;
    public static float PalletWeight;
    public GameObject CombinedWeight;
    public GameObject FWDweight;
    public GameObject AFTweight;
   
    public GameObject SpecificCB;
    public float specificCB;
    public GameObject obj;
    public GameObject OBJ;
    public GameObject OBJ2;
    public GameObject StartPos;
    public decimal CombinedWt;
    public Vector2 FSOposition;
    public GameObject WeightWarning;
    public decimal FSo;
    public Vector2 CBadjustedPosition;
    public Vector3 DistanceVector;
    public float Distance;
    public float Moment;
    public float PalletCentreInches;
    




  

    private void Awake()
    {

        constant = 39.37006151790835f;
        Locks = false;
        weight = false;
        location = false;
        dg = false;
        Checked = false;
        Added = false;
        
        FSOposition = FlightStationZero.FS0.gameObject.transform.position;
        MainCanvas = GameObject.Find("MainCanvas");
        SpecificCB = MainCanvas.transform.GetChild(2).transform.GetChild(12).gameObject;
        CombinedWeight = MainCanvas.transform.GetChild(2).transform.GetChild(14)
            .gameObject; // this is the combined weight if there is one

        if (CombinedWeight.GetComponent<TMP_InputField>().text != null) // so there is a total weight
        {

            PalletWeight = Int32.Parse(CombinedWeight.GetComponent<TMP_InputField>().text);


        }
        

        else // this means there is no entry for total weight so this method uses individual wts

        {
           
            
            FWDweight = MainCanvas.transform.GetChild(2).transform.GetChild(4).gameObject;
            AFTweight = MainCanvas.transform.GetChild(2).transform.GetChild(1).gameObject;
            fwdWeight = Int32.Parse(FWDweight.GetComponent<TMP_InputField>().text);
            aftWeight = Int32.Parse(AFTweight.GetComponent<TMP_InputField>().text);
            
            PalletWeight = fwdWeight + aftWeight;

            
        }

        Payload.TotalPayloadWt += (decimal)PalletWeight;

        if (SpecificCB != null)
        {
            PalletCentreInches = Int32.Parse(SpecificCB.GetComponent<TMP_InputField>().text);
            specificCB = 89 - PalletCentreInches;
            specificCB /= constant;
            CBadjustedPosition.x = (float) specificCB + transform.position.x;

        }

        else if (SpecificCB == null)

        {

            CBadjustedPosition.x = 0;
        }
    }

    public void
        Update() // this continously recalculates the moment. The MakeACP script adds the weight to the payload panel.
    {
        CBadjustedPosition.x = (float)specificCB + transform.position.x;

        if (Added == false) // added means the moment has been added to the payload display
        {

            Distance = Vector3.Distance(CBadjustedPosition, FSOposition);
            Distance *= constant;
            float moment = PalletWeight * Distance;
            Moment = (float)(Math.Round(moment, 0));
            Payload.Moment += (decimal)Moment;
            OldMoment = (decimal)Moment;
            Added = true;

        }



        else if (Added)

        {
            Payload.Moment -= OldMoment;
            Distance = Vector3.Distance(CBadjustedPosition, FSOposition);
            Distance *= constant;
            float moment = PalletWeight * Distance;
            Payload.Moment += (decimal)moment;
            Moment = (float)(Math.Round(moment, 0));
            OldMoment = (decimal)Moment;
            Added = true;

        }











        if (gameObject.transform.parent != null)
        {

            OriginalPosition = gameObject.transform.parent.transform.gameObject;
        }

    }



    public void GetTitle()
    {
        Title = gameObject.transform.parent.transform.parent.transform.gameObject
            .name; // gets the name of the pallet position i.e ADS 1


    }

   
    

     

    

   
}
