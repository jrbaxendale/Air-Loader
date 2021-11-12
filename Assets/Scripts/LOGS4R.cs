using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS4R : MonoBehaviour
{
    public GameObject ADS5;
    public GameObject ADS6;
    public GameObject Seat13R;
    public GameObject Seat14R;
    public GameObject Seat15R;
    public GameObject Seat16R;
    public GameObject Seat17R;
    //public GameObject Seat9R;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat13R.SetActive(false);
            Seat14R.SetActive(false);
            Seat15R.SetActive(false);
            Seat16R.SetActive(false);
            Seat17R.SetActive(false);
            // Seat3R.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            ADS5.SetActive(false);
            ADS6.SetActive(false);


        }


    }

}
