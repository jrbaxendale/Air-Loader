using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MakePaxBags : MonoBehaviour
{

    public GameObject PaxBagsprefab;
    public GameObject MainCanvas;
    public static decimal Bagweightint;

    public void MakePAXbags()
    {

        GameObject PAXbagprefab1 = Instantiate(PaxBagsprefab) as GameObject;
        PAXbagprefab1.transform.localPosition = new Vector3(0, 0.5f, 0);
        PAXbagprefab1.transform.localEulerAngles = new Vector3(0, 90, 0);
        GameObject obj = MainCanvas.transform.GetChild(22).transform.GetChild(0).gameObject;  // this is the weight input field on maincanvas, Pax bags Panel
        Bagweightint = Int32.Parse(obj.GetComponent<TMP_InputField>().text.ToString());
        Payload.TotalPayloadWt += Bagweightint; // this adds the weight to the payload panel
       // PAXbagprefab1.GetComponent<DragDropBags>().WeightDisplay.text = obj.GetComponent<TMP_InputField>().text; // this transfers the weight to the object.





    }



}
