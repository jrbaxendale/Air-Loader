using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Payload : MonoBehaviour
{
    public static float PaxNumber;
    public static float TotalPaxWt;
    public static float TotalPayloadWt;
    public TMP_Text DisplayPayloadWt;
    public TMP_Text DisplayPaxNumber;
    public TMP_Text DisplayPaxWt;
    public static float payload;
    public TMP_Text DisplayMAC;
    public TMP_Text DisplayPayloadFStn;
    public static float Moment;
    public static float OpMoment;
    public static decimal PayloadMoment;
    public static float PayloadFStation;
    public float PayloadFSTN;


    public static bool ADS1title;
    public static bool ADS1locks;
    public static bool ADS1weight;
    public static bool ADS1position;
    public static bool ADS1dg;

    public TMP_Text DisplayZFWWt;
    public static float ZFWeight;
    public static float OpWeight;

    public TMP_Text DisplayZFWMom;
    public static float ZFWstation;
    public static float OpWtStation;
    public static float ZFWmoment;
    public static float ZFWMAC;
    public TMP_Text OpWtOutout;
    public TMP_Text OpWtMoOutput;







    private void Start()
    {
        
        
      

    }    
    
    
    
    
    public void Update()
    {
        
        Debug.Log(TotalPaxWt + " Total Pax Wt");
        DisplayPaxNumber.text = PaxNumber.ToString();
        DisplayPaxWt.text = TotalPaxWt.ToString();
        DisplayPayloadWt.text = TotalPayloadWt.ToString();
        
        OpWtMoCalc();
        PayloadStation();
        ZFWCalc();

    }

    public void PayloadStation() // this calcs the payload stn
    {
        if (Moment > 0)

        {
            Debug.Log("PAYLOAD MOMENT IS .." + Moment);
            PayloadFStation = Moment / TotalPayloadWt;
            Debug.Log("Total Payload Weight" + TotalPayloadWt);
            Debug.Log("Payload FS = " + PayloadFStation);
            PayloadFSTN = (float)Math.Round(PayloadFStation, 0);
            Debug.Log("PAYLOADfstn = " + PayloadFSTN);
            DisplayPayloadFStn.text = PayloadFSTN.ToString();
        }

         else if (Moment == 0)


        {

            PayloadFStation = 0;
            Debug.Log("Payload FS = " + PayloadFStation);
            PayloadFSTN = (float)Math.Round(PayloadFStation, 0);
            Debug.Log("PAYLOADfstn = " + PayloadFSTN);
            DisplayPayloadFStn.text = PayloadFSTN.ToString();
        }



    }

    public void ZFWCalc() // this calcs the zfw and MAC.
    {
        ZFWeight = PartOne.PartOneTotalWt + TotalPayloadWt;
        DisplayZFWWt.text = ZFWeight.ToString();
        ZFWmoment = PartOne.PartOneTotalMom + Moment;
       

        if (ZFWmoment == 0)
        {
            ZFWstation = 0;
            decimal MACD = 0;
            DisplayMAC.text = MACD.ToString();

        }

        if (ZFWmoment >= 1)
       
        {

            ZFWstation = ZFWmoment / ZFWeight;
            ZFWMAC = ZFWstation - 793.6f;
            ZFWMAC /= 309.5f;
            ZFWMAC *= 100;
            float MACD = (float)Math.Round(ZFWMAC, 2);
            DisplayMAC.text = MACD.ToString();

        }

    }
        
    public void OpWtMoCalc()
    {
        OpMoment = PartOne.PartOneTotalMom;
        OpWeight = PartOne.PartOneTotalWt;
        OpWtOutout.text = PartOne.PartOneTotalWt.ToString();
        Debug.Log("OpWt =  " + OpMoment);

        if (OpMoment == 0)
        {
            OpWtStation = 0;
            decimal OpWs = 0;
            OpWtMoOutput.text = OpWs.ToString();

        }

        if (OpMoment >= 1)
        {


            OpWtStation = OpMoment / OpWeight;
            float OpWs = (float)Math.Round(OpWtStation, 0);
            OpWtMoOutput.text = OpWs.ToString();

        }

    }    





}
