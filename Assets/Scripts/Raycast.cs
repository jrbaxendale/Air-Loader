using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class Raycast : MonoBehaviour
{


    public TextMeshProUGUI Infotitle;
    public TextMeshProUGUI ACPtitle;
    public GameObject DeleteBtnUI;
    public GameObject MainCanvas;
    private Collider Coll;
    public GameObject MoveBtnUI;
    public GameObject DeleteBtnUIDouble;
    public GameObject DeleteBtnUITriple;
    public GameObject DeleteBtnUIQuad;
    public static RaycastHit hit;
    public static Transform target;
    public static bool pause;
    public GameObject DeleteBtnLogsDouble;
    public GameObject DeleteBtnLogsTriple;
    public GameObject DeleteBtnLogsQuad;
    public GameObject MoveACP;
    public LayerMask nohit;
    public GameObject MoveBtnLogsDouble;
    public GameObject MoveBtnLogsTriple;
    public GameObject MoveBtnLogsQd;
    public GameObject MoveADSdouble;
    public GameObject MoveADSTriple;
    public GameObject MoveADSQuad;
    public GameObject MovingCam;
    public GameObject MainCam;
    public GameObject me;
    public float smoothTime = 10;
    private Vector3 velocity = Vector3.zero;
    public GameObject ExitButton;
    public GameObject ExitButtondel;
    public GameObject BackgroundImage;
    public GameObject PalletGUICanvas;
    public GameObject PalletCanvasCam;
    public GameObject PalletGUIcam;
    public GameObject PalletCam;
    public GameObject Vcam1;
    public GameObject StateDrivenCam;
    public GameObject PalletLoadGUI;
    public Material Red;
    public GameObject DGpalletCanvas;
    public GameObject LooseLoadCheckCanvas;
    private float[] touchLength;
    public Touch touch;
    public Touch touchtwo;
    public Touch touchthree;
    public float TouchCounter;
    public Vector2 TouchPosition;
    public TextMeshProUGUI TouchDisplay;
    public float touchDuration;
    public float firsttouchtime;
    public float secondtouchtime;
    public bool UsingMouse;
    public GameObject SelectedPanel;
    public GameObject WhichPanel;
    public GameObject SingleACPpanel;

    [SerializeField]
    public static bool SelectedPanelisLive;

    public static GameObject OldSelectedPanel;
    public bool Demo;
    public GameObject SelectedPanelDBL;
    public GameObject SelectedPanelTPL;
    public GameObject SelectedPanelQD;



    public void Start()
    {
        Coll = GetComponent<BoxCollider>();
        pause = false;
        TouchCounter = 0;
        UsingMouse = false;

    }


    void Update()
    {
        TouchDisplay.text = TouchCounter.ToString(); // displays the number of touches

        Demo = SelectedPanelisLive;
        if ((Input.touchCount > 0) || (Input.GetMouseButtonDown(0)))
        {

            TouchCounter = Input.touchCount;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, Mathf.Infinity, ~nohit);
            target = hit.transform;


            if (Input.touchCount > 0)

            {

                if (Input.GetTouch(0).tapCount == 2)
                {
                    Debug.Log("HEREEEE");
                    UsingMouse = false;
                    TouchPosition = Input.GetTouch(0).position;
                    CreateSelectedPanel();
                }

            }



            else if ((!EventSystem.current.IsPointerOverGameObject()) && (hit.collider != null) && (hit.collider.name.Contains("ADS")))

            {
                if ((hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("ACP(Clone)")))

                {


                    if (SelectedPanelisLive == false)
                    {
                        Debug.Log("HERE");
                        UsingMouse = true;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanel(); // creates a panel for the pallet selected.

                    }

                    else if (SelectedPanelisLive == true)

                    {
                        Debug.Log("ACTUALLYHERE");
                        OldSelectedPanel = GameObject.Find("SelectedPanel(Clone)").gameObject.transform.GetChild(1).gameObject;
                        OldSelectedPanel.GetComponent<ExitBtnDelete>().ExitDelete(); // this closes down the already live Selected Panel;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanel(); // creates a panel for the pallet selected.


                    }

                }

                else if ((hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("ADSdouble(Clone)")))


                {
                    if (SelectedPanelisLive == false)
                    {
                        Debug.Log("HERE");
                        UsingMouse = true;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelDBL(); // creates a panel for the pallet selected.

                    }

                    else if (SelectedPanelisLive == true)

                    {
                        Debug.Log("ACTUALLYHERE");
                        OldSelectedPanel = GameObject.Find("SelectedPanelDBL(Clone)").gameObject.transform.GetChild(1).gameObject;
                        OldSelectedPanel.GetComponent<ExitBtnDelete>().ExitDelete(); // this closes down the already live Selected Panel;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelDBL(); // creates a panel for the pallet selected.


                    }


                }

                else if ((hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("ADSdoubleAFT(Clone)")))


                {
                    Debug.Log("THIS FAR");
                    int Index = hit.collider.transform.GetSiblingIndex();
                    target = hit.collider.transform.parent.transform.GetChild(Index - 1).transform;
                    Debug.Log("TARGET NAME ==" + target.name);


                    if (SelectedPanelisLive == false)
                    {
                        Debug.Log("HERE");
                        UsingMouse = true;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelDBL(); // creates a panel for the pallet selected.

                    }

                    else if (SelectedPanelisLive == true)

                    {
                        Debug.Log("ACTUALLYHERE");
                        OldSelectedPanel = GameObject.Find("SelectedPanel(Clone)").gameObject.transform.GetChild(1).gameObject;
                        OldSelectedPanel.GetComponent<ExitBtnDelete>().ExitDelete(); // this closes down the already live Selected Panel;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelDBL(); // creates a panel for the pallet selected.


                    }


                }

                else if ((hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("TRIPLEADS(Clone)")))


                {
                    if (SelectedPanelisLive == false)
                    {
                        Debug.Log("HERE");
                        UsingMouse = true;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelTPL(); // creates a panel for the pallet selected.

                    }

                    else if (SelectedPanelisLive == true)

                    {
                        Debug.Log("ACTUALLYHERE");
                        OldSelectedPanel = GameObject.Find("SelectedPanelTPL(Clone)").gameObject.transform.GetChild(1).gameObject;
                        OldSelectedPanel.transform.GetChild(0).transform.GetChild(2).GetComponent<CloseTPLselectedPanel>().ExitDelete(); // this closes down the already live Selected Panel;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelTPL(); // creates a panel for the pallet selected.


                    }


                }

                else if ((hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("QUADADS(Clone)")))


                {
                    if (SelectedPanelisLive == false)
                    {
                        Debug.Log("HERE");
                        UsingMouse = true;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelQD(); // creates a panel for the pallet selected.

                    }

                    else if (SelectedPanelisLive == true)

                    {
                        Debug.Log("ACTUALLYHERE");
                        OldSelectedPanel = GameObject.Find("SelectedPanelQD(Clone)").gameObject;
                        OldSelectedPanel.transform.GetChild(2).GetComponent<CloseQDselectedPanel>().ExitDelete(); // this closes down the already live Selected Panel;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelQD(); // creates a panel for the pallet selected.


                    }
                    
                }
                
            }


            if ((!EventSystem.current.IsPointerOverGameObject()) && (hit.collider != null) && (hit.collider.name.Contains("logs")))

            {
                if ((hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("ACP(Clone)")))

                {


                    if (SelectedPanelisLive == false)
                    {
                        Debug.Log("HERE");
                        UsingMouse = true;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanel(); // creates a panel for the pallet selected.

                    }

                    else if (SelectedPanelisLive == true)

                    {
                        Debug.Log("ACTUALLYHERE");
                        OldSelectedPanel = GameObject.Find("SelectedPanel(Clone)").gameObject.transform.GetChild(1).gameObject;
                        OldSelectedPanel.GetComponent<ExitBtnDelete>().ExitDelete(); // this closes down the already live Selected Panel;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanel(); // creates a panel for the pallet selected.


                    }

                }


                if ((hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("LOGSdbl (Clone)")))

                {
                    
                    if (SelectedPanelisLive == false)

                    {
                        
                        UsingMouse = true;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelDBL(); // creates a panel for the pallet selected.

                    }

                    else if (SelectedPanelisLive == true)

                    {
                        OldSelectedPanel = GameObject.Find("SelectedPanelDBL(Clone)").gameObject.transform.GetChild(1).gameObject;
                        OldSelectedPanel.transform.GetChild(0).transform.GetChild(2).GetComponent<CloseTPLselectedPanel>().ExitDelete(); // this closes down the already live Selected Panel;
                        CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                        CreateSelectedPanelDBL(); // creates a panel for the pallet selected.
                    }
                    
                }
                
                if (hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("TRIPLELOGS(Clone)"))

                {


                    switch (SelectedPanelisLive)

                    {
                        case false:
                            Debug.Log("HERE");
                            UsingMouse = true;
                            CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                            CreateSelectedPanelTPL(); // creates a panel for the pallet selected.

                            break;
                        case true:
                            Debug.Log("ACTUALLYHERE");
                            OldSelectedPanel = GameObject.Find("SelectedPanelTPL(Clone)").gameObject.transform.GetChild(1).gameObject;
                            OldSelectedPanel.transform.GetChild(0).transform.GetChild(2).GetComponent<CloseTPLselectedPanel>().ExitDelete(); // this closes down the already live Selected Panel;
                            CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                            CreateSelectedPanelTPL(); // creates a panel for the pallet selected.


                            break;
                    }




                }

                if (hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("QUADLOGSbase(Clone)"))

                {


                    switch (SelectedPanelisLive)

                    {
                        case false:
                           
                            UsingMouse = true;
                            CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                            CreateSelectedPanelQD(); // creates a panel for the pallet selected.

                            break;
                        case true:
                          
                            OldSelectedPanel = GameObject.Find("SelectedPanelQD(Clone)").gameObject;
                            OldSelectedPanel.transform.GetChild(0).transform.GetChild(2).GetComponent<CloseQDselectedPanel>().ExitDelete(); // this closes down the already live Selected Panel;
                            CloseWhichPanels(); // closes the Which Pallet Panel and the Single Panel.
                            CreateSelectedPanelQD(); // creates a panel for the pallet selected.


                            break;
                    }




                }

            }
        }

    }

    

    public void ExitFromPalletGUI()
    {
        PalletArray.AddACPtoList(hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject);
        PalletGUICanvas.SetActive(false);
        StateDrivenCam.GetComponent<CamSwitch>().SwitchState();
        Vcam1.GetComponent<MouseDrag>().enabled = false;
        Vcam1.GetComponent<MouseDrag>().target = null;
        PalletLoadGUI.SetActive(false);
        MainCanvas.SetActive(true);
        MainCanvas.GetComponent<Raycast>().enabled = enabled;
        target.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.gameObject.GetComponent<LineDraw>().enabled = !enabled;

        if (target.transform.GetChild(0).transform.GetChild(0).transform.childCount > 2)
        {

            // target.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.gameObject.SetActive(false);
            target.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.gameObject.SetActive(false);
            target.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.gameObject.SetActive(false);
            target.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.gameObject.GetComponent<LineDraw>().enabled = !enabled;
            target.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.gameObject.GetComponent<LineRenderer>().enabled = !enabled;
            target.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<DgInfoRotate>().enabled = !enabled;

        }


    }



    public void ExitFromLooseCheclGUI()


    {
        LooseLoadCheckCanvas.SetActive(false);
        StateDrivenCam.GetComponent<CamSwitch>().SwitchState();
        Vcam1.GetComponent<MouseDrag>().enabled = false;
        Vcam1.GetComponent<MouseDrag>().target = null;
        MainCanvas.SetActive(true);
        MainCanvas.GetComponent<Raycast>().enabled = enabled;

    }



    public void CreateSelectedPanel()  // This loads a SelectedPanel for the selected pallet


    {

        SelectedPanelisLive = true;
        Debug.Log("Creating Selected Panel");
        

        if (target == null)

        {
            Debug.Log("No Hit");

        }

        else if ((target != null) && (hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("ACP(Clone)")))

        {
            pause = true;
            GameObject TheSelectedPanel = Instantiate(SelectedPanel, MainCanvas.transform, false);
            TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACPpayload>().palletint.ToString();

            PalletArray.RemoveACPfromList(hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject); // removes the target pallet from the array
            int TheCount = PalletArray.Palletarray.Count;
            GetComponent<PalletArray>().ChangeColourDark(); // all the other pallets are in this array and will turn dark coloured

        }

        else if ((target != null) && (hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("ADSdouble(Clone)")))

        {
            pause = true;
            GameObject TheSelectedPanel = Instantiate(SelectedPanelDBL, MainCanvas.transform, false);
            TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACPpayload>().palletint.ToString();
            int Pos = target.gameObject.transform.GetSiblingIndex();
            GameObject Obj = target.gameObject.transform.parent.transform.GetChild(Pos + 1).transform.gameObject;
            TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.name.ToString(); // this gets the pallet position of the aft pallet of double ADS

            PalletArray.RemoveACPfromList(hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject); // removes the target pallet from the array
            int TheCount = PalletArray.Palletarray.Count;
            GetComponent<PalletArray>().ChangeColourDark(); // all the other pallets are in this array and will turn dark coloured

        }

        else if ((target != null) && (hit.collider.transform.GetChild(0).transform.GetChild(0).transform.name.Equals("ADSdoubleAFT(Clone)")))

        {
            
            pause = true;
            GameObject TheSelectedPanel = Instantiate(SelectedPanelDBL, MainCanvas.transform, false);
            TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACPpayload>().palletint.ToString();
            int Pos = target.gameObject.transform.GetSiblingIndex();
            GameObject Obj = target.gameObject.transform.parent.transform.GetChild(Pos + 1).transform.gameObject;
            TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.name.ToString(); // this gets the pallet position of the aft pallet of double ADS

            PalletArray.RemoveACPfromList(hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject); // removes the target pallet from the array
            int TheCount = PalletArray.Palletarray.Count;
            GetComponent<PalletArray>().ChangeColourDark(); // all the other pallets are in this array and will turn dark coloured

        }

        

    }

    public void CreateSelectedPanelDBL()  // This loads a SelectedPanel for the selected pallet


    {

        SelectedPanelisLive = true;
        Debug.Log("Creating Selected Panel");



        Debug.Log("Terror" + target.name);
        pause = true;
        GameObject TheSelectedPanel = Instantiate(SelectedPanelDBL, MainCanvas.transform, false);
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadDBL>().palletint.ToString(); // this is the pallet weight FWD
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadDBL>().palletintAFT.ToString(); // this is the pallet weight AFT
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadDBL>().CombinedWt.ToString(); // this is the total weight

        int Pos = target.gameObject.transform.GetSiblingIndex();
        GameObject Obj = target.transform.parent.GetChild(Pos + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.parent.name; // this gets the pallet position of the aft pallet of double ADS

        PalletArray.RemoveACPfromList(hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject); // removes the target pallet from the array
        PalletArray.RemoveACPfromList(Obj);
        int TheCount = PalletArray.Palletarray.Count;
        Debug.Log("PALLET ARRAY NUMBER IS " + TheCount);


        GetComponent<PalletArray>().ChangeColourDark(); // all the other pallets are in this array and will turn dark coloured

        foreach (GameObject OBW in PalletArray.Palletarray)

        {
            OBW.transform.parent.transform.parent.transform.GetComponent<BoxCollider>().enabled = !enabled;

        }


    }

    public void CreateSelectedPanelTPL()  // This loads a SelectedPanel for the selected pallet


    {

        SelectedPanelisLive = true;
        Debug.Log("Creating Selected Panel");



        Debug.Log("Terror" + target.name);
        pause = true;
        GameObject TheSelectedPanel = Instantiate(SelectedPanelTPL, MainCanvas.transform, false);
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadTPL>().palletintFWD.ToString(); // this is the pallet weight FWD
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadTPL>().palletintMID.ToString(); // this is the pallet weight MID
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadTPL>().palletintAFT.ToString(); // this is the pallet weight AFT

        int Pos = target.gameObject.transform.GetSiblingIndex();
        GameObject Obj = hit.transform.gameObject;

        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.GetChild(Pos -1).transform.name.ToString(); // this is the FWD position

        
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.name.ToString(); // this is the MID position

        
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.GetChild(Pos + 1).transform.name.ToString(); // this is the AFT position
      
        PalletArray.RemoveACPfromList(hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject); // removes the target pallet from the array
        PalletArray.RemoveACPfromList(Obj);
        int TheCount = PalletArray.Palletarray.Count;
        Debug.Log("PALLET ARRAY NUMBER IS " + TheCount);


        GetComponent<PalletArray>().ChangeColourDark(); // all the other pallets are in this array and will turn dark coloured

        foreach (GameObject OBW in PalletArray.Palletarray)

        {
            OBW.transform.parent.transform.parent.transform.GetComponent<BoxCollider>().enabled = !enabled;

        }


    }

    public void CreateSelectedPanelQD()  // This loads a SelectedPanel for the selected pallet


    {

        SelectedPanelisLive = true;
        pause = true;
        GameObject TheSelectedPanel = Instantiate(SelectedPanelQD, MainCanvas.transform, false);
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadQD>().palletintFWD.ToString(); // this is the pallet weight FWD
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadQD>().palletintMIDFWD.ToString(); // this is the pallet weight MIDFWD
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadQD>().palletintAFTMID.ToString(); // this is the pallet weight AFTMID
        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = target.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ACP_PayloadQD>().palletintAFT.ToString(); // this is the pallet weight AFT


        int Pos = target.gameObject.transform.GetSiblingIndex();
        GameObject Obj = hit.transform.gameObject;

        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.GetChild(Pos - 1).transform.name.ToString(); // this is the FWD position


        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.name.ToString(); // this is the MIDFWD position


        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.GetChild(Pos + 1).transform.name.ToString(); // this is the AFTMID position

        TheSelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.GetChild(Pos + 2).transform.name.ToString(); // this is the AFT position

        PalletArray.RemoveACPfromList(hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject); // removes the target pallet from the array
        PalletArray.RemoveACPfromList(Obj);
        int TheCount = PalletArray.Palletarray.Count;
        Debug.Log("PALLET ARRAY NUMBER IS " + TheCount);


        GetComponent<PalletArray>().ChangeColourDark(); // all the other pallets are in this array and will turn dark coloured

        foreach (GameObject OBW in PalletArray.Palletarray)

        {
            OBW.transform.parent.transform.parent.transform.GetComponent<BoxCollider>().enabled = !enabled;

        }


    }


    public void MoveCamtoPallet()


    {

        MainCanvas.SetActive(false);
        Vcam1.transform.position = new Vector3(target.position.x - 2, target.position.y + 7, target.position.z - 7);
        // bool CamSwitchBool = !StateDrivenCam.GetComponent<CamSwitch>().Cam2;
        StateDrivenCam.GetComponent<CamSwitch>().SwitchState();
        Vcam1.GetComponent<MouseDrag>().enabled = true;
        Vcam1.GetComponent<MouseDrag>().target = target;
        LooseLoadCheckCanvas.SetActive(true);

    }


    public void CloseWhichPanels()

    {
        WhichPanel.SetActive(false);
        SingleACPpanel.SetActive(false);


    }

}















