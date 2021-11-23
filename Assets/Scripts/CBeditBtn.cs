using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CBeditBtn : MonoBehaviour
{
    public GameObject EditCBpanel;
    public bool Bool;
    public GameObject MainCanvas;

    public void Awake()
    {
        Bool = false;
        MainCanvas = GameObject.Find("MainCanvas").gameObject;


    }







    public void MakeManualCBpanel()

    {
        
            Debug.Log("Creating EditPanelCB");
            GameObject CBpanel = 
            Instantiate(EditCBpanel, MainCanvas.transform, false);
            CBpanel.transform.SetParent(MainCanvas.transform);

    }



    public void CloseCBpanel() 


        {
            Destroy(gameObject);

        }


    



    public void ManualFSinput()
    {
        
        TMP_InputField ManualCBinput = gameObject.transform.GetChild(1).transform
            .GetComponent<TMP_InputField>(); 

        var CBText = ManualCBinput.GetComponent<TMP_InputField>().text;

        if (!string.IsNullOrWhiteSpace(CBText))
        {
            GameObject.Find("SelectedPanelDBL(Clone)").gameObject.transform.GetChild(3).gameObject.GetComponent<DBLcheckButtons>()
                .SelectedACP.gameObject
            .GetComponent<ACP_PayloadDBL>().distanceEdited = Int32.Parse(CBText);
           
        }

      


    }






}
