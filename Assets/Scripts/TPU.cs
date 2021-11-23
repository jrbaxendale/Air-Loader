using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class TPU : MonoBehaviour
{
    
    public GameObject TPUprefab;
    public GameObject MainCanvas;
    public  float weightint;
    public Button Btn;
    public TMP_InputField input;
    public float   Dec;
    public int Int;
    public bool check;

    private void Awake()
    {
        Btn.onClick.AddListener(MakeTPU);
       
    }

    
    public void MakeTPU()
    {

       
         
            GameObject TPUprefab1 = Instantiate(TPUprefab);
            TPUprefab1.transform.localPosition = new Vector3(0, 0.5f, 0);
            TPUprefab1.transform.localEulerAngles = new Vector3(-90, 0, 0);
            weightint = (float)Convert.ToDecimal(input.text);
            PartOne.PartOneTotalWt += weightint; // this adds the weight to the payload panel
            Debug.Log("TPU ADDED");
           
    }

}
