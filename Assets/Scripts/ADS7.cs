using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS7 : MonoBehaviour
{
    public GameObject Logs5R;
    public GameObject Logs5L;
    public GameObject Logs6R;
    public GameObject Logs6L;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

            Logs5R.SetActive(false);
            Logs5L.SetActive(false);
            Logs6L.SetActive(false);
            Logs6R.SetActive(false);
        }


    }

}
