using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class Clipboard : MonoBehaviour
{

    public static string[][] data;



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
        Debug.Log("initial test +  " + data[1][2]);
    }

    public void CheckforPalletRef()


    {
        Debug.Log("second test +  " + data[2][0]);

        if (data[2][5].Contains("30010040"))
        {
            Debug.Log("Successful search");
            string[] a = data[2];

            string b = Array.Find(a, ele => ele.Equals("30010040")); // checks the value is there
            int ACPindex = Array.IndexOf(a, "30010040"); // gets the index
            string c = a[ACPindex - 1]; // gets the preceding index
            if (b == "30010040")
            {
                Debug.Log("Found it!");
            }
        }

        else
        {
            Debug.Log("failed search");

        }
    }

}

   


    // Start is called before the first frame update
   

