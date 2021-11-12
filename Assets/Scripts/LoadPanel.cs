using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadPanel : MonoBehaviour
{
    public static TextMeshProUGUI ACPtitle;
    public GameObject TargetPallet;
    public GameObject title;
    public GameObject LocksBtn;
    public GameObject WeightBtn;
    public GameObject LocationBtn;
    public GameObject DgBtn;
    public Material glowgreen;
    public Material dimgreen;



    public bool locks;
    public bool weight;
    public bool location;
    public bool dg;

    public void GetPalletStatus()
    {
        locks = Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().Locks;
        weight = Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().weight;
        location = Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().location;
        dg = Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().dg;
        //Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().gameObject.transform.parent.parent.name;


    }



    public void LocksButton()

    {
        locks = true;
        Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().Locks = true;
        LocksBtn.transform.GetComponent<Button>().interactable = false;
        Debug.Log("lock button pressed");
        LoadComplete();

    }

    public void WeightButton()

    {
        weight = true;
        Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().weight = true;
        WeightBtn.transform.GetComponent<Button>().interactable = false;
        Debug.Log("weight button pressed");
        LoadComplete();

    }

    public void LocationButton()

    {
        location = true;
        Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().location = true;
        LocationBtn.transform.GetComponent<Button>().interactable = false;
        Debug.Log("location button pressed");
        LoadComplete();

    }

    public void DgButton()

    {
        dg = true;
        Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().dg = true;
        DgBtn.transform.GetComponent<Button>().interactable = false;
        Debug.Log("location button pressed");
        LoadComplete();

    }

    public void LoadComplete()
    {
        if ((Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().Locks == true) &&
            (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().weight == true) &&
            (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().location == true) &&
            (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().dg == true)) 

        {
            Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Renderer>().material = dimgreen;
            Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material = glowgreen;
            Destroy(Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Animator>());
            

            Debug.Log("Pallet load complete");
            

        }





    }


}


