using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class MakeTPl : MonoBehaviour
{
    public GameObject ADSscript;
    public GameObject LOGSscript;

    
    public   GameObject Weight1st;
    public   GameObject Weight2nd;
    public   GameObject Weight3rd;

   
    public  GameObject  DestIn;
    public  GameObject ACPID1;
    public  GameObject ACPID2;
    public GameObject ACPID3;
    public GameObject InputField1;
    public GameObject InputField2;
    public GameObject InputField3;



    public GameObject TplprefabLogs;
    public GameObject TPlprefabADS;
    public GameObject Maincanvas;
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

    public void MakeTplpallet()
    {
        Maincanvas.GetComponent<RaycastOff>().TurnOffRaycast();
        gameObject.GetComponent<Button>().interactable = false;


        if (ActivateADSLOGS.LOGSbool == true)

        {
           GameObject TPlprefabLOGS = Instantiate(TplprefabLogs) as GameObject;
           ACPdiscard = TPlprefabLOGS;


            TPlprefabLOGS.transform.localPosition = new Vector3(0, 1.02f, -1.02f);
            TPlprefabLOGS.layer = LayerMask.NameToLayer("LOGS");
            PalletArray.AddACPtoList(TPlprefabLOGS);
            Debug.Log("LOGSpalletcreated");

            TPlprefabLOGS.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = DestIn.GetComponent<TMP_InputField>().text;

            TPlprefabLOGS.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = Weight1st.GetComponent<TMP_InputField>().text;

            TPlprefabLOGS.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = Weight2nd.GetComponent<TMP_InputField>().text;

            TPlprefabLOGS.transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>().text = Weight3rd.GetComponent<TMP_InputField>().text;

            TPlprefabLOGS.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = ACPID1.GetComponent<TMP_InputField>().text;

            TPlprefabLOGS.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text = ACPID2.GetComponent<TMP_InputField>().text;

            TPlprefabLOGS.transform.GetChild(0).GetChild(6).GetComponent<TextMeshProUGUI>().text = ACPID3.GetComponent<TMP_InputField>().text;

            int weightint1 = Int32.Parse(InputField1.GetComponent<TMP_InputField>().text.ToString());

            int weightint2 = Int32.Parse(InputField2.GetComponent<TMP_InputField>().text.ToString());

            int weightint3 = Int32.Parse(InputField3.GetComponent<TMP_InputField>().text.ToString());

            TPlprefabLOGS.GetComponent<ACP_PayloadTPL>().ACPID1 = Maincanvas.transform.GetChild(3).transform.GetChild(8)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            TPlprefabLOGS.GetComponent<ACP_PayloadTPL>().ACPID2 = Maincanvas.transform.GetChild(3).transform.GetChild(10)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            TPlprefabLOGS.GetComponent<ACP_PayloadTPL>().ACPID3 = Maincanvas.transform.GetChild(3).transform.GetChild(12)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            if (gameObject.transform.parent.GetChild(20).gameObject.GetComponent<DGButtonSgl>().DGbool)
            {

                // Dblprefab1ADS.transform.GetChild(2).transform.gameObject.SetActive(true);
                TPlprefabLOGS.GetComponent<ACP_PayloadTPL>().dg = true;
            }
        }



        else if (ActivateADSLOGS.ADSbool == true)
        {
            GameObject TplprefabADS1 = Instantiate(TPlprefabADS) as GameObject;
            ACPdiscard = TplprefabADS1;
            PalletArray.AddACPtoList(TplprefabADS1);

            TplprefabADS1.transform.localPosition = new Vector3(0, 1.02f, 0);

            TplprefabADS1.layer = LayerMask.NameToLayer("ADS");
            Debug.Log("ADSTriplepalletcreated");


            TplprefabADS1.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = DestIn.GetComponent<TMP_InputField>().text;

            TplprefabADS1.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = Weight1st.GetComponent<TMP_InputField>().text;

            TplprefabADS1.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = Weight2nd.GetComponent<TMP_InputField>().text;
           
            TplprefabADS1.transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>().text = Weight3rd.GetComponent<TMP_InputField>().text;

            TplprefabADS1.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = ACPID1.GetComponent<TMP_InputField>().text;

            TplprefabADS1.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text = ACPID2.GetComponent<TMP_InputField>().text;

            TplprefabADS1.transform.GetChild(0).GetChild(6).GetComponent<TextMeshProUGUI>().text = ACPID3.GetComponent<TMP_InputField>().text;

            int weightint1 = Int32.Parse(InputField1.GetComponent<TMP_InputField>().text.ToString());

            int weightint2 = Int32.Parse(InputField2.GetComponent<TMP_InputField>().text.ToString());

            int weightint3 = Int32.Parse(InputField3.GetComponent<TMP_InputField>().text.ToString());

            TplprefabADS1.GetComponent<ACP_PayloadTPL>().ACPID1 = Maincanvas.transform.GetChild(3).transform.GetChild(8)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            TplprefabADS1.GetComponent<ACP_PayloadTPL>().ACPID2 = Maincanvas.transform.GetChild(3).transform.GetChild(10)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            
                TplprefabADS1.GetComponent<ACP_PayloadTPL>().ACPID3 = Maincanvas.transform.GetChild(3).transform.GetChild(12)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

                if(gameObject.transform.parent.GetChild(20).gameObject.GetComponent<DGButtonSgl>().DGbool)
                {

                    // Dblprefab1ADS.transform.GetChild(2).transform.gameObject.SetActive(true);
                    TplprefabADS1.GetComponent<ACP_PayloadTPL>().dg = true;
                }





        }

        gameObject.transform.parent.GetChild(20).gameObject.GetComponent<DGButtonSgl>().DGbool = false;
    }


}

