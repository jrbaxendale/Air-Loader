using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehiclePanel : MonoBehaviour



{
    public GameObject VehiclesPanel;
    public Image circle;
  
    public bool bool2;
    
 


    public void Close()
    {
        VehiclesPanel.SetActive(false);
        circle.GetComponent<Image>().color = Color.white;


        bool2 = false;
    }




    public void Open()
    {
        if (bool2 == false)
        {
            
           
            VehiclesPanel.SetActive(true);
            circle.GetComponent<Image>().color = Color.green;


            bool2 = true;

        }


        else

        {
            if (bool2 == true)
            {

                VehiclesPanel.SetActive(false);
                circle.GetComponent<Image>().color = Color.white;


                bool2 = false;
            }



        }





    }
}