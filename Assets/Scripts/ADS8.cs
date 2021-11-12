using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS8 : MonoBehaviour
{
    public GameObject Logs6R;
    public GameObject Logs6L;
    public GameObject Logs7R;
    public GameObject Logs7L;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

            Logs6R.SetActive(false);
            Logs6L.SetActive(false);
            Logs7L.SetActive(false);
            Logs7R.SetActive(false);
        }


    }

}
