using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Testing : MonoBehaviour
{
   
    public TMP_Text TheWeight;
    public TMP_Text TheNewWeight;
    public GameObject TheTestObject;
    public GameObject TheNewTestObject;
    public Transform TheOtherTransform;
    public GameObject Cube;
    public GameObject ACP1;
    public static String ParentPos;
    public Transform MySphere;
    public Transform Cubey;


    //public GameObject MakeACPscript;

   // public void saving()
   // {


       // TheTestObject = GameObject.Find("ACP(Clone)");
       // TheOtherTransform = TheTestObject.transform;

      //  TheWeight.text = makeACP.weight.text;
       // Debug.Log(TheWeight.text);
        
       

    //}

   
    public void Loading()

    {
        if (ES3.KeyExists("gameobject"))
        {
           Debug.Log("The Key Exists");
         MySphere =  ES3.Load<Transform>("gameobject", MySphere.transform); // Mysphere is a simple cube
           Debug.Log("Loaded success");
        }

        else
        {
            Debug.Log("No Key");
        }

    }

    public void SaveBtn()
    
    {
        ES3.Save<Transform>("gameobject", Cubey.transform); // cubey is another, smaller, cube
        Debug.Log("SavedSuccess");

    }

  
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // public void AddPallet()
    // {
    //  Instantiate(Cube);

    //  ES3.Save<TMP_Text>("Theweight", TheWeight);
    //  TheNewWeight = ES3.Load<TMP_Text>("Theweight");
    //  }



}
