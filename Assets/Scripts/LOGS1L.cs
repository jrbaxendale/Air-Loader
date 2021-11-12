using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS1L : MonoBehaviour
{
    public GameObject ADS1;
    public GameObject ADS2;
    
    public GameObject Seat1L;
    
    public GameObject Seat2L;
   
    public GameObject Seat3L;
   
    public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat1L.SetActive(false);
       
            Seat2L.SetActive(false);
         
            Seat3L.SetActive(false);
          
            Seat4L.SetActive(false);
        
            ADS1.SetActive(false);
            ADS2.SetActive(false);


        }


    }

}
