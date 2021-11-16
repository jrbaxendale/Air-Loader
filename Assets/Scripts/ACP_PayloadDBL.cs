using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using JetBrains.Annotations;

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
    public GameObject obj;
    public GameObject OBJ;
    public GameObject OBJ2;
    public GameObject StartPos;
    public GameObject FWDffe;
    public GameObject AFTffe;
    public GameObject MidFFE;
    public bool NoFFEbool;
    public bool FwdFFEbool;
    public bool AftFFEbool;
    public bool MidFFEbool;
    public Vector2 MidFfeVector2;
    public Vector2 AddedVector2;
    public static decimal PalletTotalWeight;
    public static decimal CentrePointDBL;
    public static decimal CombinedWt;


    public bool CombinedWeightCheck()

    {
        var text = obj.GetComponent<TMP_InputField>().text; // true means there is no entry in the CB field

        if (string.IsNullOrEmpty(text))
        {
            return true;
        }
        else
        {
           
            CombinedWt = Int32.Parse(obj.GetComponent<TMP_InputField>().text.ToString()); // this is the total weight;
            return false;
        }


    }

    public bool MidFFEnullCheck()

    {
        var text = MidFFE.GetComponent<TMP_InputField>().text; // true means there is no entry in the CB field

        if (string.IsNullOrEmpty(text))
        {
            return true;
        }
        else
        {
            return false;
        }
    }



     public void CBPrefOrder()

     { 
        
         MidFFEbool = MidFFEnullCheck();

        // true means the value of FFE input is null


         if (MidFFEbool)

         {
            NoFFE();


         }

         else if (MidFFEbool == false)

         {

            MidOnlyFFE();
         }



}

    private void Awake()
    {
       

        Added = false;
        FlightStation0 = FlightStationZero.FS0;
        MainCanvas = GameObject.Find("MainCanvas");
        FWDffe = MainCanvas.transform.GetChild(2).transform.GetChild(12).gameObject;
        MidFFE = MainCanvas.transform.GetChild(2).transform.GetChild(16).gameObject;
        AFTffe = MainCanvas.transform.GetChild(2).transform.GetChild(14).gameObject;

        obj = MainCanvas.transform.GetChild(2).transform.GetChild(14).gameObject; // this is the combined weight if there is one
        bool CombinedWtbool = CombinedWeightCheck();

        if (CombinedWtbool) // this means there is no entry for total weight

        {
            OBJ = MainCanvas.transform.GetChild(2).transform.GetChild(4).gameObject;
            weightint = Int32.Parse(OBJ.GetComponent<TMP_InputField>().text
                .ToString()); // this is the fwd weight of the pallet
            PalletWeight = weightint; // this is static version of the pallet weight;

            OBJ2 = MainCanvas.transform.GetChild(2).transform.GetChild(1).gameObject;
            weightintAFT = Int32.Parse(OBJ2.GetComponent<TMP_InputField>().text
                    .ToString()); // this is the AFT weight of the pallet
            palletintAFT = weightintAFT;

            constant = 39.37006151790835M;

            Distance = (decimal) Vector2.Distance(transform.position, FlightStation0.transform.position);

            Locks = false;
            weight = false;
            location = false;
            dg = false;
            Checked = false;

            palletint = weightint + weightintAFT;
            Payload.TotalPayloadWt += palletint;

        }
        
            CBPrefOrder(); // this checks if there is a CB mark 
        
    }

    public void Update()  // this continously recalculates the moment. The MakeACP script adds the weight to the payload panel.
    {
      CBPrefOrder();

        if (gameObject.transform.parent != null)
        {

            OriginalPosition = gameObject.transform.parent.transform.gameObject;
        }




    }



    public void GetTitle()
    {
        Title = gameObject.transform.parent.transform.parent.transform.gameObject.name; // gets the name of the pallet position i.e ADS 1


    }

    public void NoFFE()
    {

        if (Added == false)
        {
           
            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Distance = Distance * constant;
            decimal moment = palletint * Distance;
            decimal palint = (Math.Round(moment, 0));
            Payload.Moment += palint;
            OldMoment = palint;
            Added = true;


        }



        if (Added == true)

        {

            Payload.Moment -= OldMoment;
            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Distance = Distance * constant;
            decimal BetterDistance = Math.Round(Distance, 0);
            decimal moment = palletint * BetterDistance;
            decimal palint = (Math.Round(moment, 0));
            Payload.Moment += palint;
            OldMoment = palint;
            Added = true;


        }







    }

    public void MidOnlyFFE()
    {
       Debug.Log("MID RUNNING");
        if (Added == false)
        {
            decimal PalletCentre = (decimal)transform.position.x;
            decimal midInt = Int32.Parse(MidFFE.GetComponent<TMP_InputField>().text); // field input
            decimal FFE = 89 - midInt;
            Debug.Log("FFE IS... " + FFE);
            FFE /= constant;
            decimal DistancefromMidtoFFE = PalletCentre + FFE; // this is the distance between the pallet centre and the FFE distance
            float dist = (float) DistancefromMidtoFFE;
            MidFfeVector2 = new Vector2();
            MidFfeVector2.x = (float)DistancefromMidtoFFE;
            AddedVector2 = MidFfeVector2 + new Vector2(transform.position.x, 0);
            Distance = (decimal)(dist - FlightStation0.transform.position.x);
            Distance = Distance * constant;
            decimal moment = palletint * Distance;
            decimal palint = (Math.Round(moment, 0));
            Payload.Moment += palint;
            OldMoment = palint;
            Added = true;


        }



        if (Added == true)

        {

            Payload.Moment -= OldMoment;
            decimal midInt = Int32.Parse(MidFFE.GetComponent<TMP_InputField>().text); // field input
            decimal PalletCentre = (decimal)transform.position.x;
            decimal FFE = 89 - midInt;
            FFE /= constant;
            decimal DistancefromMidtoFFE = PalletCentre + FFE; // this is the distance between the pallet centre and the FFE distance
            
            MidFfeVector2 = new Vector2();
            MidFfeVector2.x = (float)DistancefromMidtoFFE;
            AddedVector2 = MidFfeVector2 + new Vector2(transform.position.x, 0);
            Distance = (decimal)(transform.position.x - FlightStation0.transform.position.x);
            Distance = Distance + FFE;
            Distance = Distance * constant;
            decimal BetterDistance = Math.Round(Distance, 0);
            decimal moment = palletint * BetterDistance;
            decimal palint = (Math.Round(moment, 0));
            Payload.Moment += palint;
            OldMoment = palint;
            Added = true;


        }






    }


}
