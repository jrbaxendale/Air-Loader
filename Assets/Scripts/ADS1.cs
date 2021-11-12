using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS1 : MonoBehaviour
{


    public GameObject Logs1R;
    public GameObject Logs1L;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >=1)
        {

            Logs1R.SetActive(false);
            Logs1L.SetActive(false);
        }


    }

}

