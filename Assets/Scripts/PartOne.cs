using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PartOne : MonoBehaviour
{
   
    public GameObject BasicAircraftWtIn;
    public GameObject CrewWtIn;
    public GameObject BaggageWtIn;
    public GameObject StewardsWtIn;
    public GameObject EmergWtIn;
    public GameObject ExtraWtIn;

    public GameObject BasicAircraftMomIn;
    public GameObject CrewMomIn;
    public GameObject BaggageMomIn;
    public GameObject StewardsMomIn;
    public GameObject EmergMomIn;
    public GameObject ExtraMomIn;

    public float BasicAcWt;
    public float CrewWt;
    public float BaggageWt;
    public float StewardsWt;
    public float EmergWt;
    public float ExtraWt;

    public float BasicAcMom;
    public float CrewMom;
    public float BaggageMom;
    public float StewardsMom;
    public float EmergMom;
    public float ExtraMom;

    public static float PartOneTotalWt;
    public static float PartOneTotalMom;

    public bool Part1Active;
    public GameObject MainCanvas;
    public GameObject BlurGlass;
    public GameObject Part1Canvas;
    public GameObject Part1;
    public Image circle;

    public void Awake()
    {
        Part1Active = false;
       
        Part1.SetActive(true);
        PartOneCalc();
    }

  



    public void PartOneCalc()
    {
        BasicAcWt = Int32.Parse(BasicAircraftWtIn.GetComponent<TMP_InputField>().text.ToString());
        CrewWt = Int32.Parse(CrewWtIn.GetComponent<TMP_InputField>().text.ToString());
        BaggageWt = Int32.Parse(BaggageWtIn.GetComponent<TMP_InputField>().text.ToString());
        StewardsWt = Int32.Parse(StewardsWtIn.GetComponent<TMP_InputField>().text.ToString());
        EmergWt = Int32.Parse(EmergWtIn.GetComponent<TMP_InputField>().text.ToString());
        ExtraWt = Int32.Parse(ExtraWtIn.GetComponent<TMP_InputField>().text.ToString());

        PartOneTotalWt = BasicAcWt + CrewWt + BaggageWt + StewardsWt + EmergWt + ExtraWt; // this calculates the part one total
        Debug.Log("Part One Weight = " + PartOneTotalWt);

        BasicAcMom = Int32.Parse(BasicAircraftMomIn.GetComponent<TMP_InputField>().text.ToString());
        CrewMom = Int32.Parse(CrewMomIn.GetComponent<TMP_InputField>().text.ToString());
        BaggageMom = Int32.Parse(BaggageMomIn.GetComponent<TMP_InputField>().text.ToString());
        StewardsMom = Int32.Parse(StewardsMomIn.GetComponent<TMP_InputField>().text.ToString());
        EmergMom = Int32.Parse(EmergMomIn.GetComponent<TMP_InputField>().text.ToString());
        ExtraMom = Int32.Parse(ExtraMomIn.GetComponent<TMP_InputField>().text.ToString());

        PartOneTotalMom = (BasicAcMom + CrewMom + BaggageMom + StewardsMom + EmergMom + ExtraMom) * 10000; // this calculates the part one total
        Debug.Log("Part One Moment = " + PartOneTotalMom);

       
        BlurGlass.SetActive(false);
        MainCanvas.GetComponent<Canvas>().enabled = enabled;
        Part1Active = false;
        circle.GetComponent<Image>().color = Color.white;
        Part1Canvas.SetActive(false);






    }

    public void PartOneDetails() // this controls the panels appearing


    {

        MainCanvas.GetComponent<Canvas>().enabled = !enabled;
            BlurGlass.SetActive(true);
            Part1Canvas.SetActive(true);
            Part1Active = true;
            circle.GetComponent<Image>().color = Color.green;





    }

    public void ClosePartOnePanel()
    {
       
        BlurGlass.SetActive(false);
        MainCanvas.GetComponent<Canvas>().enabled = enabled;
        Part1Active = false;
        circle.GetComponent<Image>().color = Color.white;
        Part1Canvas.SetActive(false);

    }

}
