using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS4L : MonoBehaviour
{
    public GameObject ADS5;
    public GameObject ADS6;
    public GameObject Seat13L;
    public GameObject Seat14L;
    public GameObject Seat15L;
    public GameObject Seat16L;
    public GameObject Seat17L;
    //public GameObject Seat9R;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat13L.SetActive(false);
            Seat14L.SetActive(false);
            Seat15L.SetActive(false);
            Seat16L.SetActive(false);
            Seat17L.SetActive(false);
            // Seat3R.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            ADS5.SetActive(false);
            ADS6.SetActive(false);


        }


    }

}
