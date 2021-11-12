using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS11 : MonoBehaviour
{
    public GameObject Logs8R;
    public GameObject Logs8L;
    public GameObject Logs9R;
    public GameObject Logs9L;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

            Logs8R.SetActive(false);
            Logs8L.SetActive(false);
            Logs9L.SetActive(false);
            Logs9R.SetActive(false);
        }


    }

}