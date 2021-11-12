using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class MakeCrewBags : MonoBehaviour
{
    public GameObject CrewBagPanel;

    public GameObject WhichPanel;
    public bool bool2;
    public PalletPanelClose Pallet;
    public TPUPalletControl Tpu;
    public GameObject CrewBagsprefab;
    public GameObject MainCanvas;
    public static decimal Bagweightint;
    public Image circle;



    public void ClosePaxBags()
    {
        CrewBagPanel.SetActive(false);
        circle.GetComponent<Image>().color = Color.white;
        bool2 = false;
    }




    public void OpenCrewBags()
    {
       
        if (bool2 == false)
        {
            Tpu.CloseTpu();
            Pallet.ClosePallet();
            CrewBagPanel.SetActive(true);
            circle.GetComponent<Image>().color = Color.green;
            WhichPanel.SetActive(false);
            bool2 = true;

        }


        else

        {
            if (bool2 == true)
            {

                CrewBagPanel.SetActive(false);
                circle.GetComponent<Image>().color = Color.white;
                bool2 = false;
            }



        }





    }

    public void AddCrewbaggage()
    {

        GameObject Crewbagprefab1 = Instantiate(CrewBagsprefab) as GameObject;
        Crewbagprefab1.transform.localPosition = new Vector3(0, 0.5f, 0);
        Crewbagprefab1.transform.localEulerAngles = new Vector3(0, 90, 0);
        GameObject obj = MainCanvas.transform.GetChild(23).transform.GetChild(1).gameObject;  // this is the weight input field on maincanvas, Tpu Panel
        Bagweightint = Int32.Parse(obj.GetComponent<TMP_InputField>().text.ToString());
        Payload.TotalPayloadWt += Bagweightint; // this adds the weight to the payload panel
    }



}
