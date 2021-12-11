using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

public class CreateDbleACP : MonoBehaviour

    
{
    public GameObject DblPrefabLOGS;
    public GameObject DblprefabADS;
    public bool Created;

    public TextMeshProUGUI Weight1;


    [ES3Serializable]
    public TextMeshProUGUI Dest;


    [ES3Serializable]
    public TextMeshProUGUI ACPID;

    public TextMeshProUGUI ACPIDaft;

    public TextMeshProUGUI weight2;

    public GameObject InputFieldFWD;
    public GameObject InputFieldAFT;
    public GameObject ACPdiscard;

    public static decimal weightint;

    public TMP_InputField CombinedWt;
    public GameObject MainCanvas;
    public void DiscardPallet()

    {
        if (ACPdiscard != null)

        {
            Destroy(ACPdiscard);
            gameObject.GetComponent<Button>().interactable = true;
        }

        else return;
    }

    public void MakeDoubleACP()
    {
       MainCanvas = GameObject.Find("MainCanvas");
        if (ActivateADSLOGS.ADSbool == ActivateADSLOGS.LOGSbool)

        {

            return;
        }
        

        if (ActivateADSLOGS.ADSbool)

        {


            GameObject Dblprefab1ADS = Instantiate(DblprefabADS);
            ACPdiscard = Dblprefab1ADS;
            gameObject.GetComponent<Button>().interactable = false;

            Debug.Log("Pallet Created");

            Dblprefab1ADS.transform.localPosition = new Vector3(0, 0.83f, 0);

            PalletArray.AddACPtoList(Dblprefab1ADS); // This is for the colour change of all items during pallet inspection

            TextMeshProUGUI destACP = Dblprefab1ADS.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>(); // this is the instantiated pallets destination display
            destACP.text = Dest.GetComponent<TextMeshProUGUI>().text;

            TextMeshProUGUI destACP1 = Dblprefab1ADS.transform.GetChild(0).GetChild(4).GetComponent<TMPro.TextMeshProUGUI>(); // this is the instantiated pallets destination display
            destACP1.text = Dest.GetComponent<TextMeshProUGUI>().text;

            TextMeshProUGUI weightfwd = Dblprefab1ADS.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>(); // weight2 is the weight display on the instantiated pallet
            weightfwd.text = Weight1.GetComponent<TextMeshProUGUI>().text; // weight1 is the input field for single pallet weight

            TextMeshProUGUI weightaft = Dblprefab1ADS.transform.GetChild(0).GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
            weightaft.text = weight2.GetComponent<TextMeshProUGUI>().text;

            TextMeshProUGUI ACPidFwd = Dblprefab1ADS.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();  // ACPID is the Pallet ID number input field for a single pallet
            ACPidFwd.text = ACPID.text; //this transfers the Pallet ID string from the input field to the instantiated pallets ID field

            TextMeshProUGUI ACPidAft = Dblprefab1ADS.transform.GetChild(0).GetChild(4).GetComponent<TMPro.TextMeshProUGUI>();  // ACPID is the Pallet ID number input field for a single pallet
            ACPidAft.text = ACPIDaft.text; //this transfers the Pallet ID string from the input field to the instantiated pallets ID field

            Dblprefab1ADS.GetComponent<ACP_PayloadDBL>().ACPID1 = MainCanvas.transform.GetChild(2).transform.GetChild(8)
                .transform.gameObject.GetComponent<TMP_InputField>().text;
            

            Dblprefab1ADS.GetComponent<ACP_PayloadDBL>().ACPID2 = MainCanvas.transform.GetChild(2).transform.GetChild(0)
                .transform.gameObject.GetComponent<TMP_InputField>().text;
            Debug.Log("DBLPREFADS = " + Dblprefab1ADS.GetComponent<ACP_PayloadDBL>().ACPID2);

            if (gameObject.transform.parent.GetChild(17).gameObject.GetComponent<DGButtonSgl>().DGbool)
            {

               // Dblprefab1ADS.transform.GetChild(2).transform.gameObject.SetActive(true);
                Dblprefab1ADS.GetComponent<ACP_PayloadDBL>().dg = true;
            }

            var CombinedText = CombinedWt.text;

                if (!string.IsNullOrWhiteSpace(CombinedText))
                {
                    Debug.Log("Total Weight added");


                    TextMeshProUGUI CombinedWT = Dblprefab1ADS.transform.GetChild(0).GetChild(5)
                        .GetComponent<TextMeshProUGUI>(); // This is the pallet total weight
                    CombinedWT.text = CombinedWt.text;

                }
                
                
            

            else 

            {
                Debug.Log("Total Weight not added");
                Dblprefab1ADS.transform.GetChild(0).transform.GetChild(5).transform.gameObject.SetActive(false);
                Dblprefab1ADS.transform.GetChild(0).transform.GetChild(6).transform.gameObject.SetActive(false); // this turns off the "Total Weight" text on the pallet

            }
            
            
        }

         if (ActivateADSLOGS.LOGSbool)

        {
              GameObject DblprefabLOGS1 = Instantiate(DblPrefabLOGS);
              ACPdiscard = DblprefabLOGS1; 
              gameObject.GetComponent<Button>().interactable = false;

              Debug.Log("Pallet Created");

              DblprefabLOGS1.transform.localPosition = new Vector3(-1.3f, 0.48f, -1.4f);

              PalletArray.AddACPtoList(DblprefabLOGS1); // This is for the colour change of all items during pallet inspection

              TextMeshProUGUI destACP = DblprefabLOGS1.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>(); // this is the instantiated pallets destination display
              destACP.text = Dest.GetComponent<TextMeshProUGUI>().text;
            
              TextMeshProUGUI weightfwd = DblprefabLOGS1.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>(); // weight2 is the weight display on the instantiated pallet
              weightfwd.text = Weight1.GetComponent<TextMeshProUGUI>().text; // weight1 is the input field for single pallet weight

              TextMeshProUGUI weightaft = DblprefabLOGS1.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
              weightaft.text = weight2.GetComponent<TextMeshProUGUI>().text;

              TextMeshProUGUI ACPidFwd = DblprefabLOGS1.transform.GetChild(0).GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();  // ACPID is the Pallet ID number input field for a single pallet
              ACPidFwd.text = ACPID.text; //this transfers the Pallet ID string from the input field to the instantiated pallets ID field

              TextMeshProUGUI ACPidAft = DblprefabLOGS1.transform.GetChild(0).GetChild(4).GetComponent<TMPro.TextMeshProUGUI>();  // ACPID is the Pallet ID number input field for a single pallet
              ACPidAft.text = ACPIDaft.text; //this transfers the Pallet ID string from the input field to the instantiated pallets ID field

              DblprefabLOGS1.GetComponent<ACP_PayloadDBL>().ACPID1 = MainCanvas.transform.GetChild(2).transform.GetChild(8)
                  .transform.gameObject.GetComponent<TMP_InputField>().text;

              DblprefabLOGS1.GetComponent<ACP_PayloadDBL>().ACPID2 = MainCanvas.transform.GetChild(2).transform.GetChild(0)
                  .transform.gameObject.GetComponent<TMP_InputField>().text;

              if (gameObject.transform.parent.GetChild(17).gameObject.GetComponent<DGButtonSgl>().DGbool)
            {

                  // Dblprefab1ADS.transform.GetChild(2).transform.gameObject.SetActive(true);
                  DblprefabLOGS1.GetComponent<ACP_PayloadDBL>().dg = true;
              }

        }

         gameObject.transform.parent.GetChild(17).gameObject.GetComponent<DGButtonSgl>().DGbool = false;
    }
          
}

