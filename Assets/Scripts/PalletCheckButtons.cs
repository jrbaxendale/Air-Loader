using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PalletCheckButtons : MonoBehaviour

{



    public Material GreenPallet;
    public Material BluePallet;
    public GameObject SelectedACP;
    public Color Orange;
    public GameObject NOTOCscreen;
    public GameObject BlurScreen;
    public GameObject NOTOCline;
    public GameObject MainCanvas;
    public GameObject Container;





    private void Awake()
    {
        Orange = new Color(251, 98, 0);
        SelectedACP = Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        Debug.Log("The pallet is ..." + Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject);
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Raycast.target.name; // this is the position
        InitialCheck();

    }

    private void Update()
    {
        FinalCheck();

    }



    public void InitialCheck()
    {

        if (SelectedACP.GetComponent<ACPpayload>().weight == false)
        {

            transform.GetChild(2).gameObject.GetComponent<Button>().enabled = enabled;
            transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.red;
            transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        }

        else if (SelectedACP.GetComponent<ACPpayload>().weight == true)
        {

            transform.GetChild(2).gameObject.GetComponent<Button>().enabled = !enabled;
            transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.green;
            transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

        }


        if (SelectedACP.GetComponent<ACPpayload>().location == false)
        {



            transform.GetChild(3).gameObject.GetComponent<Button>().enabled = enabled;
            transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.red;
            transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        }

        if (SelectedACP.GetComponent<ACPpayload>().location == true)
        {



            transform.GetChild(3).gameObject.GetComponent<Button>().enabled = !enabled;
            transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.green;
            transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

        }

        if (SelectedACP.GetComponent<ACPpayload>().Locks == false)
        {

            transform.GetChild(4).gameObject.GetComponent<Button>().enabled = enabled;
            transform.GetChild(4).gameObject.GetComponent<Image>().color = Color.red;
            transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        }

        else if (SelectedACP.GetComponent<ACPpayload>().Locks == true)
        {

            transform.GetChild(4).gameObject.GetComponent<Button>().enabled = !enabled;
            transform.GetChild(4).gameObject.GetComponent<Image>().color = Color.green;
            transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

        }

        if (SelectedACP.GetComponent<ACPpayload>().dg == false)
        {

            transform.GetChild(5).gameObject.GetComponent<Button>().interactable = false;
            SelectedACP.GetComponent<ACPpayload>().dg = true;
            //transform.GetChild(5).gameObject.GetComponent<Image>().color = Color.red;
            // transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        }

        else if (SelectedACP.GetComponent<ACPpayload>().dg)
        {

            transform.GetChild(5).gameObject.GetComponent<Button>().enabled = enabled;
            transform.GetChild(5).gameObject.GetComponent<Image>().color = Orange;
            //transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

        }



        Debug.Log("Initial Check Complete");

    }



    public void WeightCheck()

    {
        if (SelectedACP.GetComponent<ACPpayload>().weight == false)

        {
            SelectedACP.GetComponent<ACPpayload>().weight = true;
            transform.GetChild(2).gameObject.GetComponent<Button>().enabled = !enabled;
            transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.green;
            transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;
        }



    }

    public void PositionCheck()

    {
        SelectedACP.GetComponent<ACPpayload>().location = true;
        transform.GetChild(3).gameObject.GetComponent<Button>().enabled = !enabled;
        transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.green;
        transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

    }

    public void LocksCheck()

    {
        SelectedACP.GetComponent<ACPpayload>().Locks = true;
        transform.GetChild(4).gameObject.GetComponent<Button>().enabled = !enabled;
        transform.GetChild(4).gameObject.GetComponent<Image>().color = Color.green;
        transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

    }

    public void DGCheck()

    {
       
        var v = transform.GetChild(5).transform.gameObject.GetComponent<Clipboard>();
        v.ACPID1 = SelectedACP.GetComponent<ACPpayload>().ACPID;
        v.ActivateDisplay();
        v.CheckforPalletRef();

       // SelectedACP.GetComponent<ACPpayload>().dg = true;
       // transform.GetChild(5).gameObject.GetComponent<Button>().enabled = !enabled;
       //  transform.GetChild(5).gameObject.GetComponent<Image>().color = Color.green;
        //transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

    }

    public void FinalCheck()

    {
        if (SelectedACP.GetComponent<ACPpayload>().weight == true &&
            SelectedACP.GetComponent<ACPpayload>().location == true &&
            SelectedACP.GetComponent<ACPpayload>().Locks == true &&
            SelectedACP.GetComponent<ACPpayload>().dg == true)

        {
            SelectedACP.GetComponent<ACPpayload>().Checked = true;
            SelectedACP.GetComponent<Renderer>().material = GreenPallet;
        }

        else
        {
            SelectedACP.GetComponent<ACPpayload>().Checked = false;
            SelectedACP.GetComponent<Renderer>().material = BluePallet;


        }



    }


   
    

}
