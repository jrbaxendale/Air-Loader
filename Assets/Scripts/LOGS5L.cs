using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS5L : MonoBehaviour
{
    public GameObject ADS6;
    public GameObject ADS7;
    public GameObject Seat17L;
    public GameObject Seat18L;
    public GameObject Seat19L;
    public GameObject Seat20L;
    public GameObject Seat21L;
    public GameObject Seat22L;
    //public GameObject Seat9R;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat17L.SetActive(false);
            Seat18L.SetActive(false);
            Seat19L.SetActive(false);
            Seat20L.SetActive(false);
            Seat21L.SetActive(false);
            Seat22L.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            ADS6.SetActive(false);
            ADS7.SetActive(false);


        }


    }

}
