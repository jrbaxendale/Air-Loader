using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContactDBLOGS : MonoBehaviour

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
    public Collision Othertransform;
    public Collision OOthertransform;
    public Collision stay;
    public List<GameObject> PalletList;
    public float first;
    public float second;
    public GameObject FwdPosition;
    public GameObject AftPosition;
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
        

    }

    private void Start()
    {



        transform.position = new Vector3(-1.3f, 1.01f, -1.01f);
        
        PalletList = new List<GameObject>();

    }

    

    void OnMouseDown()


    {
     
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;

    }


    void OnMouseUp()
    {
        dragging = false;
        gameObject.GetComponent<BoxCollider>().enabled = !enabled;
    }

    public void OnCollisionEnter(Collision collision)

    {
        


        if (collision.collider.gameObject.name.Contains("col"))
        {

            PalletList.Add(collision.gameObject);
            Debug.Log("PALLET COUNT ON ADD IS.." + PalletList.Count);
            Debug.Log("PALLET COUNT ON ADD name.." + collision.gameObject.transform.parent.name);

            foreach (GameObject g in PalletList)

            {
                Debug.Log(g.transform.parent.name);

            }



        }

        col = true;

        if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null)
        {
            int a = collision.transform.parent.transform.GetSiblingIndex();

            if (collision.transform.childCount == 0 &&
                 collision.transform.parent.transform.parent.GetChild(a + 1).transform.GetChild(0).transform.childCount == 0)
            {
                PalletList.Add(collision.transform.parent.transform.parent.GetChild(a + 1).transform.GetChild(0).transform.gameObject);
                collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;

                collision.transform.parent.transform.parent.GetChild(a + 1).transform.GetComponent<Renderer>().material = HighlightedACP;

            }
            othertransform = collision; // othertransform is the gameobject( logs or ADS child collider) which the pallet has collided with
        }
    }


    public void OnCollisionStay(Collision staycollision)
    {
        stay = staycollision;



    }

    public void OnCollisionExit(Collision outcollision)

    {
        if (outcollision.collider.gameObject.name.Contains("col"))
        {

            PalletList.Remove(outcollision.gameObject);
            
            Debug.Log("PALLET REMOVED IS ", outcollision.gameObject);
            Debug.Log("PALLETCOUNT IS " + PalletList.Count);

            foreach (GameObject g in PalletList)

            {
                Debug.Log(g.transform.parent.name);

            }



        }



        if ((outcollision.transform.parent.name.Contains("ADS")) && (outcollision.transform.parent.tag != "ignore"))
        {
            int a = outcollision.transform.parent.transform.GetSiblingIndex();

            outcollision.transform.parent.GetComponent<Renderer>().material = ADSMat; // returns the material of the collided object back to its original
            outcollision.transform.parent.transform.parent.GetChild(a + 1).transform.GetComponent<Renderer>().material = ADSMat;
           

            
        }

         if (outcollision.transform.parent.name.Contains("logs"))
        {
            int a = outcollision.transform.parent.transform.GetSiblingIndex();
            outcollision.transform.parent.GetComponent<Renderer>().material = LogsMat; // returns the material of the collided object back to its original
            outcollision.transform.parent.transform.parent.GetChild(a + 1).transform.GetComponent<Renderer>().material = LogsMat;
            PalletList.Remove(outcollision.transform.parent.transform.parent.GetChild(a + 1).transform.GetChild(0).transform.gameObject);


        }

       

    }

    public void Pallist()
    {
        

        
           

        


    }



    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))


        {
            gameObject.GetComponent<BoxCollider>().enabled = enabled;
        }



        if (Input.GetMouseButtonDown(0))


        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;


        }


        if
            ((!dragging) && (placed == false))
        {
            transform.position = new Vector3(-1.3f, 1.01f, -1.01f); // if player lets go of the mouse button and its not above a pallet position it will return the pallet to 0,0,0,

        }

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            rayPoint.x = Mathf.Clamp(rayPoint.x, -13.4f, 11.4f);// these 3 lines limit where the pallet can be dragged to
            rayPoint.z = Mathf.Clamp(rayPoint.z, -2.1f, 2.1f);
            rayPoint.y = Mathf.Clamp(rayPoint.y, 0.28f, 0.28f);


            transform.position = rayPoint;
            Debug.Log("dragging");

        }


        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            CheckPalletPositions();

            if (CanLoadACP == true)

            {


                if ((FwdPosition.transform.name.Contains("col")) && (col == true) && (placed == false)) // this checks whether the pallet has collided with the correct collider called 'col'; checks whether the collision is actually true; checks there is not another pallet on it already (placed == false)
                {
                    LoadDoubleADSPallet();


                }



            }

            else
            {

                Debug.Log("CANNOT LOAD");
            }
        }





    }

    void CheckPalletPositions()
    {
        if (PalletList.Count == 2)

        {
            Col1 = PalletList[0].gameObject;
            first = Col1.transform.parent.transform.GetSiblingIndex();

            Col2 = PalletList[1].gameObject;
            second = Col2.transform.parent.transform.GetSiblingIndex();

            if (first < second)

            {
                FwdPosition = Col1;
                AftPosition = Col2;
                Debug.Log("FWD =" + Col1.name);
                Debug.Log("AFT =" + Col2.name);

            }

            else if (second < first)

            {

                FwdPosition = Col2;
                AftPosition = Col1;
                Debug.Log("FWD = " + Col2.name);
                Debug.Log("AFT =" + Col1.name);
            }

            CanLoadACP = true;

        }

        else
        {
            Debug.Log("PALLET COUNT IS NOT 2");
            Debug.Log("Pallet count is ..." + PalletList.Count);
            CanLoadACP = false;

        }


    }



    public void LoadDoubleADSPallet()
    {
        Debug.Log("LoadingDBLLogs");
        gameObject.transform.SetParent(FwdPosition.transform); // sets the pallet parent to the collider
        gameObject.GetComponent<ACP_PayloadDBL>().OriginalPosition = gameObject.transform.parent.gameObject;
        gameObject.transform.localPosition = new Vector3(0, 0.1f, 2.33f); // sets local position of the pallet to 0
        gameObject.transform.parent.gameObject.layer = LayerMask.NameToLayer("loaded");
        gameObject.tag = "loaded"; // pallet tag is loaded
        gameObject.layer = LayerMask.NameToLayer("loaded"); // pallet layer is loaded
                                                            //gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = !enabled; // thjis turns of the orange glow animation
        othertransform.gameObject.tag = "loaded"; // this puts the pallet positions collider tag as loaded
        othertransform.transform.parent.gameObject.tag = "loaded"; // this sets the pallet positions tag as loaded
        othertransform.gameObject.layer = LayerMask.NameToLayer("nohit"); // this sets the pallet positions layer to 'nohit' 
        othertransform.transform.parent.gameObject.layer = LayerMask.NameToLayer("loaded"); // this sets the pallet position layer to loaded
        ParentName = gameObject.transform.parent.parent.name; // this is the name of the position the pallet is in.
        PalletsWeight = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text; // this is the weight of the pallet.
        PalletsID = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>().text; // this is the Pallet ID
        PalletsDest = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text; // this is the pallet destination
        string Sgl = "Sgl"; // this is to identify that it is a single pallet
        Debug.Log(ParentName + "The Parent Name");
        SaveManager.SaveTheLoad(ParentName, PalletsID, PalletsWeight, PalletsDest, Sgl); // this saves the pallet data
        placed = true; // this lets other pallets know that the position is occupied
        thisBody = gameObject.GetComponent<Rigidbody>();
        thisBody.isKinematic = true; // sets the pallet kinematic to true (otherwise it floats off...)
        thisCollider = gameObject.GetComponent<BoxCollider>();
        thisCollider.enabled = !thisCollider.enabled; // turns off the pallets collider
        FwdPosition.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the FWD pallet positions collider
        AftPosition.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the AFTpallet positions collider
        Maincanvas.GetComponent<RaycastOff>().TurnOnRaycast(); // this turns the raycast back on now that the pallet is placed
        FwdPosition.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the FWD pallet position material to invisible
        AftPosition.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the AFT pallet position material to invisible
        gameObject.GetComponent<ACP_PayloadDBL>().GetTitle();
        FwdPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled; // this turns off the 
        AftPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        FwdPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        AftPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        Maincanvas.transform.GetChild(1).gameObject.SetActive(true); // this is which pallet panel
        Maincanvas.transform.GetChild(6).gameObject.SetActive(true); // this is config
        Maincanvas.transform.GetChild(7).gameObject.SetActive(true); // this is part one
        Maincanvas.transform.GetChild(8).gameObject.SetActive(true); // this is load view
        GameObject TemporaryChild = new GameObject(); // this is puts a empty gameobject in the aft pallet position of the double
        PalletArray.AddACPtoList(TemporaryChild);
        TemporaryChild.gameObject.transform.SetParent(AftPosition.transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChild.gameObject.name = "LOGSdoubleAFT(Clone)"; // this matches the names of the double pallet positions so it is clear they are linked

        GameObject Make = GameObject.FindGameObjectWithTag("AddDoubleACP"); // this finds the makeACP button
        Make.gameObject.GetComponent<Button>().interactable = true; // this turns the makeACP button back on now the pallet is placed
        gameObject.GetComponent<ACP_PayloadDBL>().StartPos = gameObject.transform.parent.transform.gameObject;
        Destroy(this); // destroys this script as it gets in the way of the MOVE and Delete scripts





    }






}










