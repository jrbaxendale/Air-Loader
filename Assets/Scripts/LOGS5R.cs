using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS5R : MonoBehaviour
{
    public GameObject ADS6;
    public GameObject ADS7;
    public GameObject Seat17R;
    public GameObject Seat18R;
    public GameObject Seat19R;
    public GameObject Seat20R;
    public GameObject Seat21R;
    public GameObject Seat22R;
    //public GameObject Seat9R;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat17R.SetActive(false);
            Seat18R.SetActive(false);
            Seat19R.SetActive(false);
            Seat20R.SetActive(false);
            Seat21R.SetActive(false);
            Seat22R.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            ADS6.SetActive(false);
            ADS7.SetActive(false);


        }


    }

}
