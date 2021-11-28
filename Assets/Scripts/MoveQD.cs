using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoveQD : MonoBehaviour
{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
#pragma warning disable CS0414 // The field 'MoveQD.dragging' is assigned but its value is never used
    private bool dragging = false;
#pragma warning restore CS0414 // The field 'MoveQD.dragging' is assigned but its value is never used
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    public static GameObject PalletPosition;
    public static GameObject ParentPosition;
    public static GameObject MoveObject;
    public Material ADSGreen;
    public Material LogsBlue;
    public static GameObject MoveBtn;
    public static GameObject OriginalPosition;
    public static GameObject CloseBtn;
    public static bool AlreadyInUse;
    public static bool CXmoveBtn;
    public static RaycastHit hit;
    public float BoxScaleZ;
    public GameObject CXmoveButton;
    public GameObject CurrentMoveButton;
    public static bool MovedButtonPressed;
    public int SiblingIndex;
    public GameObject TheMoveButton;
    public GameObject CurrentMoveObject;
    public GameObject LiveMoveButton;
    public bool Initialized;
    public Material Invisible;
    public GameObject MoveObjectAFT;
    public GameObject MoveObjectFWD;
    public int Index;

    private void Awake()
    {
        ADSGreen = (Material)Resources.Load("Materials/Empty ADS pos", typeof(Material)); // gets the ADS material
        LogsBlue = (Material)Resources.Load("Materials/Empty logs Position", typeof(Material)); // gets the logs material
        Invisible = (Material)Resources.Load("Materials/invisible", typeof(Material)); // gets the invisible material
    }

    private void Start()
    {
        MoveObject = gameObject.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.gameObject;
        Index = MoveObject.transform.parent.transform.parent.GetSiblingIndex();
        MoveObjectAFT = MoveObject.transform.parent.transform.parent.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
        Debug.Log("QWERTY =" + MoveObjectAFT.name);
        ParentPosition = MoveObject.transform.parent.transform.gameObject.transform.parent.transform.gameObject; // this is the parent position e.g ADS 2
        MoveBtn = gameObject;
        CloseBtn = gameObject.transform.parent.GetChild(1).gameObject;
        AlreadyInUse = false; // alreadyinuse means the pallet has been selected to move so the button wont do anything
        OriginalPosition = MoveObject.GetComponent<ACP_PayloadQD>().OriginalPosition;
        SiblingIndex = 2;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
    }


    public void MoveThis()
    {

        MoveObject.gameObject.GetComponent<ACP_PayloadQD>().location = false;
        gameObject.transform.GetChild(3).transform.GetChild(7).gameObject.GetComponent<Image>().color = Color.red;
        gameObject.transform.GetChild(3).transform.GetChild(7).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        MoveObject.gameObject.GetComponent<ACP_PayloadQD>().Locks = false;
        gameObject.transform.GetChild(3).transform.GetChild(8).gameObject.GetComponent<Image>().color = Color.red;
        gameObject.transform.GetChild(3).transform.GetChild(8).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;

        MovedButtonPressed = true;
        OriginalPosition = MoveObject.gameObject.GetComponent<ACP_PayloadQD>().OriginalPosition;
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Move";
        GameObject.Find("MainCanvas").GetComponent<RaycastOff>().TurnOffRaycast();

        foreach (GameObject i in PalletArray.Palletarray)
        {
            i.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled = !enabled; // this is the pallet position eg ADS1
            i.transform.parent.GetComponent<BoxCollider>().enabled = enabled; // this enables the 'collider' gameobject

        }



        if (ParentPosition.name.Contains("ADS")) // this changes the pallet position back to ADS green
        {

            ParentPosition.GetComponent<MeshRenderer>().material = ADSGreen;
            Index = ParentPosition.transform.GetSiblingIndex();
            MoveObjectAFT = ParentPosition.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
            MoveObjectAFT.GetComponent<MeshRenderer>().material = ADSGreen;
            MoveObjectFWD = ParentPosition.transform.parent.transform.GetChild(Index - 1).transform.gameObject;
            MoveObjectFWD.GetComponent<MeshRenderer>().material = ADSGreen;

            Debug.Log("Colour change to green");

        }


        else if (ParentPosition.name.Contains("logs")) // this changes the pallet position back to logs blue

        {
            ParentPosition.GetComponent<MeshRenderer>().material = LogsBlue;
            Debug.Log("Colour change to blue");
        }


        Debug.Log("SelectedACP is..." + gameObject.transform.GetChild(3).gameObject.GetComponent<QDcheckButtons>().SelectedACP.transform.gameObject.name); //This is the position of the pallet prior to it being moved.
        MoveObject.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled = !enabled;
        MoveObject.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
        Index = MoveObject.transform.parent.transform.parent.GetSiblingIndex();

        MoveObjectFWD = MoveObject.transform.parent.transform.parent.transform.parent.transform.GetChild(Index - 1).transform.gameObject;
        MoveObjectFWD.transform.GetChild(0).transform.GetChild(0).transform.SetParent(null);
        MoveObjectFWD.transform.GetComponent<BoxCollider>().enabled = !enabled;
        MoveObjectFWD.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = enabled;


        MoveObjectAFT = MoveObject.transform.parent.transform.parent.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
        MoveObjectAFT.transform.GetChild(0).transform.GetChild(0).transform.SetParent(null);
        MoveObjectAFT.transform.GetComponent<BoxCollider>().enabled = !enabled;
        MoveObjectAFT.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = enabled;



        MoveObject.transform.SetParent(null);
        Debug.Log("MoveObject parent changed");
        MoveObject.transform.position = new Vector3(MoveObject.transform.position.x, 2.03f, MoveObject.transform.position.z);
        MoveObject.AddComponent<ContactMoveQD>(); // adds contactmove script to the pallet;
        MoveObject.GetComponent<Rigidbody>().isKinematic = false; // this stops the object floating away
        MoveObject.GetComponent<BoxCollider>().enabled = !enabled;
        placed = false;
        Debug.Log("Finished moving Pallet");
        AlreadyInUse = true;
        GameObject NewCXbutton = Instantiate(CXmoveButton, gameObject.transform);
        NewCXbutton.transform.SetSiblingIndex(0);
        NewCXbutton.GetComponent<Button>().onClick.AddListener(CxMoveThis);
        LiveMoveButton = NewCXbutton;



        if (gameObject.transform.GetChild(1).gameObject.name == "MoveACPQD")

        {

            Destroy(gameObject.transform.GetChild(1).gameObject);

        }

        if (gameObject.transform.GetChild(1).gameObject.name == "TheMoveBtn(Clone)")

        {

            Destroy(gameObject.transform.GetChild(1).gameObject);

        }


        CurrentMoveObject = MoveObject;


        DestroyImmediate(CurrentMoveButton, true);




    }



    public void CxMoveThis()
    {


        gameObject.transform.GetChild(3).transform.GetChild(7).gameObject.GetComponent<Button>().enabled = enabled;
        gameObject.transform.GetChild(3).transform.GetChild(8).transform.gameObject.GetComponent<Button>().enabled = enabled;
        MoveObject = CurrentMoveObject;
        Initialized = true;
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Move";
        MoveObject.transform.SetParent(OriginalPosition.gameObject.transform);
        MoveObject.transform.localPosition = new Vector3(0, 0, 2.06f); // sets local position of the pallet to 0
        MoveObject.transform.parent.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the pallet position material to invisible
        MoveObject.transform.parent.parent.GetComponent<BoxCollider>().enabled = enabled;
        Index = MoveObject.transform.parent.transform.parent.GetSiblingIndex();
        MoveObjectAFT = MoveObject.transform.parent.transform.parent.transform.parent.transform.GetChild(Index + 1).transform.gameObject;
        MoveObjectAFT.transform.GetComponent<BoxCollider>().enabled = enabled;
        MoveObjectAFT.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = enabled;
        MoveObjectAFT.transform.GetComponent<Renderer>().material = Invisible; // this turns the pallet position material to invisible
        GameObject TemporaryChild = new GameObject();
        TemporaryChild.gameObject.transform.SetParent(MoveObjectAFT.transform.GetChild(0).transform); // this puts a gameobject in the aft position so other pallets no it is actually occupied
        TemporaryChild.gameObject.name = MoveObjectAFT.transform.GetChild(0).transform.GetChild(0).gameObject.name; // this matches the names of the double pallet positions so it is clear they are linked
        Destroy(MoveObject.gameObject.GetComponent<ContactMoveQD>());
        Debug.Log("ContactMoveScript Destroyerd");

        MoveObject.GetComponent<Rigidbody>().isKinematic = false; // this stops the object floating away
        MoveObject.GetComponent<BoxCollider>().enabled = !enabled;
        placed = true;
        //GameObject.Find("MainCanvas").GetComponent<RaycastOff>().TurnOnRaycast();
        Debug.Log("Cancelled moving Pallet");
        AlreadyInUse = false;
        GameObject NewMovebutton = Instantiate(TheMoveButton, gameObject.transform);
        NewMovebutton.GetComponent<Button>().onClick.AddListener(MoveThis);
        NewMovebutton.transform.SetSiblingIndex(0);
        Debug.Log("CMove Button added");
        MovedButtonPressed = false;
        Destroy(LiveMoveButton);



    }

    public void AfterMovedPallet()
    {
        GameObject NewMovebutton = Instantiate(TheMoveButton, gameObject.transform);
        NewMovebutton.GetComponent<Button>().onClick.AddListener(MoveThis);
        NewMovebutton.transform.SetSiblingIndex(0);
        Debug.Log("CMove Button added");
        MovedButtonPressed = false;
        Destroy(LiveMoveButton);

    }

}
