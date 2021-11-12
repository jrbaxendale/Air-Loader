using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS10 : MonoBehaviour
{
   
    public GameObject Logs8R;
    public GameObject Logs8L;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

           
            Logs8L.SetActive(false);
            Logs8R.SetActive(false);
        }


    }

}
