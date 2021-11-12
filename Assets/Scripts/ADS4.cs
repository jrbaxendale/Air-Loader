using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS4 : MonoBehaviour
{
    
    public GameObject Logs3L;
    public GameObject Logs3R;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

           
            Logs3R.SetActive(false);
            Logs3L.SetActive(false);
        }


    }

}
