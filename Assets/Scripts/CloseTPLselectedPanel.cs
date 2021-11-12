using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTPLselectedPanel : MonoBehaviour
{
    public static bool pause1 = Raycast.pause;
    public GameObject SelectedACP;
    public GameObject Maincanvas;


    public void ExitDelete()
    {
        gameObject.transform.parent.transform.parent.transform.GetComponent<Raycast>().enabled = true;


        if (MoveTPL.MovedButtonPressed == true)
        {

            gameObject.transform.parent.gameObject.GetComponent<MoveTPL>().CxMoveThis();
            SelectedACP = MoveTPL.MoveObject.gameObject;
        }

        else if (MoveTPL.MovedButtonPressed == false)
        {
            SelectedACP = MoveTPL.MoveObject.gameObject;
            // SelectedACP = Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        }


        PalletArray.AddACPtoList(SelectedACP);
        gameObject.transform.parent.transform.parent.GetComponent<PalletArray>().ChangeColourNormal();
        SelectedACP.gameObject.tag = "loaded";
        Raycast.pause = false;
        Debug.Log("The selected panel to be destroyed is ..." + gameObject.transform.parent.gameObject);
        Raycast.SelectedPanelisLive = false;



        Destroy(gameObject.transform.parent.gameObject);

    }













}


