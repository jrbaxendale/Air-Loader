using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS9R : MonoBehaviour
{
    public GameObject ADS10;
    public GameObject ADS11;
    // public GameObject Seat26R;
    // public GameObject Seat27R;
    // public GameObject Seat24R;
    // public GameObject Seat25R;
    // public GameObject Seat26R;
    //public GameObject Seat22R;
    //public GameObject Seat9R;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            //Seat26R.SetActive(false);
            //Seat27R.SetActive(false);
            //  Seat24R.SetActive(false);
            //  Seat25R.SetActive(false);
            // Seat26R.SetActive(false);
            // Seat22R.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            ADS10.SetActive(false);
            ADS11.SetActive(false);


        }


    }

}
