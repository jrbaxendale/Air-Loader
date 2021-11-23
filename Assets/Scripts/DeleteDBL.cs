using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDBL : MonoBehaviour
{
    public GameObject script;
    public GameObject DeleteObject;
    public GameObject DeleteObject2;
    public Material ADSMat;
    public Material LOGSMat;
    public GameObject ParentPosition;
    public int Index;
    public GameObject MoveObjectAFT;
    public GameObject MainCanvas;

     public void Awake()
    {
        MainCanvas = GameObject.Find("MainCanvas").gameObject;
    }

    public void DeleteThis() // this deletes the selected pallet
    {
        Raycast.SelectedPanelisLive = false;
       // GameObject i = gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<DBLcheckButtons>().SelectedACP;
      //  int Index45 = i.transform.parent.transform.parent.transform.GetSiblingIndex();
      //  GameObject s = gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<DBLcheckButtons>().SelectedACP.transform.parent.transform.parent.transform.GetChild(Index45 + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
       // Debug.Log("XDE", i);
       // Debug.Log("XDw", s);
       // PalletArray.RemoveACPfromList(s);
       // PalletArray.RemoveACPfromList(i);




        float weightint = gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<DBLcheckButtons>().SelectedACP.gameObject.GetComponent<ACP_PayloadDBL>().CombinedWt;
        float palint = gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<DBLcheckButtons>().SelectedACP.gameObject.GetComponent<ACP_PayloadDBL>().OldMoment;
        Payload.TotalPayloadWt -= weightint; // this minuses the weight to the total payload weight from the Payload script.
        Payload.Moment -= palint; // this minuses the moment from the payload.

        switch (MoveDBL.MovedButtonPressed)
        {
            case true:
                gameObject.transform.parent.gameObject.GetComponent<MoveDBL>().CxMoveThis();

                ParentPosition = gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<DBLcheckButtons>().SelectedACP.transform.parent.transform.parent.gameObject; // this is the parent position e.g ADS 2
                Index = ParentPosition.transform.GetSiblingIndex();
                MoveObjectAFT = ParentPosition.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
                MoveObjectAFT.GetComponent<Renderer>().material = ADSMat;
                MoveObjectAFT.GetComponent<BoxCollider>().enabled = !enabled;
                Debug.Log("SERT" + MoveObjectAFT.name);
                MoveObjectAFT.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;
                Debug.Log("AFTOBJ =" + MoveObjectAFT.name);
                // GameObject j = MoveObjectAFT;
                // PalletArray.RemoveACPfromList(j);

                DestroyImmediate(MoveObjectAFT.transform.GetChild(0).transform.GetChild(0).transform.gameObject, true);
                Destroy(gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<DBLcheckButtons>().SelectedACP);

                break;
            case false:
                ParentPosition = gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<DBLcheckButtons>().SelectedACP.transform.parent.transform.parent.gameObject; // this is the parent position e.g ADS 2
                Debug.Log("PARENT POSITION IS ....", ParentPosition);
                Index = ParentPosition.transform.GetSiblingIndex();
                MoveObjectAFT = ParentPosition.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
                ParentPosition.GetComponent<Renderer>().enabled = true; // turns the renderer for the pallet position on

                if (ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject.name.Contains("ADS"))

                {
                    MoveObjectAFT.GetComponent<Renderer>().material = ADSMat;
                    ParentPosition.GetComponent<Renderer>().material = ADSMat; // turns the pallet position back to its original colour

                }

                else if (ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject.name.Contains("LOGS"))

                {
                    MoveObjectAFT.GetComponent<Renderer>().material = LOGSMat;
                    ParentPosition.GetComponent<Renderer>().material = LOGSMat; // turns the pallet position back to its original colour


                }

                MoveObjectAFT.GetComponent<BoxCollider>().enabled = !enabled;
                MoveObjectAFT.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;

                //GameObject k = MoveObjectAFT;
                // PalletArray.RemoveACPfromList(k);

                Destroy(MoveObjectAFT.transform.GetChild(0).transform.GetChild(0).transform.gameObject);
                Destroy(gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<DBLcheckButtons>().SelectedACP);
                break;
        }

        gameObject.transform.parent.transform.parent.GetComponent<PalletArray>().ChangeColourNormal();
       
        Index = ParentPosition.transform.GetSiblingIndex();
       // MoveObjectAFT = ParentPosition.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
        
       
        ParentPosition.transform.GetComponent<BoxCollider>().enabled = false; // the box collider needs to go off otherwise it interferes with the contact script 
       
        ParentPosition.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = true;
        ParentPosition.tag = "empty";
        Raycast.pause = false;
        MainCanvas.GetComponent<RaycastOff>().TurnOnRaycast();
        


        Destroy(gameObject.transform.parent.gameObject); // this is the Selected Panel


    }


}
