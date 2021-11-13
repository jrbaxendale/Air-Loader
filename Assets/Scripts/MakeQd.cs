using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class MakeQd : MonoBehaviour
{
    public GameObject ADSscript;
    public GameObject LOGSscript;


    public GameObject Weight1st;
    public GameObject Weight2nd;
    public GameObject Weight3rd;


    public GameObject DestIn;
    public GameObject ACPID1;
    public GameObject ACPID2;
    public GameObject ACPID3;
    public GameObject InputField1;
    public GameObject InputField2;
    public GameObject InputField3;



    public GameObject QdprefabLogs;
    public GameObject QdprefabADS;
    public GameObject Maincanvas;


    public void MakeQdpallet()
    {
        Maincanvas.GetComponent<RaycastOff>().TurnOffRaycast();
        gameObject.GetComponent<Button>().interactable = false;


        if (ActivateADSLOGS.LOGSbool == true)

        {
            GameObject QdprefabLOGS = Instantiate(QdprefabLogs) as GameObject;


            QdprefabLOGS.transform.localPosition = new Vector3(0, 1.02f, -1.02f);
            QdprefabLOGS.layer = LayerMask.NameToLayer("LOGS");
            PalletArray.AddACPtoList(QdprefabLOGS);
            Debug.Log("QdLOGSpalletcreated");

            QdprefabLOGS.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = DestIn.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = Weight1st.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = Weight2nd.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>().text = Weight3rd.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = ACPID1.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text = ACPID2.GetComponent<TMP_InputField>().text;

            QdprefabLOGS.transform.GetChild(0).GetChild(6).GetComponent<TextMeshProUGUI>().text = ACPID3.GetComponent<TMP_InputField>().text;

            int weightint1 = Int32.Parse(InputField1.GetComponent<TMP_InputField>().text.ToString());

            int weightint2 = Int32.Parse(InputField2.GetComponent<TMP_InputField>().text.ToString());

            int weightint3 = Int32.Parse(InputField3.GetComponent<TMP_InputField>().text.ToString());

            Payload.TotalPayloadWt += weightint1 + weightint2 + weightint3;
            

        }



        else if (ActivateADSLOGS.ADSbool == true)
        {
            GameObject QdprefabADS1 = Instantiate(QdprefabADS) as GameObject;
            PalletArray.AddACPtoList(QdprefabADS1);

            QdprefabADS1.transform.localPosition = new Vector3(0, 1.02f, 0);

            QdprefabADS1.layer = LayerMask.NameToLayer("ADS");
            Debug.Log("ADSQdpalletcreated");


            QdprefabADS1.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = DestIn.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = Weight1st.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = Weight2nd.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>().text = Weight3rd.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = ACPID1.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text = ACPID2.GetComponent<TMP_InputField>().text;

            QdprefabADS1.transform.GetChild(0).GetChild(6).GetComponent<TextMeshProUGUI>().text = ACPID3.GetComponent<TMP_InputField>().text;

            int weightint1 = Int32.Parse(InputField1.GetComponent<TMP_InputField>().text.ToString());

            int weightint2 = Int32.Parse(InputField2.GetComponent<TMP_InputField>().text.ToString());

            int weightint3 = Int32.Parse(InputField3.GetComponent<TMP_InputField>().text.ToString());

            Payload.TotalPayloadWt += weightint1 + weightint2 + weightint3;







        }


    }


}

