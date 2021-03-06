using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteQD : MonoBehaviour
{
    public GameObject script;
    public GameObject DeleteObject;
    public GameObject DeleteObject2;
    public Material ADSMat;
    public Material LOGSMat;
    public GameObject ParentPosition;
    public int Index;
    public GameObject MoveObjectAFT;
    public GameObject MoveObjectFWD;
    public GameObject MoveObjectAftMid;
    public GameObject MainCanvas;

    public void Awake()
    {
        MainCanvas = GameObject.Find("MainCanvas").gameObject;
    }

    public void DeleteThis() // this deletes the selected pallet
    {
        Raycast.SelectedPanelisLive = false;
       
        float weightint = gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.gameObject.GetComponent<ACP_PayloadQD>().PalletWeight;
        float palint = (float)gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.gameObject.GetComponent<ACP_PayloadQD>().OldMoment;
        Payload.TotalPayloadWt -= weightint; // this minuses the weight to the total payload weight from the Payload script.
        Payload.Moment -= palint; // this minuses the moment from the payload.

        if (MoveQD.MovedButtonPressed == true)
        {
            gameObject.transform.parent.gameObject.GetComponent<MoveQD>().CxMoveThis();

            ParentPosition = gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<QDcheckButtons>().SelectedACP.transform.parent.transform.parent.gameObject; // this is the parent position e.g ADS 2
            ParentPosition.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = enabled;
            ParentPosition.tag = "empty";
            ParentPosition.transform.GetChild(0).tag = "empty";

            if (gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<QDcheckButtons>().SelectedACP.name.Contains("ADS"))

            {
                ParentPosition.layer = LayerMask.NameToLayer("ADS");
                ParentPosition.transform.GetChild(0).transform.gameObject.layer = LayerMask.NameToLayer("ADS");

            }

            else if (gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<QDcheckButtons>().SelectedACP.name.Contains("LOGS"))

            {
                ParentPosition.layer = LayerMask.NameToLayer("LOGS");
                ParentPosition.transform.GetChild(0).transform.gameObject.layer = LayerMask.NameToLayer("LOGS");
            }

            Index = ParentPosition.transform.GetSiblingIndex();
            MoveObjectAFT = ParentPosition.transform.parent.transform.GetChild(Index + 2).transform.gameObject;
            MoveObjectAftMid = ParentPosition.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
            MoveObjectAFT.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;
            MoveObjectAftMid.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;
            MoveObjectFWD = ParentPosition.transform.parent.transform.GetChild(Index - 1).transform.gameObject;
            MoveObjectAFT.GetComponent<BoxCollider>().enabled = !enabled;
            MoveObjectAftMid.GetComponent<BoxCollider>().enabled = !enabled;
            MoveObjectFWD.GetComponent<BoxCollider>().enabled = !enabled;
            MoveObjectFWD.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;

            if (gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<QDcheckButtons>().SelectedACP.gameObject.name.Contains("ADS"))

            {
                ParentPosition.transform.GetComponent<Renderer>().enabled = true; // turns the renderer for the pallet position on
                ParentPosition.transform.GetComponent<Renderer>().material = ADSMat; // turns the pallet position back to its original colour
                MoveObjectFWD.GetComponent<Renderer>().material = ADSMat;
                MoveObjectAFT.GetComponent<Renderer>().material = ADSMat;
                MoveObjectAftMid.GetComponent<Renderer>().material = ADSMat;

            }

            else if (gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<QDcheckButtons>().SelectedACP.gameObject.name.Contains("LOGS"))

            {
                ParentPosition.transform.GetComponent<Renderer>().enabled = true; // turns the renderer for the pallet position on
                ParentPosition.transform.GetComponent<Renderer>().material = LOGSMat; // turns the pallet position back to its original colour
                MoveObjectFWD.GetComponent<Renderer>().material = LOGSMat;
                MoveObjectAFT.GetComponent<Renderer>().material = LOGSMat;
                MoveObjectAftMid.GetComponent<Renderer>().material = LOGSMat;

            }
            PalletArray.RemoveACPfromList(gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<QDcheckButtons>().SelectedACP);


            DestroyImmediate(MoveObjectAFT.transform.GetChild(0).transform.GetChild(0).transform.gameObject, true);
            DestroyImmediate(MoveObjectFWD.transform.GetChild(0).transform.GetChild(0).transform.gameObject, true);
            Destroy(gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<QDcheckButtons>().SelectedACP);

        }


        else if (MoveQD.MovedButtonPressed == false)
        {
            Debug.Log("ZUBU.." + gameObject.transform.parent.transform.GetChild(3).gameObject.name);
            ParentPosition = gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.transform.parent.transform.parent.gameObject; // this is the parent position e.g ADS 2
            ParentPosition.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = enabled;
            Index = ParentPosition.transform.GetSiblingIndex();
            ParentPosition.tag = "empty";
            ParentPosition.transform.GetChild(0).tag = "empty";

            if (gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.name.Contains("ADS"))

            {
                ParentPosition.layer = LayerMask.NameToLayer("ADS");
                ParentPosition.transform.GetChild(0).transform.gameObject.layer = LayerMask.NameToLayer("ADS");
            }

            else if (gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.name.Contains("LOGS"))

            {
                ParentPosition.layer = LayerMask.NameToLayer("LOGS");
                ParentPosition.transform.GetChild(0).transform.gameObject.layer = LayerMask.NameToLayer("LOGS");
            }


            MoveObjectAFT = ParentPosition.transform.parent.transform.GetChild(Index + 2).transform.gameObject;
            MoveObjectAftMid = ParentPosition.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
            MoveObjectAFT.GetComponent<BoxCollider>().enabled = !enabled;
            MoveObjectAftMid.GetComponent<BoxCollider>().enabled = !enabled;
            MoveObjectAFT.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;
            MoveObjectAftMid.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;
            MoveObjectFWD = ParentPosition.transform.parent.transform.GetChild(Index - 1).transform.gameObject;
            MoveObjectFWD.GetComponent<BoxCollider>().enabled = !enabled;
            MoveObjectFWD.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;

            if (gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.gameObject.name.Contains("ADS"))

            {
                ParentPosition.transform.GetComponent<Renderer>().enabled = true; // turns the renderer for the pallet position on
                ParentPosition.transform.GetComponent<Renderer>().material = ADSMat; // turns the pallet position back to its original colour
                MoveObjectFWD.GetComponent<Renderer>().material = ADSMat;
                MoveObjectAFT.GetComponent<Renderer>().material = ADSMat;
                MoveObjectAftMid.GetComponent<Renderer>().material = ADSMat;
            }

            else if (gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.gameObject.name.Contains("LOGS"))

            {
                ParentPosition.transform.GetComponent<Renderer>().enabled = true; // turns the renderer for the pallet position on
                ParentPosition.transform.GetComponent<Renderer>().material = LOGSMat; // turns the pallet position back to its original colour
                MoveObjectFWD.GetComponent<Renderer>().material = LOGSMat;
                MoveObjectAFT.GetComponent<Renderer>().material = LOGSMat;
                MoveObjectAftMid.GetComponent<Renderer>().material = LOGSMat;
            }

            PalletArray.RemoveACPfromList(gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP);

            Destroy(MoveObjectAFT.transform.GetChild(0).transform.GetChild(0).transform.gameObject);
            DestroyImmediate(MoveObjectFWD.transform.GetChild(0).transform.GetChild(0).transform.gameObject, true);
            Destroy(gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP);

        }


        gameObject.transform.parent.transform.parent.GetComponent<PalletArray>().ChangeColourNormal();
        Index = ParentPosition.transform.GetSiblingIndex();
        ParentPosition.transform.GetComponent<BoxCollider>().enabled = false; // the box collider needs to go off otherwise it interferes with the contact script 

        ParentPosition.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = true;
        ParentPosition.tag = "empty";
        Raycast.pause = false;
        MainCanvas.GetComponent<RaycastOff>().TurnOnRaycast();
        Debug.Log("THIS OBJECT...", gameObject.transform.parent.transform.gameObject);
        Destroy(gameObject.transform.parent.transform.gameObject); // this is the Selected Panel


    }

}
