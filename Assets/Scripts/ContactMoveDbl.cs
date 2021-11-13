using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ContactMoveDbl : MonoBehaviour
{
    public bool Occupied = false;
    public bool col;
    public Collision othertransform;
    private bool dragging;
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    public GameObject OldCollider;
    public Material HighlightedACP;
    public Material ADSMat;
    public Material LogsMat;
    public Material Invisible;
    public GameObject StartingPosition;
    public float TouchCounter;
    public Vector2 TouchPosition;
    public bool UsingMouse;
    public static RaycastHit hit;
    public LayerMask nohit;
    public Vector3 rayPoint;
    public GameObject ParentPosition;
    public BoxCollider ACPboxcollider;
    public float BoxScaleX;
    public float BoxScaleY;
    public float BoxScaleZ;
    public float BoxScalenewZ;
    public Vector3 PreviousPosition;
    public GameObject PreviousPallet;
    public bool PalletMoved;
    public bool NewlyOccupied;
    public GameObject PreviousACPposition;
    public GameObject CurrentACPposition;
    public GameObject StartingPalletPlace;
    public TextMeshProUGUI PositionText;
    public GameObject SelectedPanel;
    public GameObject TheSelectedPanel;
    public Material BlueNormal;
    public Material GreenSeeThrough;
    public GameObject Col1;
    public GameObject Col2;
    public List<GameObject> PalletList;
    public float first;
    public float second;
    public GameObject FwdPosition;
    public GameObject AftPosition;
    public bool CanLoadACP;
    public GameObject OriginPos;
    public GameObject FWDpos;
    public GameObject AFTpos;
    public bool FWDexit;
    public bool AFTexit;
    public int Index2;
    public int Index3;
    public int CollisionParentIndex;
    public GameObject CollisionParentFWD;
    public GameObject CollisionParentAFT;
    public GameObject OriginalPosAFT;
    public GameObject OriginalPosFWD;
    public GameObject OriginalPosAFT2;
    public int Index6;
    public bool CanAddTheACP;
    public GameObject InCol;
    public GameObject OutCol;
    public int thisIndex;
    public GameObject COLL;
    public bool MovingLeft;
    public bool MovingRight;
    public float Vecta;
    public float Vectb;
    public bool PalletOccupied;
    public GameObject ThePallet;
    public GameObject ThePalletOriginalPosition;
    public GameObject OriginalPosition;
    public Vector3 ReturnPosition;
    public int LoadedNumbers;
    public GameObject TempAftPos;
    public GameObject TempFwdPos;
    public bool CanRun;



    private void Awake()
    {
        CanRun = false;
        ParentPosition = MoveDBL.ParentPosition; // this is the parent position e.g ADS 2
        OriginalPosition = ParentPosition;
        Index3 = ParentPosition.transform.GetSiblingIndex();
        OriginalPosAFT = ParentPosition.transform.parent.transform.GetChild(Index3 + 1).transform.gameObject;
        OriginalPosAFT2 = ParentPosition.transform.parent.transform.GetChild(Index3 + 1).transform.gameObject;
        //OriginalPosAFT.transform.GetChild(0).transform.GetChild(0).transform.name = "OriginalPosAFT";
        Debug.Log("WORK" + OriginalPosAFT.transform.name);
        OriginalPosFWD = ParentPosition.transform.parent.transform.GetChild(Index3 - 1).transform.gameObject;
       
        StartingPosition = ParentPosition.transform.GetChild(0).transform.gameObject;
        ReturnPosition = gameObject.transform.position;
        ACPboxcollider = gameObject.GetComponent<BoxCollider>();
        BoxScalenewZ = 0.01f;
        NewlyOccupied = false;
        SelectedPanel = GameObject.Find("SelectedPanelDBL(Clone)");
        BoxScaleX = gameObject.GetComponent<BoxCollider>().size.x;
        BoxScaleY = gameObject.GetComponent<BoxCollider>().size.y;
        BoxScaleZ = gameObject.GetComponent<BoxCollider>().size.z;
        TheSelectedPanel = SelectedPanel;
        PalletList = new List<GameObject>();
        Debug.Log("The starting palletlist count ==" + PalletList.Count);
        Debug.Log("PARENT POS = " + ParentPosition.name);
        FWDpos = new GameObject();
        AFTpos = new GameObject();
        Vecta = Input.mousePosition.x;




    }

    private void Start()
    {


        ADSMat = (Material)Resources.Load("Materials/Empty ADS pos", typeof(Material)); // gets the ADS material
        LogsMat = (Material)Resources.Load("Materials/Empty logs Position", typeof(Material)); // gets the logs material
        HighlightedACP = (Material)Resources.Load("Materials/PalletPosHighlight", typeof(Material)); // gets the highlighted material
        Invisible = (Material)Resources.Load("Materials/invisible", typeof(Material)); // gets the invisible material
        BlueNormal = (Material)Resources.Load("Materials/BlueSeeThrough", typeof(Material));
        GreenSeeThrough = (Material)Resources.Load("Materials/GreenSeeThrough", typeof(Material));
        Occupied = false;

        ParentPosition.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = enabled;
        OriginalPosAFT.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = enabled;
        gameObject.GetComponent<BoxCollider>().enabled = enabled;
        
    }

    public void OnCollisionEnter(Collision collision)

    {
        if (gameObject.name.Contains("ADS"))
        {



            PalletList.Add(collision.gameObject);
            InCol = collision.collider.transform.gameObject;


            col = true;

            if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null)
            {
                collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;

            }

            IsItAdDBLPalletCheck();
        }

        if (gameObject.name.Contains("LOG"))
        {



            PalletList.Add(collision.gameObject);
            InCol = collision.collider.transform.gameObject;
            int a = InCol.transform.parent.GetSiblingIndex();
            PalletList.Add(InCol.transform.parent.transform.parent.GetChild(a + 1).transform.gameObject.transform.GetChild(0).transform.gameObject);


            col = true;

            if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null)
            {
                collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;

            }

            IsItAdDBLPalletCheck();
        }



    }

    private void OnCollisionStay(Collision collision)
    {
       
        
        if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null)
        {
            collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;

        }


    }

    public void OnCollisionExit(Collision outcollision)

    {
        OutCol = outcollision.collider.transform.gameObject;

        if (gameObject.name.Contains("LOG"))

        {
           
            InCol = outcollision.collider.transform.gameObject;
            int a = InCol.transform.parent.GetSiblingIndex();
            PalletList.Remove(InCol.transform.parent.transform.parent.GetChild(a + 1).transform.gameObject.transform.GetChild(0).transform.gameObject);
            
        }

        if ((outcollision.transform.parent.name.Contains("ADS")))
        {
            outcollision.transform.parent.GetComponent<Renderer>().material = ADSMat; // returns the material of the collided object back to its original
            
        }

        else if (outcollision.transform.parent.name.Contains("log"))
        {
            outcollision.transform.parent.GetComponent<Renderer>().material = LogsMat; // returns the material of the collided object back to its original
        }

        PalletList.Remove(outcollision.gameObject);
        DidApalletMove();
    }






    public void OnMouseUp()

    {



        SelectedPanel = GameObject.Find("SelectedPanelDBL(Clone)");
        gameObject.GetComponent<BoxCollider>().size = new Vector3(BoxScaleX, BoxScaleY, BoxScaleZ); // this returns the collider back to a smaller size

        dragging = false;
        CheckPalletPositions();

        if (CanLoadACP)

        {
            Debug.Log("CAN ACTUALLY LOAD");



            if ((FwdPosition.transform.name.Contains("col")) && (col = true))// this checks whether the pallet has collided with the correct collider called 'col'; checks whether the collision is actually true; checks there is not another pallet on it already (placed == false)
            {
                LoadADSPalletDBL();


            }

            else
            {

                Debug.Log("Maybe I cannot LOAD");
            }

        }

        else
        {
            dragging = false;
            Debug.Log("The mouse is up");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.position = ReturnPosition;
           
        }





    }

    private void OnMouseDown()
    {
        dragging = true;
        gameObject.GetComponent<BoxCollider>().size = new Vector3(BoxScaleX, BoxScaleY, BoxScalenewZ);


    }



    public void LoadedCheck()
    {
        Debug.Log("LoadedCheck");
        LoadedNumbers = ParentPosition.transform.GetChild(0).transform.childCount;

        if (LoadedNumbers == 1)
        {
            if (ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.name == "ADSdouble(Clone)")

            {
                Debug.Log("Loaded Check Begin");
                GameObject MovingPallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                int Index20 = ParentPosition.transform.GetSiblingIndex();
                TempAftPos = MovingPallet.transform.parent.transform.parent.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACP_PayloadDBL>().StartPos.transform);
                MovingPallet.transform.localPosition = new Vector3(0, -3.14f, 0.001f);
                MovingPallet.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                int Index21 = MovingPallet.transform.parent.transform.parent.GetSiblingIndex();
                TempAftPos.transform.SetParent(MovingPallet.transform.parent.transform.parent.transform.parent.transform.GetChild(Index21 + 1).transform.GetChild(0).transform);
                TempAftPos.transform.parent.transform.parent.transform.GetComponent<Renderer>().material = Invisible;
                Debug.Log("qwerty" + TempAftPos.transform.parent.transform.gameObject);

                if (MovingPallet.transform.parent.childCount > 1)
                {
                    MovingPallet.transform.SetAsFirstSibling();
                    MovingPallet.transform.parent.transform.GetChild(1).transform.SetParent(null);

                }
                if (TempAftPos.transform.parent.childCount > 1)
                {

                    TempAftPos.transform.SetAsFirstSibling();
                    TempAftPos.transform.parent.transform.GetChild(1).transform.SetParent(null);
                }


                Debug.Log("Loaded Check End");
                PalletOccupied = false;
                return;
            }

            if (ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.name == "ACP(Clone)")


            {
                Debug.Log("MOSES");
                CheckIfSingleOccupied();
                
                return;
            }
        }

        else if (LoadedNumbers == 0)
        {

            Debug.Log("EMPTY");
            CheckIfSingleOccupied();
            LoadSingleACP();


            return;
           
        }

    }

    public void LoadedCheck2()
    {
        Debug.Log("LoadedCheck2");
        LoadedNumbers = ParentPosition.transform.GetChild(0).transform.childCount;

        if (LoadedNumbers == 1)
        {
            if (ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.name == "ADSdouble(Clone)")

            {
                Debug.Log("Loaded Check Begin");
                int Index20 = ParentPosition.transform.GetSiblingIndex();
                GameObject MovingPallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
               
                GameObject TempAFTPos = ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;

                if (MovingPallet.transform.name == "ADSdouble(Clone)")
                {

                    MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACP_PayloadDBL>().StartPos.transform);
                    MovingPallet.transform.localPosition = new Vector3(0, -3.14f, 0.001f);
                }

                else if (MovingPallet.transform.name == "ACP(Clone)")
                {

                    MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACPpayload>().StartPos.transform);
                    MovingPallet.transform.localPosition = new Vector3(0, 0, 2.27f);

                }



               
                MovingPallet.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                int Index21 = MovingPallet.transform.parent.transform.parent.GetSiblingIndex();
                Debug.Log("TEMPAFTIS.........", TempAFTPos);
                TempAFTPos.transform.SetParent(MovingPallet.transform.parent.transform.parent.transform.parent.transform.GetChild(Index21 + 1).transform.GetChild(0).transform);
                TempAFTPos.transform.parent.transform.parent.transform.GetComponent<Renderer>().material = Invisible;
                

                if (MovingPallet.transform.parent.childCount > 1)
                {
                    MovingPallet.transform.SetAsFirstSibling();
                    MovingPallet.transform.parent.transform.GetChild(1).transform.SetParent(null);

                }
                if (TempAFTPos.transform.parent.childCount > 1)
                {

                    TempAFTPos.transform.SetAsFirstSibling();
                    TempAFTPos.transform.parent.transform.GetChild(1).transform.SetParent(null);
                }


                Debug.Log("Loaded Check End");
                PalletOccupied = false;
                return;
            }

            if (ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.name == "ACP(Clone)")


            {
                Debug.Log("MOSES");
                CheckIfSingleOccupied2();
                MoveSingleACP();
                return;

            }
        }

        else
        {

            Debug.Log("EMPTY2");
            CheckIfSingleOccupied2();
            LoadSingleACP2();
            return;

        }

    }

    public void MoveSingleACP() // this actions the loading of the pallet 
    {
        int result = CheckIfSingleOccupied();


        switch (result)
        {
            case 1:
                print("FWD Position is occupied"); // We only need to empty the first position as the aft is already unloaded
                GameObject MovingPallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                int Index29 = ParentPosition.transform.GetSiblingIndex();
                MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACPpayload>().StartPos.transform);
                MovingPallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                MovingPallet.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                MovingPallet.transform.SetAsFirstSibling();
                MovingPallet.transform.parent.GetChild(1).transform.SetParent(null);
                break;

            case 5:
                print("Aft position is occupied"); // we need to empty both positions
                GameObject MovingPallet1 = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                int Index290 = ParentPosition.transform.GetSiblingIndex();
                MovingPallet1.transform.SetParent(MovingPallet1.GetComponent<ACPpayload>().StartPos.transform);
                MovingPallet1.transform.localPosition = new Vector3(0, 0, 2.27f);
                MovingPallet1.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                MovingPallet1.transform.SetAsFirstSibling();
                MovingPallet1.transform.parent.GetChild(1).transform.SetParent(null);
              

                GameObject MovingPallet2 = ParentPosition.transform.parent.GetChild(Index290 + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                Debug.Log("WERT", MovingPallet2);

                if (MovingPallet2.transform.name == "ADSdoubleAFT")
                {
                    MovingPallet2.transform.SetParent(null);
                   

                }

                if (MovingPallet2.transform.name == "ACP(Clone)")
                {
                    MovingPallet2.transform.SetParent(MovingPallet2.GetComponent<ACPpayload>().StartPos.transform);
                    MovingPallet2.transform.localPosition = new Vector3(0, 0, 2.27f);

                }

                
              
                MovingPallet2.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                MovingPallet2.transform.SetAsFirstSibling();
               // MovingPallet2.transform.parent.GetChild(1).transform.SetParent(null);
                break;


            case 3:
                print("both are empty");
                break;

            default:
                print("Incorrect intelligence level.");
                break;
        }

    }




    public int CheckIfSingleOccupied() // this checks the parent positions occupied state
    {
        Debug.Log("SINGLECHECK");
        int ParentChildCount = ParentPosition.transform.GetChild(0).transform.childCount;
        int Index20 = ParentPosition.transform.GetSiblingIndex();
        int AftPosChildCount = ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform.childCount;

        Debug.Log("ParentChildCount...." + ParentChildCount);
        Debug.Log("AftPosChildCount...." + ParentChildCount);

        if ((ParentChildCount == 0) && (AftPosChildCount == 0)) // so they are both empty

        {

            Debug.Log("LOADING00");
            return 9;


        }

        if ((ParentChildCount == 1) && (AftPosChildCount == 0)) // so only the front pallet is occupied

        {

            Debug.Log("LOADING10");
            return 1; 


        }


        if ((ParentChildCount == 1) && (AftPosChildCount == 1)) // so they are both occupied


        {


            Debug.Log("POP", ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform);
            return 5; // so 2 means both pallet positions need to be emptied

        }

            

        else
        {

            Debug.Log("EMPTY");
            return 9;
        }

       

    }

    public int CheckIfSingleOccupied2() // this checks the parent positions occupied state
    {
        Debug.Log("SINGLECHECK2");
        int ParentChildCount = ParentPosition.transform.GetChild(0).transform.childCount;
        int Index20 = ParentPosition.transform.GetSiblingIndex();
        int AftPosChildCount = ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform.childCount;

        if ((ParentChildCount == 0) && (AftPosChildCount == 0)) // so both empty

        {


            return 1;


        }

        if ((ParentChildCount == 0) && (AftPosChildCount == 1)) // so only the front pallet is occupied

        {


            return 9;


        }


        if ((ParentChildCount == 1) && (AftPosChildCount == 1)) // so they are both occupied


        {


            Debug.Log("POP", ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform);
            return 1; // so 2 means both pallet positions need to be emptied

        }



        else
        {

            Debug.Log("EMPTY");
            return 0;
        }



    }






    public void LoadSingleACP() // this actions the loading of the pallet 
    {
        int result = CheckIfSingleOccupied();


        switch (result)
        {
            case 9:
                print("Loading in the FWD Position");
                OriginPos = InCol.transform.gameObject;
                ThePallet = InCol.transform.GetChild(0).transform.gameObject;
                GameObject TempSgl = new GameObject();
                TempSgl.transform.SetParent(ThePallet.transform.parent);
                TempSgl.transform.SetAsLastSibling();
                TempSgl.transform.name = "TempSgl1";
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                PalletMoved = true; // this identifys that a pallet has been temporarily moved from its orignal position to now occupy the selectedACP position
                PreviousPallet = ThePallet;
                ThePallet.transform.SetParent(ParentPosition.transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
                ThePallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                ParentPosition.GetComponent<Renderer>().material = Invisible;
                StartingPosition = ThePallet.transform.parent.transform.gameObject;
                StartingPosition.transform.parent.transform.GetComponent<Renderer>().material = ADSMat;
                PalletOccupied = true;
                CanRun = true;
                break;



            case 1:
                print("Loading in the AFT position");
                int Index20 = ParentPosition.transform.GetSiblingIndex();
                ThePallet = InCol.transform.GetChild(0).transform.gameObject;
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                GameObject TempSgl1 = new GameObject();
                TempSgl1.transform.SetParent(ThePalletOriginalPosition.transform);
                TempSgl1.transform.SetAsLastSibling();
                TempSgl1.transform.name = "TempSgl2";
                Debug.Log("TempSgl2", TempSgl1);
                PalletMoved = true; // this identifys that a pallet has been temporarily moved from its orignal position to now occupy the selectedACP position
                PreviousPallet = ThePallet;
                ThePallet.transform.SetParent(ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
                ThePallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                PalletOccupied = true;
                CanRun = true;
                break;




            case 5:
                print("Unloading the fwd pos"); // as both acp positions are occupied we will return the fwd pallet back to its original location and then use the fwd position for the new pallet
                GameObject MovingPallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                int Index29 = ParentPosition.transform.GetSiblingIndex();
                
                MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACPpayload>().StartPos.transform);
                MovingPallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                MovingPallet.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                MovingPallet.transform.SetAsFirstSibling();
                MovingPallet.transform.parent.GetChild(1).transform.SetParent(null);

                print("Unloading the 2nd pos"); // as both acp positions are occupied we will return the fwd pallet back to its original location and then use the fwd position for the new pallet
                GameObject MovingPallet2 = MovingPallet.transform.parent.transform.parent.transform.parent.transform.GetChild(Index29 + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                MovingPallet2.transform.SetParent(MovingPallet2.GetComponent<ACPpayload>().StartPos.transform);
                MovingPallet2.transform.localPosition = new Vector3(0, 0, 2.27f);
                MovingPallet2.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                MovingPallet2.transform.SetAsFirstSibling();
                MovingPallet2.transform.parent.GetChild(1).transform.SetParent(null);

                print("Loading in the FWD Position");
                OriginPos = InCol.transform.gameObject;
                ThePallet = InCol.transform.GetChild(0).transform.gameObject;
                GameObject TempSgl2 = new GameObject();
                TempSgl2.transform.SetParent(ThePallet.transform.parent);
                TempSgl2.transform.SetAsLastSibling();
                TempSgl2.transform.name = "TempSglFwd";
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                PalletMoved = true; // this identifys that a pallet has been temporarily moved from its orignal position to now occupy the selectedACP position
                PreviousPallet = ThePallet;
                ThePallet.transform.SetParent(ParentPosition.transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
                ThePallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                ParentPosition.GetComponent<Renderer>().material = Invisible;
                StartingPosition = ThePallet.transform.parent.transform.gameObject;
                StartingPosition.transform.parent.transform.GetComponent<Renderer>().material = ADSMat;
                PalletOccupied = true;
                CanRun = true;
                break;

            case 4:
                print("Grog SMASH!");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    public void LoadSingleACP2() // this actions the loading of the pallet 
    {
        int result = CheckIfSingleOccupied2();


        switch (result)
        {
            case 9:
                print("Loading in the FWD Position");
                OriginPos = InCol.transform.gameObject;
                ThePallet = InCol.transform.GetChild(0).transform.gameObject;
                GameObject TempSgl = new GameObject();
                TempSgl.transform.SetParent(ThePallet.transform.parent);
                TempSgl.transform.SetAsLastSibling();
                TempSgl.transform.name = "TempSgl1";
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                PalletMoved = true; // this identifys that a pallet has been temporarily moved from its orignal position to now occupy the selectedACP position
                PreviousPallet = ThePallet;
                ThePallet.transform.SetParent(ParentPosition.transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
                ThePallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                ParentPosition.GetComponent<Renderer>().material = Invisible;
                StartingPosition = ThePallet.transform.parent.transform.gameObject;
                StartingPosition.transform.parent.transform.GetComponent<Renderer>().material = ADSMat;
                PalletOccupied = true;
                CanRun = true;
                break;



            case 1:
                print("Loading in the AFT position");
               
                int Index200 = ParentPosition.transform.GetSiblingIndex();
              
                ThePallet = InCol.transform.GetChild(0).transform.gameObject;
                GameObject TempSgl1 = new GameObject();
                TempSgl1.transform.SetParent(ThePallet.transform.parent.transform);
                TempSgl1.transform.SetAsLastSibling();
                TempSgl1.transform.name = "TempSgl2";
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                ThePallet.transform.SetParent(ParentPosition.transform.parent.transform.GetChild(Index200 + 1).transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
           
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                PalletMoved = true; // this identifys that a pallet has been temporarily moved from its orignal position to now occupy the selectedACP position
                PreviousPallet = ThePallet;
                
                ThePallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                PalletOccupied = true;
                CanRun = true;
                break;




            case 5:
                print("Unloading the fwd pos"); // as both acp positions are occupied we will return the fwd pallet back to its original location and then use the fwd position for the new pallet
                GameObject MovingPallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                int Index29 = ParentPosition.transform.GetSiblingIndex();
                GameObject MovingPallet2 = MovingPallet.transform.parent.transform.parent.transform.parent.transform.GetChild(Index29 + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACPpayload>().StartPos.transform);
                MovingPallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                MovingPallet.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                MovingPallet.transform.SetAsFirstSibling();
                MovingPallet.transform.parent.GetChild(1).transform.SetParent(null);

                print("Unloading the 2nd pos"); // as both acp positions are occupied we will return the fwd pallet back to its original location and then use the fwd position for the new pallet

                MovingPallet2.transform.SetParent(MovingPallet2.GetComponent<ACPpayload>().StartPos.transform);
                MovingPallet2.transform.localPosition = new Vector3(0, 0, 2.27f);
                MovingPallet2.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
                MovingPallet2.transform.SetAsFirstSibling();
                MovingPallet2.transform.parent.GetChild(1).transform.SetParent(null);

                print("Loading in the FWD Position");
                OriginPos = InCol.transform.gameObject;
                ThePallet = InCol.transform.GetChild(0).transform.gameObject;
                GameObject TempSgl2 = new GameObject();
                TempSgl2.transform.SetParent(ThePallet.transform.parent);
                TempSgl2.transform.SetAsLastSibling();
                TempSgl2.transform.name = "TempSglFwd";
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                PalletMoved = true; // this identifys that a pallet has been temporarily moved from its orignal position to now occupy the selectedACP position
                PreviousPallet = ThePallet;
                ThePallet.transform.SetParent(ParentPosition.transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
                ThePallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                ParentPosition.GetComponent<Renderer>().material = Invisible;
                StartingPosition = ThePallet.transform.parent.transform.gameObject;
                StartingPosition.transform.parent.transform.GetComponent<Renderer>().material = ADSMat;
                PalletOccupied = true;
                CanRun = true;
                break;

            case 4:
                print("Grog SMASH!");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }




    public void FixedUpdate()
    {



        if (Input.GetAxis("Mouse X") < 0)
        {
            MovingLeft = true;
            MovingRight = false;
            Debug.Log("LEFT LEFT LEFT LEFT");

        }


        else if (Input.GetAxis("Mouse X") > 0)

        {
            MovingLeft = false;
            MovingRight = true;
            Debug.Log("RIGHT RIGHT RIGHT ");

        }




        if (Input.touchCount > 0)

        {

            TouchCounter = Input.touchCount;

            if (Input.touchCount > 0)

            {
                Ray ray = Camera.main.ScreenPointToRay(TouchPosition);
                Physics.Raycast(ray, out hit, Mathf.Infinity, ~nohit);
                distance = Vector3.Distance(transform.position, TouchPosition);
                rayPoint = ray.GetPoint(distance);

                if (hit.collider.transform == gameObject)
                {


                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        UsingMouse = false;
                        TouchPosition = Input.GetTouch(0).position;
                        distance = Vector3.Distance(transform.position, TouchPosition);
                        dragging = true;
                        ParentPosition.transform.GetComponent<BoxCollider>().enabled = !enabled;

                    }
                }

            }








        }

        if (dragging)



        {
            Debug.Log("Using the Mouse ContactMove");
            UsingMouse = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, Mathf.Infinity, ~nohit);
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            rayPoint = ray.GetPoint(distance);
            dragging = true;
            rayPoint.x = Mathf.Clamp(rayPoint.x, -13.4f, 11.4f);

            if (gameObject.name.Contains("ADS"))

            {
                rayPoint.y = Mathf.Clamp(rayPoint.y, 0.2f, 0.2f);
                rayPoint.z = Mathf.Clamp(rayPoint.z, 0, 0);
            }

            if (gameObject.name.Contains("LOGS"))

            {
                rayPoint.y = Mathf.Clamp(rayPoint.y, 1.5F, 1.5f);
                rayPoint.z = Mathf.Clamp(rayPoint.z, -1f, 2);
            }


            transform.position = rayPoint;





            Debug.Log("dragging");
            ParentPosition.transform.GetComponent<BoxCollider>().enabled = !enabled;
            int Index = ParentPosition.transform.GetSiblingIndex();
            GameObject ParentPositionAFT = ParentPosition.transform.parent.GetChild(Index + 1).transform.gameObject;
            ParentPositionAFT.transform.GetComponent<BoxCollider>().enabled = !enabled;


        }




        else
        {
            if (col == false)

            {

                dragging = false;
                Debug.Log("The mouse is up");
                gameObject.transform.position = ReturnPosition;

            }


        }


        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            CheckPalletPositions();

           
        }



    }


    public void LoadADSPalletDBL()

    {
        TheSelectedPanel.gameObject.transform.GetChild(3).transform.GetChild(5).gameObject.GetComponent<Button>().enabled = enabled;
        TheSelectedPanel.gameObject.transform.GetChild(3).transform.GetChild(6).transform.gameObject.GetComponent<Button>().enabled = enabled;

        Debug.Log("Contactmove script beginning");
        //Debug.Log("MOVEACP Pallet is ... " + MoveDBL.ParentPosition.transform.name);
        NewlyOccupied = true;

        gameObject.transform.SetParent(FwdPosition.transform); // sets the pallet parent to the collider
        gameObject.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = !enabled;

        if (gameObject.name.Contains("ADS"))

        {
            gameObject.transform.localEulerAngles = new Vector3(0, 0, -180); // sets rotation
            gameObject.transform.localPosition = new Vector3(0, -3.14f, 0.001f);// sets the position to higher than the mainfloor

        }
       
        else if (gameObject.name.Contains("LOG"))

        {
            gameObject.transform.localPosition = new Vector3(0, 0, 2.07f);// sets the position to higher than the mainfloor



        }
        FwdPosition.transform.parent.transform.GetComponent<Renderer>().material = Invisible;
        AftPosition.transform.parent.transform.GetComponent<Renderer>().material = Invisible;
        int Index = FwdPosition.transform.parent.transform.GetSiblingIndex();
        GameObject CurrentACPpositionAFT = FwdPosition.transform.parent.transform.parent.GetChild(Index + 1).gameObject; // this creates the aft act position
        CurrentACPpositionAFT.transform.GetComponent<Renderer>().material = Invisible; // this sets the aft ACP position colour
        FwdPosition.transform.parent.transform.GetComponent<BoxCollider>().enabled = enabled;
        GameObject TemporaryChild = new GameObject();
        TemporaryChild.gameObject.transform.SetParent(CurrentACPpositionAFT.transform.GetChild(0).transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChild.gameObject.name = gameObject.name; // this matches the names of the double pallet positions so it is clear they are linked
        thisBody = gameObject.GetComponent<Rigidbody>();
        thisBody.isKinematic = true; // pallet rigidbody turned on
        FwdPosition.transform.GetComponent<BoxCollider>().enabled = !enabled; // this pallets box collider turned off
        GameObject.Find("MainCanvas").GetComponent<RaycastOff>().TurnOnRaycast(); // turns the raycast script back on
        Raycast.pause = false;
        Occupied = true;
        MoveDBL.ParentPosition.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;
        MoveDBL.ParentPosition.transform.GetComponent<BoxCollider>().enabled = !enabled;
        MoveDBL.ParentPosition = FwdPosition.transform.parent.gameObject;
        MoveDBL.MovedButtonPressed = false;

        GameObject SelectedPanel = GameObject.Find("SelectedPanelDBL(Clone)");
        SelectedPanel.GetComponent<MoveDBL>().AfterMovedPallet();

        Debug.Log("ContactMoveDBL Complete");

        foreach (GameObject i in PalletArray.Palletarray)
        {
            i.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled = enabled; // this is the pallet position eg ADS1
            i.transform.parent.GetComponent<BoxCollider>().enabled = !enabled; // this enables the 'collider' gameobject


        }




        gameObject.GetComponent<ACP_PayloadDBL>().OriginalPosition = FwdPosition;
        //MoveACP.CloseBtn.GetComponent<UnityEngine.UI.Button>().interactable = true; // re-enbles the close button on the selected Panel.
        MoveDBL.AlreadyInUse = false;
        Destroy(this); // destroys this script









    }

    void CheckPalletPositions()
    {
        Debug.Log("PALLET COUNT ==" + PalletList.Count);

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
                Debug.Log("FWD =" + Col1.transform.parent.name);
                Debug.Log("AFT =" + Col2.transform.parent.name);

            }

            else if (second < first)

            {

                FwdPosition = Col2;
                AftPosition = Col1;
                Debug.Log("FWD = " + Col2.transform.parent.name);
                Debug.Log("AFT =" + Col1.transform.parent.name);
            }

            CanLoadACP = true;

        }

        else
        {

            CanLoadACP = false;

        }


    }





    public void IsItAdDBLPalletCheck()
    {

        if (InCol.transform.childCount >= 1)

        {
            Debug.Log("UTOPIA ====" + InCol.transform.parent.name);

            if (InCol.transform.parent.transform.gameObject == ParentPosition || InCol.transform.parent.transform.gameObject == OriginalPosAFT)
            {
                Debug.Log("NOT HERE", ParentPosition);
                Debug.Log("NOT HEREQ", OriginalPosAFT);
                return; // this ignores pallets loaded into the parent positions
            }



            if ((InCol.transform.GetChild(0).transform.gameObject.name == "ADSdouble(Clone)") && (MovingRight == true))// so we have hit a double pallet
            {

                CanRun = false;
                Debug.Log("Starting number 1");
                // LoadedCheck();
                if (ParentPosition.transform.GetChild(0).transform.childCount == 1) // unload the fwd pallet

                {
                    if (ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject.name == "ACP(Clone)")
                    {

                        ThePallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                        ThePallet.transform.SetParent(ThePallet.GetComponent<ACPpayload>().StartPos.transform);
                        ThePallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                        Destroy(ThePallet = ThePallet.GetComponent<ACPpayload>().StartPos.transform.GetChild(0).transform.gameObject);

                        Debug.Log("moved the fwd single pallet");

                    }

                    else if (ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject.name == "ADSdouble(Clone)")

                    {
                        ThePallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                        ThePallet.transform.SetParent(ThePallet.GetComponent<ACP_PayloadDBL>().StartPos.transform);
                        ThePallet.transform.localPosition = new Vector3(0, -3.14f, 0.001f);

                        Debug.Log("moved the fwd dbl pallet");
                    }
                }

                if (OriginalPosAFT.transform.GetChild(0).transform.childCount == 1) // unload the aft pallet
                {
                    if (OriginalPosAFT.transform.GetChild(0).transform.GetChild(0).transform.gameObject.name == "ADSdoubleAFT(Clone)")
                    {

                        Destroy(OriginalPosAFT.transform.GetChild(0).transform.GetChild(0).transform.gameObject);

                    }

                    else if (OriginalPosAFT.transform.GetChild(0).transform.GetChild(0).transform.gameObject.name == "ACP(Clone)")

                    {
                        ThePallet = OriginalPosAFT.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
                        ThePallet.transform.SetParent(ThePallet.GetComponent<ACPpayload>().StartPos.transform);
                        ThePallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                        Destroy(ThePallet = ThePallet.GetComponent<ACPpayload>().StartPos.transform.GetChild(0).transform.gameObject);
                        Debug.Log("moved the aft single pallet");
                    }



                }


                OriginPos = InCol.transform.gameObject;
                ThePallet = InCol.transform.GetChild(0).transform.gameObject;
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                PalletMoved = true; // this identifys that a pallet has been temporarily moved from its orignal position to now occupy the selectedACP position
                PreviousPallet = ThePallet;
                int Index1 = ThePalletOriginalPosition.transform.parent.transform.GetSiblingIndex();
                StartingPosition = ThePallet.transform.parent.transform.gameObject;
                StartingPosition.transform.parent.transform.GetComponent<Renderer>().material = ADSMat;
                ThePallet.transform.SetParent(ParentPosition.transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
                ParentPosition.GetComponent<Renderer>().material = Invisible;
                int Index20 = ParentPosition.transform.GetSiblingIndex();
                GameObject TempAftPos = new GameObject();
                TempAftPos.transform.SetParent(ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform);
                GameObject Gam = ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.gameObject;
                Gam.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = enabled;
                Debug.Log(Gam.name + "You2");
                Debug.Log("THISS", ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform);
                TempAftPos.name = "ADSdoubleAFT(Clone)";
                OriginalPosAFT2 = ThePalletOriginalPosition.transform.parent.transform.parent.GetChild(Index1 + 1).transform.gameObject;
                OriginalPosAFT2.transform.GetComponent<Renderer>().material = Invisible;
                Debug.Log("This one", OriginalPosAFT);
                PreviousPallet.transform.localPosition = new Vector3(0, -3.14f, 0.001f);
                FWDpos.transform.SetParent(ThePalletOriginalPosition.transform);
                AFTpos.transform.SetParent(ThePalletOriginalPosition.transform.parent.parent.transform.GetChild(Index1 + 1).transform.GetChild(0).transform);
                FWDpos.name = "FWDPOS";
                AFTpos.name = "AFTPOS";
                AFTpos.transform.parent.transform.parent.transform.GetComponent<Renderer>().material = ADSMat;
                AFTpos.transform.SetAsFirstSibling();
                FWDpos.transform.SetAsFirstSibling();
                Destroy(OriginalPosAFT2.transform.GetChild(0).transform.GetChild(1).transform.gameObject);
                Debug.Log("FINISHED INCOL SCRIPT");
                Gam.GetComponent<Renderer>().material = Invisible;
                PalletOccupied = true;
                CanRun = true;


            }

            if ((InCol.transform.GetChild(0).transform.gameObject.name == "ADSdoubleAFT(Clone)") && (MovingLeft == true))// so we have hit a double pallet

            {
                CanRun = false;
                Debug.Log("Starting number 2");
                LoadedCheck2();
                int Index22 = InCol.transform.parent.transform.GetSiblingIndex();
                OriginPos = InCol.transform.parent.transform.parent.transform.GetChild(Index22 - 1).transform.GetChild(0).transform.gameObject;
                OriginPos.transform.parent.transform.GetComponent<Renderer>().material = ADSMat;
                ThePallet = OriginPos.transform.GetChild(0).transform.gameObject;
                ThePalletOriginalPosition = ThePallet.transform.parent.transform.gameObject;
                PalletMoved = true; // this identifys that a pallet has been temporarily moved from its orignal position to now occupy the selectedACP position
                PreviousPallet = ThePallet;
                int Index1 = ThePalletOriginalPosition.transform.parent.transform.GetSiblingIndex();
                StartingPosition = ThePallet.transform.parent.transform.gameObject;
                ThePallet.transform.SetParent(ParentPosition.transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
                ParentPosition.GetComponent<Renderer>().material = Invisible;
                int Index20 = ParentPosition.transform.GetSiblingIndex();
                GameObject TempAftPos = new GameObject();
                TempAftPos.transform.SetParent(ParentPosition.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform);
                TempAftPos.transform.parent.transform.parent.transform.GetComponent<Renderer>().material = Invisible;
                TempAftPos.name = "ADSdoubleAFT(Clone)";
                OriginalPosAFT2 = ThePalletOriginalPosition.transform.parent.transform.parent.GetChild(Index1 + 1).transform.gameObject;
                OriginalPosAFT2.transform.GetComponent<Renderer>().material = ADSMat;
                PreviousPallet.transform.localPosition = new Vector3(0, -3.14f, 0.001f);
                FWDpos.transform.SetParent(ThePalletOriginalPosition.transform);
                AFTpos.transform.SetParent(ThePalletOriginalPosition.transform.parent.parent.transform.GetChild(Index1 + 1).transform.GetChild(0).transform);
                FWDpos.name = "FWDPOS";
                AFTpos.name = "AFTPOS";
                AFTpos.transform.SetAsFirstSibling();
                FWDpos.transform.SetAsFirstSibling();
                Destroy(OriginalPosAFT2.transform.GetChild(0).transform.GetChild(1).transform.gameObject);
                Debug.Log("FINISHED INCOL SCRIPT");
                PalletOccupied = true;
                CanRun = true;





            }

            if ((InCol.transform.GetChild(0).transform.gameObject.name == "ACP(Clone)") && (MovingRight == true))// so we have hit a single pallet

            {
                Debug.Log("Its a single pallet");
                LoadedCheck();
                return;
            }

            if ((InCol.transform.GetChild(0).transform.gameObject.name == "ACP(Clone)") && (MovingLeft == true))// so we have hit a single pallet

            {
                Debug.Log("Its a single pallet");
                LoadedCheck2();
                return;

            }

        }

        else
        {

            Debug.Log("SOSW");
        }


    }

    public void ReturnDblPallet()
    {

        PalletOccupied = false;
        Debug.Log("Return Pallet Begin dbl");
        GameObject MovingPallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        ParentPosition.GetComponent<Renderer>().material = ADSMat;
        int Index20 = ParentPosition.transform.GetSiblingIndex();
        MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACP_PayloadDBL>().StartPos.transform);
        MovingPallet.transform.localPosition = new Vector3(0, -3.14f, 0.001f);
        Debug.Log("MOVE DBL COMPLETE", MovingPallet);
        MovingPallet.transform.parent.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;
        int Index21 = MovingPallet.transform.parent.transform.parent.GetSiblingIndex();
        TempAftPos = MovingPallet.transform.parent.transform.parent.transform.parent.transform.GetChild(Index20 + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        TempAftPos.transform.parent.transform.parent.transform.GetComponent<Renderer>().material = ADSMat;
        Debug.Log("LKJ", TempAftPos);
       TempAftPos.transform.SetParent(MovingPallet.transform.parent.transform.parent.transform.parent.transform.GetChild(Index21 + 1).transform.GetChild(0).transform);
        TempAftPos.transform.parent.transform.parent.transform.GetComponent<Renderer>().material = Invisible;
        Debug.Log("qwerty" + TempAftPos.transform.parent.transform.gameObject);

        if (MovingPallet.transform.parent.childCount > 1)
        {
            MovingPallet.transform.SetAsFirstSibling();
            MovingPallet.transform.parent.transform.GetChild(1).transform.SetParent(null);

        }
        if (TempAftPos.transform.parent.childCount > 1)
        {

            TempAftPos.transform.SetAsFirstSibling();
            TempAftPos.transform.parent.transform.GetChild(1).transform.SetParent(null);
        }
       


    }

  public void ReturnSglPallet1()

    {

        PalletOccupied = false;
        Debug.Log("Return Pallet Begin");
        GameObject MovingPallet = ParentPosition.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        Debug.Log("JRB", MovingPallet);
        ParentPosition.GetComponent<Renderer>().material = ADSMat;
        MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACPpayload>().StartPos.transform);
        MovingPallet.transform.localPosition = new Vector3(0, 0, 2.27f);
        MovingPallet.transform.parent.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;

        if (MovingPallet.transform.parent.childCount > 1)
        {
            MovingPallet.transform.SetAsFirstSibling();
            MovingPallet.transform.parent.transform.GetChild(1).transform.SetParent(null);
            Debug.Log("Return Pallet ended");

        }


    }

    public void ReturnSglPallet2() 

    {

        PalletOccupied = false;
        Debug.Log("Return Pallet Begin from aft pos");
        int Index34 = ParentPosition.transform.GetSiblingIndex();
        GameObject MovingPallet = ParentPosition.transform.parent.GetChild(Index34 + 1).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        Debug.Log("JRB", MovingPallet);
        ParentPosition.GetComponent<Renderer>().material = ADSMat;
        MovingPallet.transform.SetParent(MovingPallet.GetComponent<ACPpayload>().StartPos.transform);
        MovingPallet.transform.localPosition = new Vector3(0, 0, 2.27f);
        MovingPallet.transform.parent.transform.parent.transform.gameObject.GetComponent<Renderer>().material = Invisible;

        if (MovingPallet.transform.parent.childCount > 1)
        {
            MovingPallet.transform.SetAsFirstSibling();
            MovingPallet.transform.parent.transform.GetChild(1).transform.SetParent(null);
            Debug.Log("Return Pallet ended");

        }


    }



    public void DidApalletMove()

    {

        int Index10 = OutCol.transform.parent.transform.GetSiblingIndex();

        
        if ((OutCol.transform.childCount >= 1))
        {
            if ((OutCol.transform.GetChild(0).transform.name == "AFTPOS") && (MovingRight == true))

            {
                if (CanRun == true)
                {
                    

                    ReturnDblPallet();

                    

                }
               
              

            }

            if ((OutCol.transform.GetChild(0).transform.name == "FWDPOS") && (MovingLeft == true))

            {
                if (CanRun == true)
                {


                    ReturnDblPallet();



                }



            }

            if ((OutCol.transform.GetChild(0).transform.name == "TempSgl") && (MovingRight == true)) // so we are exiting a single pallet place where the pallet has been moved from

            {
                Debug.Log("TempSgl");

                if (CanRun == true)
                {


                    ReturnSglPallet1();




                }



            }

            if ((OutCol.transform.GetChild(0).transform.name == "TempSgl1") && (MovingRight == true)) // so we are exiting a single pallet place where the pallet has been moved from

            {
                Debug.Log("TempSgl1");
                if (CanRun == true)
                {


                    ReturnSglPallet1();




                }



            }

            if ((OutCol.transform.GetChild(0).transform.name == "TempSgl2") && (MovingRight == true)) // so we are exiting a single pallet place where the pallet has been moved from

            {
                Debug.Log("TempSgl2");

                if (CanRun == true)
                {


                    ReturnSglPallet2();




                }



            }

            if ((OutCol.transform.GetChild(0).transform.name == "TempSgl1") && (MovingLeft == true)) // so we are exiting a single pallet place where the pallet has been moved from

            {
                Debug.Log("TempSgl1");
                if (CanRun == true)
                {


                    ReturnSglPallet1();




                }



            }

            if ((OutCol.transform.GetChild(0).transform.name == "TempSgl2") && (MovingLeft == true)) // so we are exiting a single pallet place where the pallet has been moved from

            {
                Debug.Log("TempSgl2");

                if (CanRun == true)
                {


                    ReturnSglPallet2();




                }



            }

            if ((OutCol.transform.GetChild(0).transform.name == "TempSglFwd") && (MovingRight == true)) // so we are exiting a single pallet place where the pallet has been moved from

            {
                Debug.Log("TempSglFwd");

                if (CanRun == true)
                {


                    ReturnSglPallet1();




                }



            }

            if ((OutCol.transform.GetChild(0).transform.name == "TempSglFwd") && (MovingLeft == true)) // so we are exiting a single pallet place where the pallet has been moved from

            {
                Debug.Log("TempSglFwd");

                if (CanRun == true)
                {


                    ReturnSglPallet1();




                }



            }

        }

     
    }
    }








    





      










