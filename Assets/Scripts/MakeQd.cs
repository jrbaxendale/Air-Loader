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
    public GameObject Weight2nd;
    public GameObject Weight1st;
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
    public GameObject MainCanvas;


    public void MakeQdpallet()
    {
        
        MainCanvas.GetComponent<RaycastOff>().TurnOffRaycast();
        gameObject.GetComponent<Button>().interactable = false;



        if (ActivateADSLOGS.LOGSbool == true)

        {
            GameObject QDprefabLOGS = Instantiate(QdprefabLogs) as GameObject;


            QDprefabLOGS.transform.localPosition = new Vector3(0, 0.28f, 0);
            QDprefabLOGS.layer = LayerMask.NameToLayer("LOGS");
            Debug.Log("LOGSpalletcreated");
            TMPro.TextMeshProUGUI weight2 = QDprefabLOGS.transform.GetChild(0).GetChild(7).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight = Weight1st.GetComponent<TMPro.TextMeshProUGUI>();
            weight2.text = weight.text;
            TMPro.TextMeshProUGUI weight3 = QDprefabLOGS.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight4 = Weight2nd.GetComponent<TMPro.TextMeshProUGUI>();
            weight3.text = weight4.text;
            TMPro.TextMeshProUGUI weight5 = QDprefabLOGS.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight6 = Weight3rd.GetComponent<TMPro.TextMeshProUGUI>();
            weight5.text = weight6.text;
            TMPro.TextMeshProUGUI weight7 = QDprefabLOGS.transform.GetChild(0).GetChild(5).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight8 = Weight4th.GetComponent<TMPro.TextMeshProUGUI>();
            weight7.text = weight8.text;

            TMPro.TextMeshProUGUI destACP = QDprefabLOGS.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI destin1 = DestIn.GetComponent<TMPro.TextMeshProUGUI>();
            destACP.text = destin1.text;
            TMPro.TextMeshProUGUI dest2ACP = QDprefabLOGS.transform.GetChild(0).GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
            dest2ACP.text = destin1.text;
            TMPro.TextMeshProUGUI dest3ACP = QDprefabLOGS.transform.GetChild(0).GetChild(4).GetComponent<TMPro.TextMeshProUGUI>();
            dest3ACP.text = destin1.text;
            TMPro.TextMeshProUGUI dest4ACP = QDprefabLOGS.transform.GetChild(0).GetChild(6).GetComponent<TMPro.TextMeshProUGUI>();
            dest4ACP.text = destin1.text;

            TMPro.TextMeshProUGUI ACPid1 = QDprefabLOGS.transform.GetChild(0).GetChild(6).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin1 = ACPID1.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid1.text = ACPin1.text;
            TMPro.TextMeshProUGUI ACPid2 = QDprefabLOGS.transform.GetChild(0).GetChild(7).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin2 = ACPID2.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid2.text = ACPin2.text;
            TMPro.TextMeshProUGUI ACPid3 = QDprefabLOGS.transform.GetChild(0).GetChild(8).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin3 = ACPID2.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid3.text = ACPin3.text;
            TMPro.TextMeshProUGUI ACPid4 = QDprefabLOGS.transform.GetChild(0).GetChild(8).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin4 = ACPID2.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid4.text = ACPin4.text;
            QDprefabLOGS.transform.localEulerAngles = new Vector3(-90, 0, 0);

            int weightint1 = Int32.Parse(InputField1.GetComponent<TMP_InputField>().text.ToString());
            int weightint2 = Int32.Parse(InputField2.GetComponent<TMP_InputField>().text.ToString());
            int weightint3 = Int32.Parse(InputField3.GetComponent<TMP_InputField>().text.ToString());
            int weightint4 = Int32.Parse(InputField3.GetComponent<TMP_InputField>().text.ToString());
            Payload.TotalPayloadWt += weightint1 + weightint2 + weightint3 + weightint4;

        }



        if (ActivateADSLOGS.ADSbool == true)
        {
            GameObject QDprefabADS = Instantiate(QdprefabADS) as GameObject;


            QDprefabADS.transform.localPosition = new Vector3(0, 0.28f, 0);

            QDprefabADS.layer = LayerMask.NameToLayer("ADS");
            Debug.Log("ADSpalletcreated");
            TMPro.TextMeshProUGUI weight2 = QDprefabADS.transform.GetChild(0).GetChild(7).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight = Weight1st.GetComponent<TMPro.TextMeshProUGUI>();
            weight2.text = weight.text;
            TMPro.TextMeshProUGUI weight3 = QDprefabADS.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight4 = Weight2nd.GetComponent<TMPro.TextMeshProUGUI>();
            weight3.text = weight4.text;
            TMPro.TextMeshProUGUI weight5 = QDprefabADS.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight6 = Weight3rd.GetComponent<TMPro.TextMeshProUGUI>();
            weight5.text = weight6.text;
            TMPro.TextMeshProUGUI weight7 = QDprefabADS.transform.GetChild(0).GetChild(5).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight8 = Weight4th.GetComponent<TMPro.TextMeshProUGUI>();
            weight7.text = weight8.text;

            TMPro.TextMeshProUGUI destACP = QDprefabADS.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI destin1 = DestIn.GetComponent<TMPro.TextMeshProUGUI>();
            destACP.text = destin1.text;
            TMPro.TextMeshProUGUI dest2ACP = QDprefabADS.transform.GetChild(0).GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
            dest2ACP.text = destin1.text;
            TMPro.TextMeshProUGUI dest3ACP = QDprefabADS.transform.GetChild(0).GetChild(4).GetComponent<TMPro.TextMeshProUGUI>();
            dest3ACP.text = destin1.text;
            TMPro.TextMeshProUGUI dest4ACP = QDprefabADS.transform.GetChild(0).GetChild(6).GetComponent<TMPro.TextMeshProUGUI>();
            dest4ACP.text = destin1.text;

            TMPro.TextMeshProUGUI ACPid1 = QDprefabADS.transform.GetChild(0).GetChild(8).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin1 = ACPID1.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid1.text = ACPin1.text;
            TMPro.TextMeshProUGUI ACPid2 = QDprefabADS.transform.GetChild(0).GetChild(9).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin2 = ACPID2.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid2.text = ACPin2.text;
            TMPro.TextMeshProUGUI ACPid3 = QDprefabADS.transform.GetChild(0).GetChild(10).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin3 = ACPID3.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid3.text = ACPin3.text;
            TMPro.TextMeshProUGUI ACPid4 = QDprefabADS.transform.GetChild(0).GetChild(11).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin4 = ACPID4.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid4.text = ACPin4.text;
            QDprefabADS.transform.localEulerAngles = new Vector3(-90, 0, 90);

            int weightint1 = Int32.Parse(InputField1.GetComponent<TMP_InputField>().text.ToString());
            int weightint2 = Int32.Parse(InputField2.GetComponent<TMP_InputField>().text.ToString());
            int weightint3 = Int32.Parse(InputField3.GetComponent<TMP_InputField>().text.ToString());
            int weightint4 = Int32.Parse(InputField3.GetComponent<TMP_InputField>().text.ToString());

            Payload.TotalPayloadWt += weightint1 + weightint2 + weightint3 + weightint4;



        }




    }


}

