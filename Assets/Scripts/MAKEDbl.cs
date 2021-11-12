using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class MAKEDbl : MonoBehaviour
{
    public GameObject ADSscript;
    public GameObject LOGSscript;
    public GameObject Weight3;
    public GameObject Weight1;
    public GameObject Dest1;
    public GameObject ACPID1;
    public GameObject ACPID2;
    public GameObject InputField1;
    public GameObject InputField2;


    public GameObject DblprefabLogs;
    public GameObject DblprefabADS;
    public GameObject Maincanvas;



    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(MakeDblpallet);



    }


    public void MakeDblpallet()
    {
        Maincanvas.GetComponent<RaycastOff>().TurnOffRaycast();
        //gameObject.GetComponent<Button>().;



      /*  if (LOGSscript.GetComponent<ActivateADSLOGS>().LOGSbool == true)

        {
            GameObject Dblprefab1 = Instantiate(DblprefabLogs);


            Dblprefab1.transform.localPosition = new Vector3(0, 0.83f, 0);
            Dblprefab1.layer = LayerMask.NameToLayer("LOGS");
            TMPro.TextMeshProUGUI weight2 = Dblprefab1.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight = Weight1.GetComponent<TMPro.TextMeshProUGUI>();
            weight2.text = weight.text;
            TMPro.TextMeshProUGUI weight3 = Dblprefab1.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight4 = Weight3.GetComponent<TMPro.TextMeshProUGUI>();
            weight3.text = weight4.text;
            TMPro.TextMeshProUGUI destACP = Dblprefab1.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI destin1 = Dest1.GetComponent<TMPro.TextMeshProUGUI>();
            destACP.text = destin1.text;
            TMPro.TextMeshProUGUI dest2ACP = Dblprefab1.transform.GetChild(0).GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
            dest2ACP.text = destin1.text;
            TMPro.TextMeshProUGUI ACPid1 = Dblprefab1.transform.GetChild(0).GetChild(4).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin1 = ACPID1.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid1.text = ACPin1.text;
            TMPro.TextMeshProUGUI ACPid2 = Dblprefab1.transform.GetChild(0).GetChild(5).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin2 = ACPID2.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid2.text = ACPin2.text;


            Debug.Log("LOGSpalletcreated");
            Dblprefab1.transform.localEulerAngles = new Vector3(-90, 0, 0);

            int weightint1 = Int32.Parse(InputField1.GetComponent<TMP_InputField>().text.ToString());
            int weightint2 = Int32.Parse(InputField2.GetComponent<TMP_InputField>().text.ToString());
            Payload.TotalPayloadWt += weightint1 + weightint2;
        }

        */


        if (ActivateADSLOGS.ADSbool == true)
        {
            GameObject Dblprefab1ADS = Instantiate(DblprefabADS);


            Dblprefab1ADS.transform.localPosition = new Vector3(0, 0.83f, 0);

           
            Debug.Log("ADSpalletcreated");
           /* TMPro.TextMeshProUGUI weight2 = Dblprefab1ADS.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight = Weight1.GetComponent<TMPro.TextMeshProUGUI>();
            weight2.text = weight.text;
            TMPro.TextMeshProUGUI weight3 = Dblprefab1ADS.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI weight4 = Weight3.GetComponent<TMPro.TextMeshProUGUI>();
            weight3.text = weight4.text;
            TMPro.TextMeshProUGUI destACP = Dblprefab1ADS.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI destin1 = Dest1.GetComponent<TMPro.TextMeshProUGUI>();
            destACP.text = destin1.text;
            TMPro.TextMeshProUGUI dest2ACP = Dblprefab1ADS.transform.GetChild(0).GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
            dest2ACP.text = destin1.text;
            TMPro.TextMeshProUGUI ACPid1 = DblprefabADS.transform.GetChild(0).GetChild(4).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin1 = ACPID1.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid1.text = ACPin1.text;
            TMPro.TextMeshProUGUI ACPid2 = DblprefabADS.transform.GetChild(0).GetChild(5).GetComponent<TMPro.TextMeshProUGUI>();
            TMPro.TextMeshProUGUI ACPin2 = ACPID2.GetComponent<TMPro.TextMeshProUGUI>();
            ACPid2.text = ACPin2.text;

            */

            Dblprefab1ADS.transform.localEulerAngles = new Vector3(-90, 0, 90);

            //  int weightint1 = Int32.Parse(InputField1.GetComponent<TMP_InputField>().text.ToString());
            //int weightint2 = Int32.Parse(InputField2.GetComponent<TMP_InputField>().text.ToString());
            // Payload.TotalPayloadWt += weightint1 + weightint2;
            PalletArray.AddACPtoList(Dblprefab1ADS);
            Debug.Log("DBL ADDED TO LIST");



        }


    }


}

