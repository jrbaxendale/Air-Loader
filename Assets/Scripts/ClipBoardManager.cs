using LinqToExcel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ClipBoardManager : MonoBehaviour
{
    private TextEditor t;
    public string content;
    public string ULD;
    public string ULDnumber;


    void awake()

    {
       

    }


    public void GetClipBoardData()

    {   content = GUIUtility.systemCopyBuffer;
        Debug.Log("ClipData is" + content);
    }

    public void GetDataBase()
    {
        var excel = new ExcelQueryFactory(content);
        excel.AddMapping("ULDnumber", "ULD:");
        var spreadsheet =
            from c in
                excel.WorksheetRange<ClipBoardManager>("A9",
                    "E15") // A9 denotes the top left of the range and e15 the bottom right
            where c.ULDnumber == "A9"
            select c;
    }
}

