using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseQDselectedPanel : MonoBehaviour
{
    public static bool pause1 = Raycast.pause;
    public GameObject SelectedACP;
    public GameObject Maincanvas;


    public void ExitDelete()
    {
        gameObject.transform.parent.transform.parent.transform.GetComponent<Raycast>().enabled = true;


        if (MoveQD.MovedButtonPressed == true)
        {

            gameObject.transform.parent.gameObject.GetComponent<MoveQD>().CxMoveThis();
            SelectedACP = MoveQD.MoveObject.gameObject;
        }

        else if (MoveQD.MovedButtonPressed == false)
        {
            SelectedACP = MoveQD.MoveObject.gameObject;
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
