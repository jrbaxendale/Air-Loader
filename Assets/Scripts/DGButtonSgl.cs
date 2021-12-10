using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DGButtonSgl : MonoBehaviour
{
   
    public bool DGbool;
    void Awake()
    {
        Toggle Btn = gameObject.GetComponent<Toggle>();
        //Btn.onClick.AddListener(DG);



    }

    public  void DG() 

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
