using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



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
    public  GameObject NOTOCscreen;
    public  GameObject BlurScreen;
    public  GameObject NOTOCline;
    public  GameObject MainCanvas;
    public  GameObject Container;
    

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
        BlurScreen = GameObject.Find("BlurGlass2");
        NOTOCscreen.GetComponent<Canvas>().enabled = !enabled;
        BlurScreen.GetComponent<MeshRenderer>().enabled = !enabled;
        MainCanvas = GameObject.Find("MainCanvas");
        MainCanvas.GetComponent<Canvas>().enabled = enabled;
        Container = GameObject.Find("Content");
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
        Container = GameObject.Find("Content");
        var q = EndingIndex - StartingIndex;
        ULDarray = new string[q][]; // this creates an array the exact size required
        var j = 0;
        for (var i = StartingIndex; i < EndingIndex ; i++)
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
            count++;
        }
       
    }

   

}









