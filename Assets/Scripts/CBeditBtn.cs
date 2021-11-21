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
            Destroy(gameObject.transform.parent.transform.gameObject);

        }


    



    public void ManualFSinput()
    {
        
       // TMP_InputField ManualCBinput = GameObject.FindWithTag("SelectedPanel").gameObject.transform.GetChild(3).transform.GetChild(12).gameObject
         //   .GetComponent<TMP_InputField>(); ..... THIS IS WRONG and should be the new CBedit Panel...

        var CBText = ManualCBinput.GetComponent<TMP_InputField>().text;

        if (!string.IsNullOrWhiteSpace(CBText))
        {

           Raycast.target.GetComponent<ACP_PayloadDBL>().distanceEdited = Int32.Parse(CBText);

        }

      


    }






}
