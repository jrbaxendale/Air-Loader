using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS2R : MonoBehaviour
{
    //public GameObject ADS1;
    public GameObject ADS2;
    public GameObject Seat4R;
    public GameObject Seat5R;
    public GameObject Seat6R;
    public GameObject Seat7R;
    public GameObject Seat8R;
    public GameObject Seat9R;
   // public GameObject Seat4R;
   // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat4R.SetActive(false);
            Seat5R.SetActive(false);
            Seat6R.SetActive(false);
            Seat7R.SetActive(false);
            Seat8R.SetActive(false);
           // Seat3R.SetActive(false);
           // Seat4L.SetActive(false);
           // Seat4R.SetActive(false);
           // ADS1.SetActive(false);
            ADS2.SetActive(false);


        }


    }

}
