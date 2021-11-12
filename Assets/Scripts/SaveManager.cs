using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveManager : MonoBehaviour
{
    



    public static void SaveTheLoad(string par, string id, string weight, string dest, string type) // this will save the pallet info and its pallet position

    { 
       
    
        
        if (par == "ADS1")

       

        {


        List<string> ADS1 = new List<string>();
            
            
            ADS1.Add(par);
            ADS1.Add(id);
            ADS1.Add(weight);
            ADS1.Add(dest);
            ADS1.Add(type);
            ES3.Save<List<string>>("ADS1", ADS1, "SaveFile.es3");
            Debug.Log("ADS1 List Saved");

           

        }


        if (par == "ADS2")



        {


            List<string> ADS2 = new List<string>();


            ADS2.Add(par);
            ADS2.Add(id);
            ADS2.Add(weight);
            ADS2.Add(dest);
            ADS2.Add(type);
            ES3.Save<List<string>>("ADS2", ADS2, "SaveFile.es3");
            Debug.Log("ADS2 List Saved");


        }








    }


}
