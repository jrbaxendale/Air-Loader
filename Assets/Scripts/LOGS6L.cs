using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS6L : MonoBehaviour
{
    public GameObject ADS7;
    public GameObject ADS8;
    public GameObject Seat22L;
    public GameObject Seat23L;
    public GameObject Seat24L;
    public GameObject Seat25L;
    public GameObject Seat26L;
    //public GameObject Seat22R;
    //public GameObject Seat9R;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat22L.SetActive(false);
            Seat23L.SetActive(false);
            Seat24L.SetActive(false);
            Seat25L.SetActive(false);
            Seat26L.SetActive(false);
            Seat22L.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            ADS7.SetActive(false);
            ADS8.SetActive(false);


        }


    }

}
