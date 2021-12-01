using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using EasyGameStudio.Jeremy;


public class makeACP : MonoBehaviour
{

    


    [ES3Serializable]
    public GameObject Weight1;


    [ES3Serializable]
    public GameObject Dest1;


    [ES3Serializable]
    public GameObject ACPID;


    [ES3Serializable]
    public GameObject InputField;


    [ES3Serializable]
    public GameObject Maincanvas;


    [ES3Serializable]
    public static float weightint;

    public static TextMeshProUGUI weight;
    public GameObject MainCanvas;
    public GameObject ACPdisplay;
    public GameObject ACPprefab;
    public GameObject ConfigView;
    public GameObject ParOone;
    public GameObject LoadFreight;
    public GameObject WhichPallet;
    public GameObject ADSobj;
    public GameObject LOGSobj;
    public GameObject ACPdiscard;

    public void DiscardPallet()

    {
        if (ACPdiscard != null)

        {
            Destroy(ACPdiscard);
            gameObject.GetComponent<Button>().interactable = true;
        }

        else return;
    }


    public void makepallet()
    {
        if (ActivateADSLOGS.ADSbool == ActivateADSLOGS.LOGSbool)

        {

            return;
        }

        else
        {



            ConfigView.SetActive(false); // these turn off the UI so they cannot be selected
            ParOone.SetActive(false);
            LoadFreight.SetActive(false);
            WhichPallet.SetActive(false);



            Maincanvas.GetComponent<RaycastOff>().TurnOffRaycast(); // turns off Raycast script
                                                                    // gameObject.GetComponent<Button>().interactable = false; // turns off button used to add another pallet until the current pallet is placed.

            if (ActivateADSLOGS.LOGSbool == false && ActivateADSLOGS.ADSbool == true) // make ADS pallet

            {
                GameObject ACPprefab1 = Instantiate(ACPprefab); // instatiates a single pallet;
                ACPdiscard = ACPprefab1;
                gameObject.GetComponent<Button>().interactable = false;
                ACPprefab1.transform.localPosition = new Vector3(0, 0.83f, 0); // positions the new pallet slightly above other items to prevent interferance
               // ACPprefab1.GetComponent<Dissolve>().show();
                Debug.Log("MADE A ADS PALLET");  
                ACPprefab1.layer = LayerMask.NameToLayer("ADS"); // pallet goes on ADS layer.
                Debug.Log("ADSpalletcreated");
                TMPro.TextMeshProUGUI weight2 = ACPprefab1.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>(); // weight2 is the weight display on the instantiated pallet
                weight = Weight1.GetComponent<TextMeshProUGUI>(); // weight1 is the input field for single pallet weight
                weight2.text = weight.text; // this transfers the weight figure from the input field to the instantiated pallets weight field
                TMPro.TextMeshProUGUI destACP = ACPprefab1.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>(); // this is the instantiated pallets destination display
                TMPro.TextMeshProUGUI destin1 = Dest1.GetComponent<TextMeshProUGUI>(); // Dest1 is the destination string from the input field for a single pallet
                destACP.text = destin1.text;// this transfers the destination string from the input field to the instantiated pallets destination field
                TMPro.TextMeshProUGUI ACPid = ACPprefab1.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>(); // this is the pallets ID number display
                TMPro.TextMeshProUGUI ACPin = ACPID.GetComponent<TextMeshProUGUI>(); // ACPID is the Pallet ID number input field for a single pallet
                ACPid.text = ACPin.text; //this transfers the Pallet ID string from the input field to the instantiated pallets ID field
                ACPprefab1.transform.localEulerAngles = new Vector3(-90, 90, 0); // This sets the orientation of the instantiated pallet
                ACPprefab1.GetComponent<ACPpayload>().ACPID = MainCanvas.transform.GetChild(5).transform.GetChild(5)
                    .transform.gameObject.GetComponent<TMP_InputField>().text;
                PalletArray.AddACPtoList(ACPprefab1); // This is for the colour change of all items during pallet inspection

                if (DGButtonSgl.DGbool)
                {

                    ACPprefab1.transform.GetChild(2).transform.gameObject.SetActive(true);
                    ACPprefab1.GetComponent<ACPpayload>().dg = true;
                }



                if (DangerousGoods.HasDg == true)


                {
                    foreach (Transform DgACP in DangerousGoods.DgItemsList)

                    {
                        DgACP.transform.SetParent(ACPprefab1.transform, false);
                        DgACP.transform.GetComponent<LineDraw>().Line.startWidth = 0.01f;
                        DgACP.transform.GetComponent<LineDraw>().Line.endWidth = 0.01f;

                        Debug.Log("DG items added to instantiated Pallet");

                    }

                }



            }


            if (InputField.GetComponent<TMP_InputField>().text != null) // this checks that there is a number in the single pallet weight input field
            {


                weightint = Int32.Parse(InputField.GetComponent<TMP_InputField>().text.ToString()); // this transfers the weight from the input field into the weightint variable

                Payload.TotalPayloadWt += weightint; // this adds the weight to the total payload weight from the Payload script





            }



            if (ActivateADSLOGS.ADSbool == false && ActivateADSLOGS.LOGSbool == true) // make LOGS pallet
            {
                GameObject ACPprefab1 = Instantiate(ACPprefab) as GameObject; // this instantiates a single pallet
                                                                              //gameObject.GetComponent<Button>().interactable = false;
                ACPdiscard = ACPprefab1;
                                                                              
                Debug.Log("MADE A LOGS PALLET");
                
                ACPprefab1.transform.localPosition = new Vector3(0, 0.83f, 0); // this sets the initial position on the instantiated pallet slightly above everything else to prevent interference

                ACPprefab1.layer = LayerMask.NameToLayer("LOGS"); // adds the pallet to the Logs Layer
                ACPprefab1.gameObject.name = "ACPLogs";
                Debug.Log("LOGSpalletcreated");
                TMPro.TextMeshProUGUI weight2 = ACPprefab1.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>(); // these 3 lines transfer the weight number from the input field to the pallets display
                TMPro.TextMeshProUGUI weight = Weight1.GetComponent<TMPro.TextMeshProUGUI>();
                weight2.text = weight.text;
                TMPro.TextMeshProUGUI destACP = ACPprefab1.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>(); // these 3 lines transfer the destination string from the input field to the pallets destination display
                TMPro.TextMeshProUGUI destin1 = Dest1.GetComponent<TMPro.TextMeshProUGUI>();
                destACP.text = destin1.text;
                TMPro.TextMeshProUGUI ACPid = ACPprefab1.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>(); // this is the pallets ID number display
                TMPro.TextMeshProUGUI ACPin = ACPID.GetComponent<TextMeshProUGUI>(); // ACPID is the Pallet ID number input field for a single pallet
                ACPid.text = ACPin.text; //this transfers the Pallet ID string from the input field to the instantiated pallets ID field
               
                ACPprefab1.transform.localEulerAngles = new Vector3(-90, 0, 0); // this sets the orientation of the instantiated pallet
                ACPprefab1.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 90); // this sets the orientation of the canvas gameobject on the instantiated pallet
                PalletArray.AddACPtoList(ACPprefab1);



              /*  foreach (Transform DgACP in DangerousGoods.DgItemsList)

                {
                    DgACP.transform.SetParent(ACPprefab1.transform, false);
                    DgACP.transform.GetComponent<LineDraw>().Line.startWidth = 0.01f;
                    DgACP.transform.GetComponent<LineDraw>().Line.endWidth = 0.01f;

                    Debug.Log("DG items added to instantiated Pallet");

                }

              */

                if (InputField.GetComponent<TMP_InputField>().text != null)
                {

                    weightint = Int32.Parse(InputField.GetComponent<TMP_InputField>().text.ToString());// this transfers the weight from the input field into the weightint variable
                    Payload.TotalPayloadWt += weightint;  // this adds the weight to the total payload weight from the Payload script

                }




                if (DGButtonSgl.DGbool == true)
                {

                    ACPprefab1.transform.GetChild(2).transform.gameObject.SetActive(true);

                }
            }


            gameObject.GetComponent<Button>().interactable = false;
        }



    }
    

}
