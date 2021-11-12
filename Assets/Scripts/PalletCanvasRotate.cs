using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletCanvasRotate : MonoBehaviour
{
    private void Awake()
    {

        transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = transform.parent.parent.GetChild(0).GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text;
        transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = transform.parent.parent.GetChild(0).GetChild(1).transform.GetComponent<TMPro.TextMeshProUGUI>().text;
        transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = transform.parent.parent.GetChild(0).GetChild(2).transform.GetComponent<TMPro.TextMeshProUGUI>().text;

    }


    void Update()
    {
        Camera camera = Camera.main;
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.left); // This makes the PalletPanelGUI always face the active camera
        transform.position = new Vector3(transform.parent.parent.position.x, transform.parent.parent.position.y + 2, transform.parent.parent.position.z);
    }
}
