using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class MakeQd : MonoBehaviour
{
    
    public GameObject Weight1st;
    public GameObject Weight2nd;
    public GameObject Weight3rd;
    public GameObject Weight4th;


    public GameObject DestIn;
    public GameObject ACPID1;
    public GameObject ACPID2;
    public GameObject ACPID3;
    public GameObject ACPID4;


    public GameObject InputField1;
    public GameObject InputField2;
    public GameObject InputField3;
    public GameObject InputField4;
    
    public GameObject QdprefabLogs;
    public GameObject QdprefabADS;
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
    public void MakeQdpallet()
    {
        Maincanvas.GetComponent<RaycastOff>().TurnOffRaycast();
        gameObject.GetComponent<Button>().interactable = false;


        if (ActivateADSLOGS.LOGSbool == true)

        {
            GameObject QdprefabLOGS = Instantiate(QdprefabLogs) as GameObject;
            ACPdiscard = QdprefabLOGS;

            QdprefabLOGS.transform.localPosition = new Vector3(0, 1.02f, -1.02f);
            QdprefabLOGS.transform.eulerAngles = new Vector3(-90, 0, 360);
                

            QdprefabLOGS.layer = LayerMask.NameToLayer("LOGS");
            PalletArray.AddACPtoList(QdprefabLOGS);
            Debug.Log("QdLOGSpalletcreated");

            QdprefabLOGS.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = DestIn.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = Weight1st.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = Weight2nd.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>().text = Weight3rd.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(7).GetComponent<TextMeshProUGUI>().text = Weight4th.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = ACPID1.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text = ACPID2.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(6).GetComponent<TextMeshProUGUI>().text = ACPID3.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(8).GetComponent<TextMeshProUGUI>().text = ACPID4.GetComponent<TMP_InputField>().text;

            int weightint1 = int.Parse(InputField1.GetComponent<TMP_InputField>().text);

            int weightint2 = int.Parse(InputField2.GetComponent<TMP_InputField>().text);

            int weightint3 = int.Parse(InputField3.GetComponent<TMP_InputField>().text);

            int weightint4 = int.Parse(InputField4.GetComponent<TMP_InputField>().text);

            QdprefabLOGS.GetComponent<ACP_PayloadQD>().ACPID1 = Maincanvas.transform.GetChild(4).transform.GetChild(10)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.GetComponent<ACP_PayloadQD>().ACPID2 = Maincanvas.transform.GetChild(4).transform.GetChild(12)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.GetComponent<ACP_PayloadQD>().ACPID3 = Maincanvas.transform.GetChild(4).transform.GetChild(13)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.GetComponent<ACP_PayloadQD>().ACPID4 = Maincanvas.transform.GetChild(4).transform.GetChild(15)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            if(gameObject.transform.parent.GetChild(24).gameObject.GetComponent<DGButtonSgl>().DGbool)
            {

                // Dblprefab1ADS.transform.GetChild(2).transform.gameObject.SetActive(true);
                QdprefabLOGS.GetComponent<ACP_PayloadQD>().dg = true;
            }


        }



        else if (ActivateADSLOGS.ADSbool == true)
        {
            GameObject QdprefabADS1 = Instantiate(QdprefabADS) as GameObject;
            ACPdiscard = QdprefabADS1;
            PalletArray.AddACPtoList(QdprefabADS1);

            QdprefabADS1.transform.localPosition = new Vector3(0, 1.02f, 0);

            QdprefabADS1.layer = LayerMask.NameToLayer("ADS");
            Debug.Log("ADSQdpalletcreated");


            QdprefabADS1.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = DestIn.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = Weight1st.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = Weight2nd.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>().text = Weight3rd.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(7).GetComponent<TextMeshProUGUI>().text = Weight4th.GetComponent<TMP_InputField>().text;


            QdprefabADS1.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = ACPID1.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text = ACPID2.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(6).GetComponent<TextMeshProUGUI>().text = ACPID3.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(8).GetComponent<TextMeshProUGUI>().text = ACPID4.GetComponent<TMP_InputField>().text;


            int weightint1 = int.Parse(InputField1.GetComponent<TMP_InputField>().text);

            int weightint2 = int.Parse(InputField2.GetComponent<TMP_InputField>().text);

            int weightint3 = int.Parse(InputField3.GetComponent<TMP_InputField>().text);

            int weightint4 = int.Parse(InputField4.GetComponent<TMP_InputField>().text);

            QdprefabADS1.GetComponent<ACP_PayloadQD>().ACPID1 = Maincanvas.transform.GetChild(4).transform.GetChild(10)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            QdprefabADS1.GetComponent<ACP_PayloadQD>().ACPID2 = Maincanvas.transform.GetChild(4).transform.GetChild(12)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            QdprefabADS1.GetComponent<ACP_PayloadQD>().ACPID3 = Maincanvas.transform.GetChild(4).transform.GetChild(13)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            QdprefabADS1.GetComponent<ACP_PayloadQD>().ACPID4 = Maincanvas.transform.GetChild(4).transform.GetChild(15)
                .transform.gameObject.GetComponent<TMP_InputField>().text;

            if (gameObject.transform.parent.GetChild(24).gameObject.GetComponent<DGButtonSgl>().DGbool)
            {

                // Dblprefab1ADS.transform.GetChild(2).transform.gameObject.SetActive(true);
                QdprefabADS1.GetComponent<ACP_PayloadQD>().dg = true;
            }

        }


    }


}

