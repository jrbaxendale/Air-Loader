using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DangerousGoods : MonoBehaviour
{
   
    public GameObject Barrel;
    public GameObject Box;
    
    public GameObject Vcam1;
    public GameObject StateDrivenCam;
    public GameObject MainCanvas;
    public GameObject DGbutton;
    
    public static Vector3 Dgpos;
    public static GameObject Dgposition;
    public static GameObject OtherCrate;
    public GameObject DgCanvas;

    public GameObject DGpallet;
    public GameObject Crate;
    public static List<Transform> DgItemsList;
    public GameObject DGinputPanel;

    public TextMeshProUGUI  AWBno;
    public TextMeshProUGUI UNno;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI Class;
    public TextMeshProUGUI Subclass;
    public static GameObject DgItem;
    public static bool HasDg;

    public void Awake()
    {
        DGpallet = GameObject.Find("DGpallet");
        HasDg = false;
       


    }


    public static void CreateList()
    {
        DgItemsList = new List<Transform>();
        HasDg = true;

    }

    public static void CheckDGposition()
    {
       Dgposition  = GameObject.Find("DGcrate 1(Clone)");
        Dgpos = Dgposition.transform.localPosition;

        
    }
    
    public void ExitFromDGpalletGUI()
    {
       
       
        
        DGbutton.GetComponent<DGcamSwitch>().DGcameraSwitch();
        DgItem.transform.GetChild(0).GetChild(0).transform.GetComponent<DGlabelControl>().enabled = !enabled;
        DgItem.transform.GetChild(0).transform.gameObject.SetActive(false);
        DgItem.GetComponent<LineDraw>().enabled = !enabled;





    }

    public void AddCrate()
    {
        Vector3 CratePos = new Vector3(DGpallet.transform.position.x, DGpallet.transform.position.y, DGpallet.transform.position.z);
        Quaternion CrateRot = new Quaternion(DGpallet.transform.rotation.x, DGpallet.transform.rotation.y, DGpallet.transform.rotation.z, DGpallet.transform.rotation.w);
        GameObject NewCrate = Instantiate(Crate, CratePos, CrateRot);
        NewCrate.transform.parent = DGpallet.transform;
        NewCrate.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        AWBno.text = DGinputPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        UNno.text = DGinputPanel.transform.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        ItemName.text = DGinputPanel.transform.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
        Class.text = DGinputPanel.transform.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text;
        Subclass.text = DGinputPanel.transform.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text;
        NewCrate.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = AWBno.text;
        NewCrate.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = UNno.text;
        NewCrate.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ItemName.text;
        NewCrate.transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = Class.text;
        NewCrate.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = Subclass.text;
        DgItemsList.Add(NewCrate.transform);
        DgItem = NewCrate;
        

        Debug.Log("DGcrate Added");




    }


}
