using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using Object = System.Object;


public class Clipboard : MonoBehaviour
{

    public static string[][] data;
    public string ACPID1;
    public int ACPindex;
    public int StartingIndex;
    public int EndingIndex;
    public char[] ULDchar;
    public static string[][] ULDarray;
    public static TextMeshProUGUI[][] DisplayArray;
    public string ULDname;
    public string ULDstring;
    public static TextMeshProUGUI LINE00;
    public static TextMeshProUGUI LINE01;
    public static TextMeshProUGUI LINE02;
    public static TextMeshProUGUI LINE03;
    public static TextMeshProUGUI LINE04;
    public static TextMeshProUGUI LINE10;
    public static TextMeshProUGUI LINE11;
    public static TextMeshProUGUI LINE12;
    public static TextMeshProUGUI LINE13;
    public static TextMeshProUGUI LINE14;
    public TextMeshProUGUI LINE20;
    public TextMeshProUGUI LINE21;
    public TextMeshProUGUI LINE22;
    public TextMeshProUGUI LINE23;
    public TextMeshProUGUI LINE24;
    public TextMeshProUGUI LINE30;
    public TextMeshProUGUI LINE31;
    public TextMeshProUGUI LINE32;
    public TextMeshProUGUI LINE33;
    public TextMeshProUGUI LINE34;
    public TextMeshProUGUI LINE40;
    public TextMeshProUGUI LINE41;
    public TextMeshProUGUI LINE42;
    public TextMeshProUGUI LINE43;
    public TextMeshProUGUI LINE44;
    public GameObject NOTOCscreen;
    public GameObject BlurScreen;
    public GameObject NOTOCline;
    

    public void ActivateDisplay()

    {
        NOTOCscreen = GameObject.Find("NotocDisplay");
        BlurScreen = GameObject.Find("BlurGlass2");
        
        NOTOCscreen.GetComponent<Canvas>().enabled = enabled;
        BlurScreen.GetComponent<MeshRenderer>().enabled = enabled;
       
       // LINE10 = GameObject.Find("LINE10").GetComponent<TextMeshProUGUI>();
       // LINE11 = GameObject.Find("LINE11").GetComponent<TextMeshProUGUI>();
       // LINE12 = GameObject.Find("LINE12").GetComponent<TextMeshProUGUI>();
       // LINE13 = GameObject.Find("LINE13").GetComponent<TextMeshProUGUI>();
       // LINE14 = GameObject.Find("LINE14").GetComponent<TextMeshProUGUI>();
        
    }

    
    public void ImportNOTOC()

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

    public void CheckforPalletRef()
        
    {
        Debug.Log("Checking for ACPID");
       
        ACPID1 = Raycast.target.transform.GetChild(0).transform.GetChild(0)
            .gameObject.GetComponent<ACPpayload>().ACPID; // this is the ID of a pallet
        
        for (var i = 0; i < data[2].Length; i++)
        {
            if (data[2][i].Contains(ACPID1)) // this checks data row 2 for the acpid
            {
                Debug.Log("ACPID CONFIRMED");
                ACPindex = i - 1;
                ULDname = data[2][ACPindex];
                ULDname.Trim();
                
                SearchFirstColumnForStart();
                SearchFirstColumnforEnd();
                CreateULDarray();
                    
                

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
                    Debug.Log("ULDchar = " + ULDchar.ToString());
                    var IntArray = Int32.Parse(ULDchar[3].ToString());
                    Debug.Log("Int Array =" + IntArray);
                IntArray += 1;
                Debug.Log("IntArray " + IntArray);
                char j = IntArray.ToString()[0];

                Debug.Log("J = " + j);
                ULDchar[3] = j; // this is the next ULD number e.g we have gone from 'ULD1' to ULD2'.
                ULDstring = String.Concat(ULDchar[0], ULDchar[1], ULDchar[2], ULDchar[3]);
                Debug.Log("ULDstring = " + ULDstring);

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
        ULDarray = new string[14][];
      /*  
        DisplayArray = new TextMeshProUGUI[10][];
        DisplayArray[0] = new TextMeshProUGUI[5];
        DisplayArray[1] = new TextMeshProUGUI[5];
        DisplayArray[2] = new TextMeshProUGUI[5];
        DisplayArray[3] = new TextMeshProUGUI[5];
        DisplayArray[4] = new TextMeshProUGUI[5];
        DisplayArray[5] = new TextMeshProUGUI[5];
        DisplayArray[6] = new TextMeshProUGUI[5];

        */

        LINE00 = GameObject.Find("LINE00").GetComponent<TextMeshProUGUI>();
        LINE01 = GameObject.Find("LINE01").GetComponent<TextMeshProUGUI>();
        LINE02 = GameObject.Find("LINE02").GetComponent<TextMeshProUGUI>();
        LINE03 = GameObject.Find("LINE03").GetComponent<TextMeshProUGUI>();
        LINE04 = GameObject.Find("LINE04").GetComponent<TextMeshProUGUI>();

        DisplayArray[0][0] = LINE00;
        DisplayArray[0][1] = LINE01;
        DisplayArray[0][2] = LINE02;
        DisplayArray[0][3] = LINE03;
        DisplayArray[0][4] = LINE04;
        
        var j = 0;
        for (var i = StartingIndex; i < EndingIndex ; i++)
        {
            ULDarray[j] = new string[5];
            ULDarray[j] = data[i]; // this cuts out the relevent part of the data array into the ULD array;
            j++;
        }

       
        for (var h = 0; h < ULDarray.Length; h++) // this creates a NOTOC line in the GUI
        {
            GameObject NotocLine = Instantiate(NOTOCline, NOTOCscreen.transform.GetChild(0));
            NotocLine.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ULDarray[h][h + 1]; // this populates the display notoc
            NotocLine.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ULDarray[h][h + 2]; // this populates the display notoc
            NotocLine.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ULDarray[h][h + 3]; // this populates the display notoc
            NotocLine.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ULDarray[h][h + 4]; // this populates the display notoc
            
        }


    }

   

}









