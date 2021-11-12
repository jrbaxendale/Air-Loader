using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaxBagsPanel : MonoBehaviour
{
    public GameObject PaxBagPanel;
    
    public GameObject WhichPanel;
    public bool bool2;
    public PalletPanelClose Pallet;
    public TPUPalletControl Tpu;
    public Image circle;


    public void ClosePaxBags()
    {
        PaxBagPanel.SetActive(false);
        circle.GetComponent<Image>().color = Color.white;


        bool2 = false;
    }




    public void OpenPaxBags()
    {
        Debug.Log("PAX Bags Open");
        if (bool2 == false)
        {
            Tpu.CloseTpu();
            Pallet.ClosePallet();
            PaxBagPanel.SetActive(true);
            circle.GetComponent<Image>().color = Color.green;


            WhichPanel.SetActive(false);

            bool2 = true;

        }


        else

        {
            if (bool2 == true)
            {

                PaxBagPanel.SetActive(false);
                circle.GetComponent<Image>().color = Color.white;


                bool2 = false;
            }



        }





    }
}
