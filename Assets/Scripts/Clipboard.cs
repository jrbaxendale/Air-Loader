using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Clipboard : MonoBehaviour // this has all the NOTOC stuff on
{

    public static string[][] data;
    public string ACPID1;
    public int ACPindex;
    public int StartingIndex;
    public int EndingIndex;
    public char[] ULDchar;
    public static string[][] ULDarray;
    public List<GameObject> CheckedArray;
    public static TextMeshProUGUI[][] DisplayArray;
    public string ULDname;
    public string ULDstring;
    public  GameObject NOTOCscreen;
    public  GameObject BlurScreen;
    public  GameObject NOTOCline;
    public  GameObject MainCanvas;
    public  GameObject Container;
    public int NotocButtonCount;
    public GameObject PalletButton;
    public int BtnNumbers;

    public void Awake()
    {
        NotocButtonCount = 0;
        BtnNumbers = 0;


    }
    public void ActivateDisplay()

    {
        NOTOCscreen = GameObject.Find("NotocDisplay");
        BlurScreen = GameObject.Find("BlurGlass2");
        NOTOCscreen.GetComponent<Canvas>().enabled = enabled;
        BlurScreen.GetComponent<MeshRenderer>().enabled = enabled;
        MainCanvas = GameObject.Find("MainCanvas");
        MainCanvas.GetComponent<Canvas>().enabled = !enabled;
        Container = GameObject.Find("Content");
        Container.SetActive(true);

    }

    public void DeactivateDisplay()

    {
       
        
        NOTOCscreen = GameObject.Find("NotocDisplay");
        MainCanvas = GameObject.Find("MainCanvas");
        Container = GameObject.Find("Content");
        BlurScreen = GameObject.Find("BlurGlass2");

        if (NOTOCscreen.gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            return;

        }

       
        
            NOTOCscreen.GetComponent<Canvas>().enabled = !enabled;
            BlurScreen.GetComponent<MeshRenderer>().enabled = !enabled;
            MainCanvas.GetComponent<Canvas>().enabled = enabled;
            Container.SetActive(false);
        
    }

    public void ImportNOTOC()

    {
        if (File.Exists(@"C:\Users\jrbax\OneDrive\Desktop\test.txt"))
        {
           
            data = new string[30][];
            string filePath = @"C:\Users\jrbax\OneDrive\Desktop\test.txt";
            StreamReader sr = new StreamReader(filePath);
            var lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                lines.Add(Line);
                Row++;

            }

            data = lines.ToArray();
            Debug.Log("NOTOC IMPORTED");
        }

        else if (!File.Exists(@"C:\Users\jrbax\OneDrive\Desktop\test.txt"))

        {
            Debug.Log("No NOTOC FOUND");

        }
    }

   
    public void CheckforPalletRef()
        
    {
        Debug.Log("Checking for ACPID");
       

        
        for (var i = 0; i < data[2].Length; i++)
        {
            if (data[2][i].Contains(ACPID1)) // this checks data row 2 for the acpid
            {
                Debug.Log("ACPID CONFIRMED");
                ACPindex = i - 1;
                ULDname = data[2][ACPindex];
                ULDname.Trim();
                
               
                PalletButton = Resources.Load("Pallet ID Btn") as GameObject;
                NOTOCline = Resources.Load("NotocParent") as GameObject;
                GameObject PalletBtn = Instantiate(PalletButton, NOTOCscreen.transform.GetChild(0).transform);
                PalletBtn.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ACPID1;
                BtnNumbers += 1;
                PositionBtns(PalletBtn);

                if (ULDarray == null)
                {
                    SearchFirstColumnForStart();
                    SearchFirstColumnforEnd();
                    CreateULDarray();
                }

                else if (ULDarray != null)

                {
                    CheckULDarray();

                }
            }
            
        }
        
    }

    public void SearchFirstColumnForStart()

    {
        Debug.Log("Searching for First Column");

        for ( var i = 0 ; i < data.Length; i++)
        {

            if (data[i][0].Trim() == (data[2][ACPindex].Trim())) // this checks the first column for the uldid 

            {
                StartingIndex = i;
                ULDchar = data[i][0].ToCharArray();
                var IntArray = int.Parse(ULDchar[3].ToString());
                IntArray += 1;
                char j = IntArray.ToString()[0];
                ULDchar[3] = j; // this is the next ULD number e.g we have gone from 'ULD1' to ULD2'.
                ULDstring = string.Concat(ULDchar[0], ULDchar[1], ULDchar[2], ULDchar[3]);
               
            }
            
        }
        
    }

    public void SearchFirstColumnforEnd()

    {
        Debug.Log("Searching for Final Column");
        for (var i = 0; i < data.Length; i++)
        {
            if (data[i][0].Trim() == (ULDstring.Trim())) // this checks data row 0 for ULD name
            {
               Debug.Log("ULDstring search = " + ULDstring);
                EndingIndex = i;
                i = data.Length; // this stops the rest of the search
            }


        }
        
    }

    public void CreateULDarray()

    {
        Debug.Log("Creating Final Array");
        NOTOCline = Resources.Load("NotocParent") as GameObject;
        Container = GameObject.Find("Content");
        var q = EndingIndex - StartingIndex;

      
        
            ULDarray = new string[q][]; // this creates an array the exact size required
            CheckedArray = new List<GameObject>(); // this holds the details of which notoc lines have been checked;
            var j = 0;
            for (var i = StartingIndex; i < EndingIndex; i++)
            {
                ULDarray[j] = new string[5];
                ULDarray[j] = data[i]; // this cuts out the relevent part of the data array into the ULD array;
                j++;
            }

            int count = 0;
            foreach (var a in ULDarray)
            {
                GameObject NotocLine = Instantiate(NOTOCline, Container.transform);
                
                NotocLine.transform.localPosition = new Vector3(NotocLine.transform.localPosition.x, count * -20,
                    NotocLine.transform.localPosition.z);
                NotocLine.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                NotocLine.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = a[1];
                NotocLine.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = a[2];
                NotocLine.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = a[3];
                NotocLine.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = a[4];
                CheckedArray.Add(NotocLine); // this is to hold a record so we can see if each has been checked
                count++;
            }
        
            

    }

    




        public void CheckAllNOTOCs() // The notoc parent buttons run this
        {

            if (NotocButtonCount == ULDarray.Length)
            {
              NOTOCscreen.transform.GetChild(1).gameObject.SetActive(true);
            GameObject.FindWithTag("DG").gameObject.GetComponent<Image>().color = Color.green;
            var p = GameObject.FindWithTag("DG").gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            p.color = Color.green;

            switch (Raycast.target.name)
            {

                case "ACP(Clone)":
                    Raycast.target.GetComponent<ACPpayload>().dg = true;
                    break;

                case "ADSdouble(Clone)":
                    Raycast.target.GetComponent<ACP_PayloadDBL>().dg = true;
                    break;

                case "LOGSdbl(Clone)":
                    Raycast.target.GetComponent<ACP_PayloadDBL>().dg = true;
                    break;

                case "TripleLOGS(Clone)":
                    Raycast.target.GetComponent<ACP_PayloadTPL>().dg = true;
                    break;

                case "TRIPLEADS(Clone)":
                    Raycast.target.GetComponent<ACP_PayloadTPL>().dg = true;
                    break;

                case "QUADADS(Clone)":
                    Raycast.target.GetComponent<ACP_PayloadQD>().dg = true;
                    break;

                case "QUADLOGSbase(Clone)":
                    Raycast.target.GetComponent<ACP_PayloadQD>().dg = true;
                    break;

            }


        }
       

        }


        public void PositionBtns(GameObject Btn)
        {
            switch (BtnNumbers)
            {

            case 1:
                break;

            case 2:
                Btn.transform.localPosition = new Vector3(Btn.transform.localPosition.x + 360, Btn.transform.localPosition.y, Btn.transform.localPosition.z);
                break;

            case 3:
                 Btn.transform.localPosition = new Vector3(Btn.transform.position.x + 720, Btn.transform.position.y, Btn.transform.position.z);
                 break;

            case 4:
                Btn.transform.localPosition = new Vector3(Btn.transform.position.x + 1080, Btn.transform.position.y, Btn.transform.position.z);
                break;

            }

    }


        public void CheckULDarray() // checks if notoc lines have already been checked and display them
        {

            int count = 0;
        foreach (var a in CheckedArray)
        {
            if (a.GetComponent<NotocLineBtn>().CheckedBool)

            {
                GameObject NotocLine = Instantiate(NOTOCline, Container.transform);

                a.transform.localPosition = new Vector3(NotocLine.transform.localPosition.x, count * -20,
                    NotocLine.transform.localPosition.z);
                TextMeshProUGUI d = NotocLine.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                d.color = Color.green;
                TextMeshProUGUI e = NotocLine.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                e.color = Color.green;
                TextMeshProUGUI f = NotocLine.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                f.color = Color.green;
                TextMeshProUGUI g = NotocLine.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
                g.color = Color.green;
                TextMeshProUGUI h = NotocLine.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
                h.color = Color.green;
                count++;
            }
           
            

        }
    
    
    
    
    
    
}
    
    
    
    












