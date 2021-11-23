using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{

    public GameObject script;
    public GameObject DeleteObject;
    public GameObject DeleteObject2;
    public Material ADSMat;
    public Material LOGSMat;
    public GameObject ParentPosition;
    


    public void DeleteThis() // this deletes the selected pallet
    {
        Raycast.SelectedPanelisLive = false;

        float weightint = (float)gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<PalletCheckButtons>().SelectedACP.gameObject.GetComponent<ACPpayload>().palletint;
        float palint = (float)gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<PalletCheckButtons>().SelectedACP.gameObject.GetComponent<ACPpayload>().OldMoment;
        Payload.TotalPayloadWt -= weightint; // this minuses the weight to the total payload weight from the Payload script.
        Payload.Moment -= palint; // this minuses the moment from the payload.

        if (MoveACP.MovedButtonPressed == true)
        {
            gameObject.transform.parent.gameObject.GetComponent<MoveACP>().CxMoveThis();
            
            ParentPosition = gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<PalletCheckButtons>().SelectedACP.transform.parent.transform.parent.gameObject; // this is the parent position e.g ADS 2
            Destroy(gameObject.transform.parent.transform.GetChild(4).gameObject.GetComponent<PalletCheckButtons>().SelectedACP);
        }


        else if (MoveACP.MovedButtonPressed == false)
        {
            Debug.Log("ZUBU.." + gameObject.transform.parent.transform.GetChild(3).gameObject.name);
            ParentPosition = gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<PalletCheckButtons>().SelectedACP.transform.parent.transform.parent.gameObject; // this is the parent position e.g ADS 2
            Destroy(gameObject.transform.parent.transform.GetChild(3).gameObject.GetComponent<PalletCheckButtons>().SelectedACP);
        }

        gameObject.transform.parent.transform.parent.GetComponent<PalletArray>().ChangeColourNormal();
        ParentPosition.transform.GetComponent<Renderer>().enabled = true; // turns the renderer for the pallet position on
        ParentPosition.transform.GetComponent<Renderer>().material = ADSMat; // turns the pallet position back to its original colour
        ParentPosition.transform.GetComponent<BoxCollider>().enabled = false; // the box collider needs to go off otherwise it interferes with the contact script 
        ParentPosition.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = true;
        ParentPosition.tag = "empty";
        Raycast.pause = false;
       
      
        Destroy(gameObject.transform.parent.gameObject); // this is the Selected Panel
        
       
    }

  
}
