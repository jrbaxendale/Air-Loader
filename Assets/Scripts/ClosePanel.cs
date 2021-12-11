using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{


    public void CloseCurrentPanel()
    {

        gameObject.GetComponent<Canvas>().enabled = !enabled;
        GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = enabled;
        GameObject.Find("BlurGlass2").SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
