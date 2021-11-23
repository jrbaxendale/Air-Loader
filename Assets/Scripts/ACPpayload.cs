using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEditor.UIElements;
using UnityEngine.Rendering;

public class ACPpayload : MonoBehaviour
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
    public  GameObject  WeightPallet;
    public TextMeshProUGUI Moment;
    public TMP_Text weighttext;
    public float constant;
    public float palletint;
    public float TheMoment;
    public GameObject Button;
    public GameObject MainCanvas;
    public static float weightint;
    public static float Distance;
    public static GameObject FlightStation0;
    public bool Added;
    public bool Initial;
    public float OldMoment;
    public float NewMoment;
    public GameObject OriginalPosition;
    public GameObject CurrentPosition;
    public static float PalletWeight;
    public GameObject StartPos;





    private void Awake()
    {
         Added = false;
        FlightStation0 = FlightStationZero.FS0;
        MainCanvas = GameObject.Find("MainCanvas");
        GameObject obj = MainCanvas.transform.GetChild(5).transform.GetChild(1).gameObject;
        weightint = Int32.Parse(obj.GetComponent<TMP_InputField>().text.ToString()); // this is the weight of the pallet
        PalletWeight = weightint; // this is static version of the pallet weight;
     

        constant = 39.37006151790835f;

        Distance = Vector2.Distance(transform.position, FlightStation0.transform.position);
     
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

            Distance = transform.position.x - FlightStation0.transform.position.x;
            Debug.Log("THE DISTANCE =  ..." + Distance);
            Distance = Distance * constant;
            float moment = palletint * Distance;
            float palint = (float)Math.Round(moment, 0);
            Payload.Moment += palint;
            OldMoment = palint;
            Added = true;
          

        }

        
        
        if (Added == true)
            
        {
              
            Payload.Moment -= OldMoment;
            Distance = transform.position.x - FlightStation0.transform.position.x;
            Debug.Log("THE DISTANCE =  ..." + Distance);
            Distance = Distance * constant;
            float BetterDistance = (float)Math.Round(Distance, 0);
            float moment = palletint * BetterDistance;
            float palint = (float)Math.Round(moment, 0);
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
