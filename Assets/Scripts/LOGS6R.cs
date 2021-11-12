using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGS6R : MonoBehaviour
{
    public GameObject ADS7;
    public GameObject ADS8;
    public GameObject Seat22R;
    public GameObject Seat23R;
    public GameObject Seat24R;
    public GameObject Seat25R;
    public GameObject Seat26R;
    //public GameObject Seat22R;
    //public GameObject Seat9R;
    // public GameObject Seat4R;
    // public GameObject Seat4L;





    public void Update()
    {
        if (gameObject.tag == "loaded")
        {

            Seat22R.SetActive(false);
            Seat23R.SetActive(false);
            Seat24R.SetActive(false);
            Seat25R.SetActive(false);
            Seat26R.SetActive(false);
            Seat22R.SetActive(false);
            // Seat4L.SetActive(false);
            // Seat4R.SetActive(false);
            ADS7.SetActive(false);
            ADS8.SetActive(false);


        }


    }

}
