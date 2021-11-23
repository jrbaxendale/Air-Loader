using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MakeLse : MonoBehaviour

{
   
    public GameObject Lseprefab;
    public GameObject MainCanvas;
    public static float weightint;



    public void MakeLSE()
    {
        
        GameObject Loose = Instantiate(Lseprefab) as GameObject;


        Loose.transform.localPosition = new Vector3(0, 0.1f, 0);
        Loose.transform.localScale = new Vector3(1, 1, 1);
        Loose.transform.localEulerAngles = new Vector3(0, 0, 0);
        GameObject obj = MainCanvas.transform.GetChild(0).transform.GetChild(1).gameObject;  // this is the weight input field on maincanvas, Lse Panel
        weightint = Int32.Parse(obj.GetComponent<TMP_InputField>().text.ToString());
        Payload.TotalPayloadWt += weightint; // this adds the weight to the payload panel
        Loose.GetComponent<DragDropBags>().WeightDisplay.text = obj.GetComponent<TMP_InputField>().text; // this transfers the weight to the object.




    }
}
