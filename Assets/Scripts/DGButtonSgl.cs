using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DGButtonSgl : MonoBehaviour
{
   
    public static bool DGbool;
    void Awake()
    {
        Toggle Btn = gameObject.GetComponent<Toggle>();
        //Btn.onClick.AddListener(DG);



    }

    public static void DG() 

    {
       if (DGbool == false)
        {
            DGbool = true;


        }

       else if (DGbool == true)
        {

            DGbool = false;
        }



    }

}
