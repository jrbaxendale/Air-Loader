using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS3 : MonoBehaviour
{
    public GameObject Logs2R;
    public GameObject Logs2L;
    public GameObject Logs3R;
    public GameObject Logs3L;


    public void Update()
    {
        if (gameObject.transform.GetChild(0).transform.childCount >= 1)
        {

            Logs2R.SetActive(false);
            Logs2L.SetActive(false);
            Logs3L.SetActive(false);
            Logs3R.SetActive(false);
        }


    }

}
