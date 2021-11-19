using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CBeditBtn : MonoBehaviour
{
    public GameObject EditCBpanel;
    public bool Bool;


    public void MakeManualCBpanel()

    {
       if (Bool == false)
       {
           GameObject CBpanel = Instantiate(EditCBpanel);
           Bool = true;
       }

       else if (Bool)

       {
            GameObject cbPanel = GameObject.Find("CBpanel(Clone)");
            Destroy(cbPanel);
            Bool = false;
       }


    }



    public void ManualFSinput()
    {
        
        TMP_InputField ManualCBinput = gameObject.transform.GetChild(3).transform.GetChild(12).gameObject
            .GetComponent<TMP_InputField>();

        var CBText = ManualCBinput.GetComponent<TMP_InputField>().text;

        if (!string.IsNullOrWhiteSpace(CBText))
        {

           Raycast.target.GetComponent<ACP_PayloadDBL>().distanceEdited = Int32.Parse(CBText);

        }

      


    }






}
