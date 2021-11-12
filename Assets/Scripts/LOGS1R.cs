using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS1R : MonoBehaviour
{
    public GameObject ADS1;
    public GameObject ADS2;
    public GameObject Seat1R;
   // public GameObject Seat1L;
    public GameObject Seat2R;
   // public GameObject Seat2L;
    public GameObject Seat3R;
    //public GameObject Seat3L;
    public GameObject Seat4R;
   // public GameObject Seat4L;

        



    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

           
            Seat1R.SetActive(false);
            
            Seat2R.SetActive(false);
          
            Seat3R.SetActive(false);
           
            Seat4R.SetActive(false);
            ADS1.SetActive(false);
            ADS2.SetActive(false);


        }


    }

}
