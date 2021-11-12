using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS6 : MonoBehaviour
{
    public GameObject Logs4R;
    public GameObject Logs4L;
    public GameObject Logs5R;
    public GameObject Logs5L;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

            Logs4R.SetActive(false);
            Logs4L.SetActive(false);
            Logs5L.SetActive(false);
            Logs5R.SetActive(false);
        }


    }

}