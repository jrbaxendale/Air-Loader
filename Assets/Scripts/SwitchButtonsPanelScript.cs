using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SwitchButtonsPanelScript : MonoBehaviour
{

    [SerializeField]
    public Button Weight;
    public Button Locks;
    public Button Net;
    public Button Dg;
    public Button PlacePalletBtn;
    public GameObject deletepallet;



    public void SetButtonInteractableWeight()
    {
        


        {
            Weight.interactable = false;
            Debug.Log("weightbtnchecked");

        }

        
    }



    public void SetButtonInteractableLocks()
    {
        


        {
            Locks.interactable = false;

        }
    }

    public void SetButtonInteractableNet()
    {
        


        {
            Net.interactable = false;

        }
    }


    public void PlacePallet()

    {

        Debug.Log("PalletLoadedbtnchecked");
        
           

       {

            PlacePalletBtn.interactable = false;
            
            Debug.Log("PalletLoadedbtnchecked2");

        }

    }

    public void SetButtonInteractableDg()
    {
       


        {
            Dg.interactable = false;

        }
    }







}







