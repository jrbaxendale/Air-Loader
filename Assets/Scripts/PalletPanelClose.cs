using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PalletPanelClose : MonoBehaviour
{
    public GameObject WhichPallet;
    
    public bool PalletBool;
    public TPUPalletControl TpuScript;
    public LoosePanel Lse;
    public Image circle;



    public void OpenWhichPallet()
    {

        if (PalletBool == false)
        {
            Lse.CloseLse();
            TpuScript.CloseTpu();
            WhichPallet.SetActive(true); 
            circle.GetComponent<Image>().color = Color.green;





            PalletBool = true;
            return;
        }


        else if (PalletBool == true)
        {
            WhichPallet.SetActive(false);
            circle.GetComponent<Image>().color = Color.white;
            Debug.Log("Circle should be white");

            PalletBool = false;



        }

    }

        public void ClosePallet()

          { 
        
            WhichPallet.SetActive(false);
            circle.GetComponent<Image>().color = Color.white;



        PalletBool = false;


        }









    


}
        
        
        
