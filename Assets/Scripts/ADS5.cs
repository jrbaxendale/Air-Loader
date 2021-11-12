using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS5 : MonoBehaviour
{
    public GameObject Logs4R;
    public GameObject Logs4L;
    public GameObject Logs3R;
    public GameObject Logs3L;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

            Logs4R.SetActive(false);
            Logs4L.SetActive(false);
            Logs3L.SetActive(false);
            Logs3R.SetActive(false);
        }


    }

}

