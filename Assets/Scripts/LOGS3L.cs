using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS3L : MonoBehaviour
{
    //public GameObject ADS1;
    public GameObject ADS2;
    public GameObject Seat4L;
    public GameObject Seat5L;
    public GameObject Seat6L;
    public GameObject Seat7L;
    public GameObject Seat8L;
    // public GameObject Seat9L;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat4L.SetActive(false);
            Seat5L.SetActive(false);
            Seat6L.SetActive(false);
            Seat7L.SetActive(false);
            Seat8L.SetActive(false);
            // Seat3R.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            // ADS1.SetActive(false);
            ADS2.SetActive(false);


        }


    }

}
