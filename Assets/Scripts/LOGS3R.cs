using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS3R : MonoBehaviour
{
    public GameObject ADS3;
    public GameObject ADS4;
    public GameObject Seat9R;
    public GameObject Seat11R;
    public GameObject Seat12R;
    public GameObject Seat13R;
    public GameObject Seat10R;
    //public GameObject Seat9R;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat9R.SetActive(false);
            Seat10R.SetActive(false);
            Seat11R.SetActive(false);
            Seat12R.SetActive(false);
            Seat13R.SetActive(false);
            // Seat3R.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            ADS3.SetActive(false);
            ADS4.SetActive(false);


        }


    }

}
