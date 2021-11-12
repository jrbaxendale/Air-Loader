using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoosePanel : MonoBehaviour


{
    public GameObject LsePanel;
    public GameObject LseObject;
    public GameObject WhichPanel;
    public bool bool2;
    public PalletPanelClose Pallet;
    public TPUPalletControl Tpu;
    public Image circleLSE;


    public void CloseLse()
    {
        LsePanel.SetActive(false);
        circleLSE.GetComponent<Image>().color = Color.white;

        bool2 = false;
    }




    public void Openlse()
    {
        if (bool2 == false)
        {
            Tpu.CloseTpu();
            Pallet.ClosePallet();
            LsePanel.SetActive(true);
            
            WhichPanel.SetActive(false);
            circleLSE.GetComponent<Image>().color = Color.green;
            bool2 = true;

        }


        else

        {
            if (bool2 == true)
            {

                LsePanel.SetActive(false);
                circleLSE.GetComponent<Image>().color = Color.white;


                bool2 = false;
            }



        }





    }
}