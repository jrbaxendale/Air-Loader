using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QDcheckButtons : MonoBehaviour
{

    public GameObject MainCanvas;
    public Material GreenPallet;
    public Material BluePallet;
    public GameObject SelectedACP;
    public int index;
    public GameObject AftPallet;
    public Color Orange;



    private void Awake()
    {
        Orange = new Color(251, 98, 0);
        SelectedACP = Raycast.target.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        Debug.Log("The pallet is ..." + Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject);
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Raycast.target.name; // this is the fwd position
        index = Raycast.target.GetSiblingIndex();
        transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = Raycast.target.transform.parent.GetChild(index + 1).gameObject.name; // this is the aft position
        AftPallet = Raycast.target.transform.parent.GetChild(index + 1).gameObject;
        InitialCheck();

    }

    private void Update()
    {
        FinalCheck();

    }



    public void InitialCheck()
    {

        if (SelectedACP.GetComponent<ACP_PayloadQD>().weight == false)
        {

            transform.GetChild(6).gameObject.GetComponent<Button>().enabled = enabled;
            transform.GetChild(6).gameObject.GetComponent<Image>().color = Color.red;
            transform.GetChild(6).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        }

        else if (SelectedACP.GetComponent<ACP_PayloadQD>().weight == true)
        {

            transform.GetChild(6).gameObject.GetComponent<Button>().enabled = !enabled;
            transform.GetChild(6).gameObject.GetComponent<Image>().color = Color.green;
            transform.GetChild(6).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

        }


        if (SelectedACP.GetComponent<ACP_PayloadQD>().location == false)
        {



            transform.GetChild(7).gameObject.GetComponent<Button>().enabled = enabled;
            transform.GetChild(7).gameObject.GetComponent<Image>().color = Color.red;
            transform.GetChild(7).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        }

        if (SelectedACP.GetComponent<ACP_PayloadQD>().location == true)
        {



            transform.GetChild(7).gameObject.GetComponent<Button>().enabled = !enabled;
            transform.GetChild(7).gameObject.GetComponent<Image>().color = Color.green;
            transform.GetChild(7).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

        }

        if (SelectedACP.GetComponent<ACP_PayloadQD>().Locks == false)
        {

            transform.GetChild(8).gameObject.GetComponent<Button>().enabled = enabled;
            transform.GetChild(8).gameObject.GetComponent<Image>().color = Color.red;
            transform.GetChild(8).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        }

        else if (SelectedACP.GetComponent<ACP_PayloadQD>().Locks == true)
        {

            transform.GetChild(8).gameObject.GetComponent<Button>().enabled = !enabled;
            transform.GetChild(8).gameObject.GetComponent<Image>().color = Color.green;
            transform.GetChild(8).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

        }

        if (SelectedACP.GetComponent<ACP_PayloadQD>().dg == false)
        {

            transform.GetChild(9).gameObject.GetComponent<Button>().interactable = false;
            SelectedACP.GetComponent<ACP_PayloadQD>().dg = true;
            //transform.GetChild(9).gameObject.GetComponent<Image>().color = Color.red;
            // transform.GetChild(9).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        }

        else if (SelectedACP.GetComponent<ACP_PayloadQD>().dg)
        {

            transform.GetChild(9).gameObject.GetComponent<Button>().enabled = enabled;
            transform.GetChild(9).gameObject.GetComponent<Image>().color = Orange;
            transform.GetChild(9).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

        }



        Debug.Log("Initial Check Complete");

    }



    public void WeightCheck()

    {
        if (SelectedACP.GetComponent<ACP_PayloadQD>().weight == false)

        {
            SelectedACP.GetComponent<ACP_PayloadQD>().weight = true;
            transform.GetChild(6).gameObject.GetComponent<Button>().enabled = !enabled;
            transform.GetChild(6).gameObject.GetComponent<Image>().color = Color.green;
            transform.GetChild(6).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;
        }



    }

    public void PositionCheck()

    {
        SelectedACP.GetComponent<ACP_PayloadQD>().location = true;
        transform.GetChild(7).gameObject.GetComponent<Button>().enabled = !enabled;
        transform.GetChild(7).gameObject.GetComponent<Image>().color = Color.green;
        transform.GetChild(7).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

    }

    public void LocksCheck()

    {
        SelectedACP.GetComponent<ACP_PayloadQD>().Locks = true;
        transform.GetChild(8).gameObject.GetComponent<Button>().enabled = !enabled;
        transform.GetChild(8).gameObject.GetComponent<Image>().color = Color.green;
        transform.GetChild(8).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

    }

    public void DGCheck()

    {
        var v = transform.GetChild(5).transform.gameObject.GetComponent<Clipboard>();
        v.ACPID1 = SelectedACP.GetComponent<ACP_PayloadQD>().ACPID1;
        v.ActivateDisplay();
        v.CheckforPalletRef();
        
        //SelectedACP.GetComponent<ACP_PayloadQD>().dg = true;
        // transform.GetChild(9).gameObject.GetComponent<Button>().enabled = !enabled;
        // transform.GetChild(9).gameObject.GetComponent<Image>().color = Color.green;
        // transform.GetChild(9).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;

    }

    public void FinalCheck()

    {
        if (SelectedACP.GetComponent<ACP_PayloadQD>().weight == true &&
            SelectedACP.GetComponent<ACP_PayloadQD>().location == true &&
            SelectedACP.GetComponent<ACP_PayloadQD>().Locks == true &&
            SelectedACP.GetComponent<ACP_PayloadQD>().dg == true)

        {
            SelectedACP.GetComponent<ACP_PayloadQD>().Checked = true;
            SelectedACP.GetComponent<Renderer>().material = GreenPallet;
            Material[] mat = SelectedACP.gameObject.GetComponent<Renderer>().materials;
            mat[0] = GreenPallet;
            mat[1] = GreenPallet;
            SelectedACP.gameObject.GetComponent<Renderer>().materials = mat;





        }

        else
        {
            SelectedACP.GetComponent<ACP_PayloadQD>().Checked = false;
            SelectedACP.GetComponent<Renderer>().material = BluePallet;
            Material[] mat = SelectedACP.gameObject.GetComponent<Renderer>().materials;
            mat[0] = BluePallet;
            mat[1] = BluePallet;
            SelectedACP.gameObject.GetComponent<Renderer>().materials = mat;



        }



    }

}


