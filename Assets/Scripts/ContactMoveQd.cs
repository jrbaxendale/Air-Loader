using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContactMoveQD : MonoBehaviour
{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
    private bool dragging = false;
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    public GameObject OldCollider;
    public Material HighlightedACP;
    public Material ADSMat;
    public Material LogsMat;
    public Material Invisible;


    private Collider otherParent;
    public GameObject DeleteBtnUI;


    public GameObject Maincanvas;

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
    public GameObject AftMidPosition;
    public GameObject AftPosition;
    public bool CanLoadACP;
    public static string ParentName;
    public static string PalletsWeight;
    public static string PalletsID;
    public static string PalletsDest;
    public static string Sgl;
    public Material BlueNormal;
    public Material GreenSeeThrough;

    [ES3Serializable]
    public GameObject Weight1;


    [ES3Serializable]
    public GameObject Dest1;


    [ES3Serializable]
    public GameObject ACPID;

    public Vector3 ParentPosition;
    public BoxCollider ACPboxcollider;
    public float BoxScaleX;
    public float BoxScaleY;
    public float BoxScaleZ;
    public float BoxScalenewZ;

    public void Awake()
    {
        Maincanvas = GameObject.Find("MainCanvas");
        Othertransform = null;
        PalletList = new List<GameObject>();
        ACPboxcollider = gameObject.GetComponent<BoxCollider>();
        BoxScaleX = gameObject.GetComponent<BoxCollider>().size.x;
        BoxScaleY = gameObject.GetComponent<BoxCollider>().size.y;
        BoxScaleZ = gameObject.GetComponent<BoxCollider>().size.z;
        BoxScalenewZ = 1;
    }

    private void Start()
    {

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 2.03f, gameObject.transform.position.z);
        ParentPosition = gameObject.transform.position;
        placed = false;
        ADSMat = (Material)Resources.Load("Materials/Empty ADS pos", typeof(Material)); // gets the ADS material
        LogsMat = (Material)Resources.Load("Materials/Empty logs Position", typeof(Material)); // gets the logs material
        HighlightedACP = (Material)Resources.Load("Materials/PalletPosHighlight", typeof(Material)); // gets the highlighted material
        Invisible = (Material)Resources.Load("Materials/invisible", typeof(Material)); // gets the invisible material
        BlueNormal = (Material)Resources.Load("Materials/BlueSeeThrough", typeof(Material));
        GreenSeeThrough = (Material)Resources.Load("Materials/GreenSeeThrough", typeof(Material));
        gameObject.GetComponent<BoxCollider>().enabled = enabled;

    }


    void OnMouseDown()


    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Debug.Log("mousedownMOVEACP");
        gameObject.GetComponent<BoxCollider>().size = new Vector3(BoxScaleX, BoxScaleY, BoxScalenewZ);

    }


    void OnMouseUp()
    {
        dragging = false;
        Debug.Log("mouseupMOVEACP");
    }





    public void OnCollisionEnter(Collision collision)

    {



        PalletList.Add(collision.gameObject);


        col = true;

        if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null)
        {
            collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;
            int a = collision.transform.parent.transform.GetSiblingIndex();
            collision.transform.parent.transform.parent.GetChild(a - 1).transform.GetComponent<Renderer>().material = HighlightedACP;
            collision.transform.parent.transform.parent.GetChild(a + 1).transform.GetComponent<Renderer>().material = HighlightedACP;
            collision.transform.parent.transform.parent.GetChild(a + 2).transform.GetComponent<Renderer>().material = HighlightedACP;

        }

        othertransform = collision; // othertransform is the gameobject( logs or ADS child collider) which the pallet has collided with
        

    }

    public void OnCollisionStay(Collision StayCollision)
    {
        col = true;

        if (StayCollision.transform != null && StayCollision.transform.parent.transform.GetComponent<Renderer>() != null)
        {
            StayCollision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;
            int a = StayCollision.transform.parent.transform.GetSiblingIndex();
            StayCollision.transform.parent.transform.parent.GetChild(a - 1).transform.GetComponent<Renderer>().material = HighlightedACP;
            StayCollision.transform.parent.transform.parent.GetChild(a + 1).transform.GetComponent<Renderer>().material = HighlightedACP;
            StayCollision.transform.parent.transform.parent.GetChild(a + 2).transform.GetComponent<Renderer>().material = HighlightedACP;

        }
        
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
            transform.position = ParentPosition;

        }

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            rayPoint.x = Mathf.Clamp(rayPoint.x, -13.4f, 11.4f);// these 3 lines limit where the pallet can be dragged to
            rayPoint.z = Mathf.Clamp(rayPoint.z, -2.1f, 2.1f);
            rayPoint.y = Mathf.Clamp(rayPoint.y, 2.06f, 2.06f);


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
        if (PalletList.Count == 1)

        {


            Col1 = PalletList[0].gameObject;


            Position = Col1;
            int a = Col1.transform.parent.GetSiblingIndex();
            AftMidPosition = Col1.transform.parent.transform.parent.transform.GetChild(a + 1).transform.GetChild(0).transform.gameObject;
            FwdPosition = Col1.transform.parent.transform.parent.transform.GetChild(a - 1).transform.GetChild(0).transform.gameObject;
            AftPosition = Col1.transform.parent.transform.parent.transform.GetChild(a + 2).transform.GetChild(0).transform.gameObject;



            CanLoadACP = true;

        }

        else
        {

            CanLoadACP = false;

        }


    }



    public void LoadQDPallet()
    {
        Debug.Log("LoadingTplADS");
        gameObject.transform.SetParent(Position.transform); // sets the pallet parent to the collider
        gameObject.GetComponent<ACP_PayloadQD>().OriginalPosition = gameObject.transform.parent.gameObject;
        gameObject.transform.localPosition = new Vector3(0, -3.16f, 2.06f); // sets local position of the pallet to 0
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
        AftMidPosition.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the AFTpallet positions collider
        AftPosition.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the AFTpallet positions collider
        
        Maincanvas.GetComponent<RaycastOff>().TurnOnRaycast(); // this turns the raycast back on now that the pallet is placed
        Position.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the FWD pallet position material to invisible
        FwdPosition.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the AFT pallet position material to invisible
        AftMidPosition.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the AFT pallet position material to invisible
        AftPosition.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the AFT pallet position material to invisible
        
        Position.transform.parent.GetComponent<BoxCollider>().enabled = enabled; // this turns off the 
        FwdPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        AftMidPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        AftPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        
        Position.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        FwdPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        AftMidPosition.transform.parent.GetComponent<BoxCollider>().enabled = enabled;

        GameObject TemporaryChild = new GameObject(); // this is puts a empty gameobject in the aft pallet position of the triple

        TemporaryChild.gameObject.transform.SetParent(AftPosition.transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChild.gameObject.name = "QdAFT(Clone)"; // this matches the names of the double pallet positions so it is clear they are linked

        GameObject TemporaryChildFwd = new GameObject(); // this is puts a empty gameobject in the FWD pallet position of the triple

        TemporaryChildFwd.gameObject.transform.SetParent(FwdPosition.transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChildFwd.gameObject.name = "QdFwd(Clone)"; // this matches the names of the double pallet positions so it is clear they are linked

        GameObject TemporaryChildAftMid = new GameObject(); // this is puts a empty gameobject in the FWD pallet position of the triple

        TemporaryChildAftMid.gameObject.transform.SetParent(AftMidPosition.transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChildAftMid.gameObject.name = "QDAftMid(Clone)"; // this matches the names of the double pallet positions so it is clear they are linked

        
        gameObject.GetComponent<ACP_PayloadQD>().StartPos = gameObject.transform.parent.transform.gameObject;
        GameObject SelectedPanel = GameObject.Find("SelectedPanelQD(Clone)");
        SelectedPanel.GetComponent<MoveQD>().AfterMovedPallet();
        MoveQD.MovedButtonPressed = false;
        int Pos = Position.transform.parent.transform.GetSiblingIndex();
        GameObject Obj = Position.transform.parent.gameObject;
      
        SelectedPanel.gameObject.transform.GetChild(4).gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.name; // this is the MID position
        
        SelectedPanel.gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.GetChild(Pos - 1).transform.name.ToString(); // this is the FWD position

        SelectedPanel.gameObject.transform.GetChild(4).gameObject.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.GetChild(Pos + 1).transform.name.ToString(); // this is the AFT position

        SelectedPanel.gameObject.transform.GetChild(4).gameObject.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = Obj.transform.parent.transform.GetChild(Pos + 2).transform.name.ToString(); // this is the AFT position

        Destroy(this); // destroys this script as it gets in the way of the MOVE and Delete scripts





    }
}
