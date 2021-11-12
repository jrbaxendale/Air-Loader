using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject SingleACP;
    public List<string> TheList;
    public string[] TheListArray;
    public GameObject Maincanvas;
    public Material Invisible;
    public Material HighlightedACP;
    public Material ADSMat;
    public Material LogsMat;

    public void Awake()
    {

        TheList = new List<string>();
       Maincanvas = GameObject.Find("MainCanvas");

    }

    public void LoadtheKey(string par, string id, string weight, string dest, string type) // this will create a list identical to the saved list from the LoadTheSave method below

    {
  
        
        if (par == "ADS1")

        {

            List<string> ADS1 = new List<string>();

            ADS1.Add(par);
            ADS1.Add(id);
            ADS1.Add(weight);
            ADS1.Add(dest);
            ADS1.Add(type);
            Debug.Log("ADS1 LIST LOADED");
            GameObject ads1 = Instantiate(SingleACP); // instantiates a single pallet (but the pallet is a varient of the original as it has lots of components turned off due to interferance 
            ads1.name = "ACP(Clone)";
            GameObject TheParent = GameObject.Find(ADS1[0]); // identifies who the pallet needs to be parented with
            ads1.transform.SetParent(TheParent.transform.GetChild(0).transform); // sets the parent of the pallet
            ads1.gameObject.transform.localPosition = new Vector3(0, 0, 2.37f); // sets the position
            ads1.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0); // sets the angle
            ads1.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text = ADS1[2]; // this transfers the weight figure from the List to the weight display on the pallet
            ads1.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TMP_Text>().text = ADS1[3]; // this transfers the destination string from the List to the destination display on the pallet
            ads1.transform.GetChild(0).GetChild(2).gameObject.GetComponent<TMP_Text>().text = ADS1[1]; // this transfers the Pallet ID from the List to the Pallet ID display on the pallet
            Debug.Log("Instantiated PALLET");
            ads1.layer = LayerMask.NameToLayer("ADS"); // pallet goes on ADS layer.
            ads1.GetComponent<Contact>().placed = true; // sets the placed value to true so other pallets know the position is occupied
            ads1.GetComponent<Rigidbody>().isKinematic = true;// sets the pallet kinematic to true (otherwise it floats off...)
            ads1.transform.parent.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the pallet positions collider
            ads1.tag = "loaded"; // pallet tag is loaded
            ads1.layer = LayerMask.NameToLayer("loaded"); // pallet layer is loaded
            ads1.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = !enabled; // thjis turns of the orange glow animation
            ads1.transform.parent.gameObject.tag = "loaded"; // this puts the pallet positions collider tag as loaded
            ads1.transform.parent.parent.gameObject.tag = "loaded"; // this sets the pallet positions tag as loaded
            ads1.transform.parent.gameObject.layer = LayerMask.NameToLayer("nohit"); // this sets the pallet positions layer to 'nohit' 
            ads1.transform.parent.transform.parent.gameObject.layer = LayerMask.NameToLayer("loaded"); // this sets the pallet position layer to loaded
            Maincanvas.GetComponent<RaycastOff>().TurnOnRaycast(); // this turns the raycast back on now that the pallet is placed
            ads1.transform.parent.parent.GetComponent<Renderer>().material = Invisible; // this turns the pallet position material to invisible
            ads1.GetComponent<ACPpayload>().Title = par; // this sets the ACPpayload title value to the par value
            ads1.GetComponent<ACPpayload>().GetTitle();

        }

        if (par == "ADS2")

        {

            List<string> ADS2 = new List<string>();

            ADS2.Add(par);
            ADS2.Add(id);
            ADS2.Add(weight);
            ADS2.Add(dest);
            ADS2.Add(type);
            Debug.Log("ADS2 LIST LOADED");
            
        }

    }

    public void LoadTheSave() // Loads the saved file
    {
      
        
      var es3LoadFile = new ES3File("SaveFile.es3"); // load the keys from a file
        TheListArray = es3LoadFile.GetKeys(); // gets the keys from the save file and puts them in TheListArray
       
        
        foreach( string key in TheListArray) // creates a string called key for every entry in TheListArray
        {
           List<string> AkeyList = ES3.Load<List<string>>(key);  // creates a List<string> called AkeyList for every entry in TheListArray
            var parent = AkeyList[0];
            var Id = AkeyList[1];
            var Weight = AkeyList[2];
            var Dest = AkeyList[3];
            var Type = AkeyList[4];
           
            LoadtheKey(parent, Id, Weight, Dest, Type); //This transfers the information from the list created above (sourced from the save file) and puts it into the LoadtheKey method
            Debug.Log("New Key Loaded");
        }

        
       









       



    }

}
