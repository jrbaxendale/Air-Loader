using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TPUPalletControl : MonoBehaviour
{
    public GameObject TPUPanel;
    public GameObject WhichPallet;
    public bool bool1;
    public PalletPanelClose Pallet;
    public LoosePanel Lse;
    public Image circleTPU;
    
    public void CloseTpu()
    {

        TPUPanel.SetActive(false);
        bool1 = false;
        circleTPU.GetComponent<Image>().color = Color.white;

    }




    public void OpenTPU()
    {
        if (bool1 == false)
        {
            Lse.CloseLse();
            Pallet.ClosePallet();
            WhichPallet.SetActive(false);
            TPUPanel.SetActive(true);
            circleTPU.GetComponent<Image>().color = Color.green;

            bool1 = true;

        }


        else

        {
            if (bool1 == true)
            {

                TPUPanel.SetActive(false);
                bool1 = false;
                circleTPU.GetComponent<Image>().color = Color.white;

            }



        }


       


    }
}