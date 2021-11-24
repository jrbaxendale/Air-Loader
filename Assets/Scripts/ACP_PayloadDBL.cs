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
    public  float fwdWeight;
    public  float aftWeight;
    
   
    public bool Added;
    public bool Initial;
    public float OldMoment;

    public GameObject OriginalPosition;
    public GameObject CurrentPosition;
    public float PalletWeight;
    public GameObject CombinedWeight;
    public GameObject FWDweight;
    public GameObject AFTweight;
   
    public GameObject SpecificCB;
    public float specificCB;
    public GameObject obj;
    public GameObject OBJ;
    public GameObject OBJ2;
    public GameObject StartPos;
    public float CombinedWt;
    public Vector3 FSOposition;
    public GameObject WeightWarning;
    public float FSo;
    public Vector3 CBadjustedPosition;
    public Vector3 DistanceVector;
    public float Distance;
    public float Moment;
    public float PalletCentreInches;
    public float localMoment;
    public float LocalDistance;
    public float distanceEdited;
    public bool SpecCB;
    public bool distanceAddedBool;
    public Vector3 SpecCBVector;
    public Vector3 TransferedDistanceEditedVec;
    




  

    private void Awake()
    {
        distanceEdited = 0;
        constant = 39.37006151790835f; // real world is unity x constant ( as in the real world is 39 times bigger)
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

        FWDweight = MainCanvas.transform.GetChild(2).transform.GetChild(4).gameObject;
        AFTweight = MainCanvas.transform.GetChild(2).transform.GetChild(1).gameObject;
        fwdWeight = Int32.Parse(FWDweight.GetComponent<TMP_InputField>().text);
        aftWeight = Int32.Parse(AFTweight.GetComponent<TMP_InputField>().text);


        var CombinedText = CombinedWeight.GetComponent<TMP_InputField>().text;

            if (!string.IsNullOrWhiteSpace(CombinedText))
            {
            
                PalletWeight = Int32.Parse(CombinedText);

            }
            

            else // this means there is no entry for total weight so this method uses individual wts

            {
           
            PalletWeight = fwdWeight + aftWeight;
            
            }

        Payload.TotalPayloadWt += PalletWeight;

        var SpecificCBtext = SpecificCB.GetComponent<TMP_InputField>().text;

        if (!String.IsNullOrWhiteSpace(SpecificCBtext))
        {
            SpecCB = true;
            PalletCentreInches = Int32.Parse(SpecificCB.GetComponent<TMP_InputField>().text);

            if (gameObject.name.Contains("ADS"))
            {
                specificCB = 89 - PalletCentreInches;

            }

            else if (gameObject.name.Contains("LOG"))
            {
                specificCB = 89 - PalletCentreInches; // update this number

            }

            specificCB /= constant;

            CBadjustedPosition.x = specificCB + transform.position.x;
            Debug.Log("SPEC CB IS " + specificCB);

        }

        else

        {
            Debug.Log("NO spec CB");

            CBadjustedPosition = transform.position;
        }
    }

    public void
        Update() // this continously recalculates the moment. The MakeACP script adds the weight to the payload panel.
    {
       DistanceChooser();
       Debug.Log("DistanceChooser ran");

        if (Added == false) // added means the moment has been added to the payload display
        {
            Debug.Log("added false running");

            Distance = Vector3.Distance(CBadjustedPosition, FSOposition);
            Distance *= constant;
            float moment = PalletWeight * Distance;
            Moment = (float)(Math.Round(moment, 0));
            Payload.Moment += Moment;
            OldMoment = Moment;
            Added = true;
            LocalDistance = (float)(Math.Round(Distance, 0)); // this is the FS of the CB

        }



        else if (Added)

        {
            Debug.Log("added true running");
            Payload.Moment -= OldMoment;
            Distance = Vector3.Distance(CBadjustedPosition, FSOposition);
            Debug.Log("Distance between new CB and FSO before constant is .." + Distance);
            Distance *= constant;
            Debug.Log("distance after constant adjustment is .." + Distance);
            float moment = PalletWeight * Distance;
            Payload.Moment += moment;
            Moment = (float)(Math.Round(moment, 0));
            OldMoment = Moment;
            Added = true;
            LocalDistance = (float)(Math.Round(Distance, 0));
            GameObject.Find("SelectedPanelDBL").gameObject.transform.GetChild(3).gameObject.transform
                .GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = LocalDistance.ToString();


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


    public void DistanceChooser()

    {
        if (distanceEdited == 0) // if distance edited is enpty
        {
            if (SpecCB) // if specCB is being used
            {
                Debug.Log("SPEC CB applied");
                
                Vector3 CBvector = new Vector3(specificCB, 0, 0);
                CBadjustedPosition.x = CBvector.x + transform.position.x;

            }

            else

            {
                Debug.Log("SPEC CB not applied");


                CBadjustedPosition = transform.position;
            }
        }

        else if (distanceEdited != 0 && distanceAddedBool == false) // distanceaddedbool refers to whether distanceedited has been already calculated

        {
            Debug.Log("distanceEdited CB applied");
           
            distanceEdited /= constant;
            distanceEdited -= 22.501f; // we have to do this because a FS manually inputted assumes that FSO is at FS0 but in Unity FSO is at minus 22.501
            Debug.Log("distanceEdited is" + distanceEdited);
            Vector3 DistanceEditVector = new Vector3(distanceEdited, 0, 0);
            CBadjustedPosition = DistanceEditVector;
            TransferedDistanceEditedVec = DistanceEditVector;
            Debug.Log("distancedEdited finished" + CBadjustedPosition.x);
           
            distanceAddedBool = true;


        }

        else if (distanceEdited != 0 && distanceAddedBool) // this stops us continually recalculating and adding the distanceEdited
        {
            CBadjustedPosition = TransferedDistanceEditedVec;
            Debug.Log("distancedEdited finished" + CBadjustedPosition.x);
            
        }
       
    }
     

    

   
}
