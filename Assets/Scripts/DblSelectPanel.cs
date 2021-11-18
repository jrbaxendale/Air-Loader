using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class DblSelectPanel : MonoBehaviour
{
    public GameObject CombinedWeightInput;
    public GameObject FWDweightInput;
    public GameObject AFTweightInput;
    public decimal weightFwd;
    public decimal weightAft;
    public decimal CombinedWt;
    public decimal palletint;
    public GameObject WarningText;
    public decimal tot;

    public bool FwdWtCheck() // checks if a value is put into the fwd wt input

    {
       
        var text = FWDweightInput.GetComponent<TMP_InputField>().text; 

        if (string.IsNullOrEmpty(text))
        {
            return false;

        }
        else
        {
            weightFwd = Int32.Parse(FWDweightInput.GetComponent<TMP_InputField>().text);
            return true;
        }
    }

    public bool AftWtCheck() // checks if a value is put into the aft input

    {
       
        

        var text = AFTweightInput.GetComponent<TMP_InputField>().text; 

        if (string.IsNullOrEmpty(text))
        {
            return false;

        }
        
        else
        {
            weightAft = Int32.Parse(AFTweightInput.GetComponent<TMP_InputField>().text);
            return true;
        }
    }

    public bool CombinedWeightCheck()

    {
        var text = CombinedWeightInput.GetComponent<TMP_InputField>().text; // total weight
        bool Weight = !string.IsNullOrEmpty(text);

        if (Weight) // so we have an input wt;

        {
            bool Fwd = FwdWtCheck();
            bool Aft = AftWtCheck();

            if (Fwd && Aft)
            {

                CombinedWt = Int32.Parse(CombinedWeightInput.GetComponent<TMP_InputField>().text.ToString());
                return true;

            }
        }
        else

        {
            return false;
        }

        return false;
    }


   
    void Update()
    {
       
        bool TotalWeightbool = CombinedWeightCheck();

        if (TotalWeightbool) // this means we have a total weight

        {
            
            
            tot = weightFwd + weightAft;

            if (tot == CombinedWt)

            {
                WarningText.SetActive(false); // this tells the operator that the total weight does not equal the two individual weights;

            }
          
          else if (tot != CombinedWt)

          {
              WarningText.SetActive(true);
          }
        }

        if (TotalWeightbool == false) // this means we do not have a total weight


        {
            WarningText.SetActive(false); // this tells the operator that the total weight does not equal the two individual weights;

        }


        
    }
}
