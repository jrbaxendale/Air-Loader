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
    public string ULDname;
    


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

                if (data[i][0].Trim().Equals(data[2][ACPindex].Trim())) // this checks the first column for the uldid 

                {
                    StartingIndex = i;
                    ULDchar = data[i][0].ToCharArray(); // this takes the ULD name so we can convert to a char array and find the next pallet number
                    int IntArray = Int32.Parse(ULDchar[3].ToString());
                    IntArray += 1;
                    char j = (char)IntArray;
                    ULDchar[3] = j; // this is the next ULD number e.g we have gone from 'ULD1' to ULD2'.
                    SearchFirstColumnForStart();
                     SearchFirstColumnforEnd();
                     CreateULDarray();
                }

            }

            
        }
        

    }

    public void SearchFirstColumnForStart()

    {
           

        for ( var i = 0 ; i < data.Length; i++)
        {

            if (data[i][0].Trim().Equals(data[2][ACPindex].Trim())) // this checks the first column for the uldid 

            {
                StartingIndex = i;
                ULDchar = data[i][0]
                    .ToCharArray(); // this takes the ULD name so we can convert to a char array and find the next pallet number
                int IntArray = Int32.Parse(ULDchar[3].ToString());
                IntArray += 1;
                char j = (char) IntArray;
                ULDchar[3] = j; // this is the next ULD number e.g we have gone from 'ULD1' to ULD2'.

            }
            
        }
        
    }

    public void SearchFirstColumnforEnd()

    {

        for (var i = 0; i < data.Length; i++)
        {
            if (data[i][0].Trim().Equals(ULDchar.ToString().Trim())) // this checks data row 0 for ULD name
            {
                EndingIndex = i;
                i = data.Length; // this stops the rest of the search
            }


        }
        
    }

    public void CreateULDarray()

    {
       
        ULDarray = new string[13][];
        ULDarray[0] = new string[10];
        ULDarray[1] = new string[10];
        ULDarray[2] = new string[10];
        ULDarray[3] = new string[10];
        ULDarray[4] = new string[10];
        ULDarray[5] = new string[10];
        ULDarray[6] = new string[10];
        ULDarray[7] = new string[10];
        ULDarray[9] = new string[10];
        ULDarray[10] = new string[10];
        ULDarray[11] = new string[10];
        ULDarray[12] = new string[10];
        ULDarray[13] = new string[10];



        var j = 0;
        for (var i = StartingIndex; i < EndingIndex; i++)
        {
           
            ULDarray[j++] = data[i]; // this cuts out the relevent part of the data array into the ULD array;
            Debug.Log(ULDarray[j++]);

        }

        Debug.Log("Array should equal...." + ULDarray[0][2] );
    }
}









