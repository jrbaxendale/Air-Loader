using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ContactQd : MonoBehaviour
{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
    private bool dragging = false;
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    private Collider otherParent;
    public GameObject DeleteBtnUI;

    public Material Invisible;
    public Material HighlightedACP;
    public Material ADSMat;
    public GameObject Maincanvas;
    public Material LogsMat;
    public GameObject Col1;
    public GameObject Col2;
    public GameObject Col3;
    public Collision Othertransform;
    public Collision OOthertransform;
    public Collision stay;
    public List<GameObject> PalletList;
    public float first;
    public float second;
    public float third;
    public GameObject FwdPosition;
    public GameObject Position;
    public GameObject AftPosition;
    public GameObject AftMidPosition;

    public bool CanLoadACP;
    public static string ParentName;
    public static string PalletsWeight;
    public static string PalletsID;
    public static string PalletsDest;
    public static string Sgl;

    [ES3Serializable]
    public GameObject Weight1;


    [ES3Serializable]
    public GameObject Dest1;


    [ES3Serializable]
    public GameObject ACPID;



    public void Awake()
    {
        Maincanvas = GameObject.Find("MainCanvas");
        Othertransform = null;
        PalletList = new List<GameObject>();

    }

    private void Start()
    {



        //transform.position = new Vector3(0, 1.02f, -1.02f);



    }


    void OnMouseDown()


    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;

    }


    void OnMouseUp()
    {
        dragging = false;
    }

    public void OnCollisionEnter(Collision collision)

    {

        PalletList.Add(collision.gameObject);
        Debug.Log("Pallet List added is .." + collision.gameObject.name);


        col = true;

        if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null)
        {
            int a = collision.transform.parent.transform.GetSiblingIndex();

            if (collision.transform.parent.transform.parent.GetChild(a - 1).transform.GetChild(0).transform.childCount == 0 &&
                 collision.transform.parent.transform.parent.GetChild(a + 1).transform.GetChild(0).transform.childCount == 0
                 && collision.transform.parent.transform.parent.GetChild(a + 2).transform.GetChild(0).transform.childCount == 0)
                 

            {
                collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;

                collision.transform.parent.transform.parent.GetChild(a - 1).transform.GetComponent<Renderer>().material = HighlightedACP;

                collision.transform.parent.transform.parent.GetChild(a + 1).transform.GetComponent<Renderer>().material = HighlightedACP;

                collision.transform.parent.transform.parent.GetChild(a + 2).transform.GetComponent<Renderer>().material = HighlightedACP;

            }




        }

        othertransform = collision; // othertransform is the gameobject( logs or ADS child collider) which the pallet has collided with

    }


    public void OnCollisionStay(Collision staycollision)
    {
        stay = staycollision;



    }

    public void OnCollisionExit(Collision outcollision)

    {
        if ((outcollision.transform.parent.name.Contains("ADS")) && (outcollision.transform.parent.tag != "ignore"))
        {
            outcollision.transform.parent.GetComponent<Renderer>().material = ADSMat; // returns the material of the collided object back to its original
            int a = outcollision.transform.parent.transform.GetSiblingIndex();
            outcollision.transform.parent.transform.parent.GetChild(a - 1).transform.GetComponent<Renderer>().material = ADSMat;
            outcollision.transform.parent.transform.parent.GetChild(a + 1).transform.GetComponent<Renderer>().material = ADSMat;
            outcollision.transform.parent.transform.parent.GetChild(a + 2).transform.GetComponent<Renderer>().material = ADSMat;
        }

        else if (outcollision.transform.parent.name.Contains("logs"))
        {
            outcollision.transform.parent.GetComponent<Renderer>().material = LogsMat; // returns the material of the collided object back to its original
            int a = outcollision.transform.parent.transform.GetSiblingIndex();
            outcollision.transform.parent.transform.parent.GetChild(a - 1).transform.GetComponent<Renderer>().material = LogsMat;
            outcollision.transform.parent.transform.parent.GetChild(a + 1).transform.GetComponent<Renderer>().material = LogsMat;
            outcollision.transform.parent.transform.parent.GetChild(a + 2).transform.GetComponent<Renderer>().material = LogsMat;

        }

        PalletList.Remove(outcollision.gameObject);
        Debug.Log("Pallet List removed is .." + outcollision.gameObject.name);

    }





    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))


        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;


        }


        if
            ((!dragging) && (placed == false))
        {
            if (gameObject.name.Contains("LOGS"))
            {

                transform.position = new Vector3(0, 1.02f, -1.02f); // if player lets go of the mouse button and its not above a pallet position it will return the pallet to 0,0,0,

            }

            else if (gameObject.name.Contains("ADS"))
            {

                transform.position = new Vector3(0, 1.02f, 0); // if player lets go of the mouse button and its not above a pallet position it will return the pallet to 0,0,0,

            }
        }

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            rayPoint.x = Mathf.Clamp(rayPoint.x, -13.4f, 11.4f);// these 3 lines limit where the pallet can be dragged to
            rayPoint.z = Mathf.Clamp(rayPoint.z, -2.1f, 2.1f);
            rayPoint.y = Mathf.Clamp(rayPoint.y, 1.02f, 1.02f);


            transform.position = rayPoint;
            Debug.Log("dragging");

        }


        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            CheckPalletPositions();

            if (CanLoadACP == true)

            {


                if ((Position.transform.name.Contains("col")) && (col == true) && (placed == false)) // this checks whether the pallet has collided with the correct collider called 'col'; checks whether the collision is actually true; checks there is not another pallet on it already (placed == false)
                {
                    LoadQDPallet();


                }



            }
        }





    }

    void CheckPalletPositions()
    {
        foreach (GameObject G in PalletList)

        {

            Debug.Log("Pallet List Contains", G.gameObject);


        }

        if (PalletList.Count == 1)

        {


            Col1 = PalletList[0].gameObject;


            Position = Col1;
            int a = Col1.transform.parent.GetSiblingIndex();
            AftMidPosition = Col1.transform.parent.transform.parent.transform.GetChild(a + 1).transform.GetChild(0).transform.gameObject;
            FwdPosition = Col1.transform.parent.transform.parent.transform.GetChild(a - 1).transform.GetChild(0).transform.gameObject;
            AftPosition = Col1.transform.parent.transform.parent.transform.GetChild(a + 2).transform.GetChild(0).transform.gameObject;

            if (AftPosition.transform.childCount == 0 && FwdPosition.transform.childCount == 0)

            {
                CanLoadACP = true;
                Debug.Log("Can Load");
            }

        }

        else
        {

            CanLoadACP = false;
            Debug.Log("Cannot Load" + PalletList.Count);

        }


    }



    public void LoadQDPallet()
    {
        Debug.Log("LoadingQD");
        gameObject.transform.SetParent(Position.transform); // sets the pallet parent to the collider
        gameObject.GetComponent<ACP_PayloadQD>().OriginalPosition = gameObject.transform.parent.gameObject;
        gameObject.transform.localPosition = new Vector3(0, 0, 2.06f); // sets local position of the pallet to 0
        gameObject.tag = "loaded"; // pallet tag is loaded
        gameObject.layer = LayerMask.NameToLayer("loaded"); // pallet layer is loaded
                                                            //gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = !enabled; // thjis turns of the orange glow animation
        othertransform.gameObject.tag = "loaded"; // this puts the pallet positions collider tag as loaded
        othertransform.transform.parent.gameObject.tag = "loaded"; // this sets the pallet positions tag as loaded
        othertransform.gameObject.layer = LayerMask.NameToLayer("nohit"); // this sets the pallet positions layer to 'nohit' 
        othertransform.transform.parent.gameObject.layer = LayerMask.NameToLayer("loaded"); // this sets the pallet position layer to loaded
        ParentName = gameObject.transform.parent.parent.name; // this is the name of the position the pallet is in.
                                                              //PalletsWeight = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text; // this is the weight of the pallet.
                                                              // PalletsID = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>().text; // this is the Pallet ID
                                                              // PalletsDest = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text; // this is the pallet destination
                                                              // string Sgl = "Sgl"; // this is to identify that it is a single pallet
        Debug.Log(ParentName + "The Parent Name");
        // SaveManager.SaveTheLoad(ParentName, PalletsID, PalletsWeight, PalletsDest, Sgl); // this saves the pallet data
        placed = true; // this lets other pallets know that the position is occupied
        thisBody = gameObject.GetComponent<Rigidbody>();
        thisBody.isKinematic = true; // sets the pallet kinematic to true (otherwise it floats off...)
        thisCollider = gameObject.GetComponent<BoxCollider>();
        thisCollider.enabled = !thisCollider.enabled; // turns off the pallets collider
        Position.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the FWD pallet positions collider
        FwdPosition.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the AFTpallet positions collider
        AftPosition.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the AFTpallet positions collider
        AftMidPosition.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the AFTMidpallet positions collider

        Maincanvas.GetComponent<RaycastOff>().TurnOnRaycast(); // this turns the raycast back on now that the pallet is placed
        Position.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the FWD pallet position material to invisible
        FwdPosition.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the AFT pallet position material to invisible
        AftPosition.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the AFT pallet position material to invisible
        AftMidPosition.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the AFTmid pallet position material to invisible
                                                                                    // gameObject.GetComponent<ACP_PayloadTPL>().GetTitle();


        Position.transform.parent.GetComponent<BoxCollider>().enabled = enabled; // this turns off the 
        FwdPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        AftPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        AftMidPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;

        Position.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        FwdPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        AftPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        AftMidPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;

        Maincanvas.transform.GetChild(1).gameObject.SetActive(true); // this is which pallet panel
        Maincanvas.transform.GetChild(6).gameObject.SetActive(true); // this is config
        Maincanvas.transform.GetChild(7).gameObject.SetActive(true); // this is part one
        Maincanvas.transform.GetChild(8).gameObject.SetActive(true); // this is load view
        GameObject TemporaryChild = new GameObject(); // this is puts a empty gameobject in the aft pallet position of the triple
        //PalletArray.AddACPtoList(TemporaryChild);
        TemporaryChild.gameObject.transform.SetParent(AftPosition.transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChild.gameObject.name = "QdAFT(Clone)"; // this matches the names of the double pallet positions so it is clear they are linked

        GameObject TemporaryChildFwd = new GameObject(); // this is puts a empty gameobject in the FWD pallet position of the triple
                                                         // PalletArray.AddACPtoList(TemporaryChildFwd);
        TemporaryChildFwd.gameObject.transform.SetParent(FwdPosition.transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChildFwd.gameObject.name = "QdFwd(Clone)"; // this matches the names of the double pallet positions so it is clear they are linked

        GameObject TemporaryChildMid = new GameObject(); // this is puts a empty gameobject in the mid pallet position of the triple
        // PalletArray.AddACPtoList(TemporaryChildFwd);
        TemporaryChildMid.gameObject.transform.SetParent(AftMidPosition.transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChildMid.gameObject.name = "QdAftMid(Clone)"; // this matches the names of the double pallet positions so it is clear they are linked


        GameObject Make = GameObject.FindGameObjectWithTag("AddQDACP"); // this finds the makeACP button
        Make.gameObject.GetComponent<Button>().interactable = true; // this turns the makeACP button back on now the pallet is placed
        gameObject.GetComponent<ACP_PayloadQD>().StartPos = gameObject.transform.parent.transform.gameObject;
        Destroy(this); // destroys this script as it gets in the way of the MOVE and Delete scripts





    }






}










