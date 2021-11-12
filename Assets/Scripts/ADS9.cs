using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS9 : MonoBehaviour
{
    
    public GameObject Logs7L;
    public GameObject Logs7R;

    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

           
            Logs7R.SetActive(false);
            Logs7L.SetActive(false);

        }


    }

}
