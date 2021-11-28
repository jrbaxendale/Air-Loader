using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoveACP : MonoBehaviour

{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
#pragma warning disable CS0414 // The field 'MoveACP.dragging' is assigned but its value is never used
    private bool dragging = false;
#pragma warning restore CS0414 // The field 'MoveACP.dragging' is assigned but its value is never used
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


    private void Start()
    {
        MoveObject = gameObject.transform.GetChild(3).gameObject.GetComponent<PalletCheckButtons>().SelectedACP.gameObject;
        ParentPosition = MoveObject.transform.parent.transform.gameObject.transform.parent.transform.gameObject; // this is the parent position e.g ADS 2
        MoveBtn = gameObject;
        CloseBtn = gameObject.transform.parent.GetChild(1).gameObject;
        AlreadyInUse = false; // alreadyinuse means the pallet has been selected to move so the button wont do anything
        OriginalPosition = MoveObject.GetComponent<ACPpayload>().OriginalPosition;
        SiblingIndex = 2;
            
      
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        

    }

    
    public void MoveThis()
    {
       
        MoveObject.gameObject.GetComponent<ACPpayload>().location = false;
        gameObject.transform.GetChild(3).transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.red;
        gameObject.transform.GetChild(3).transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;


        MoveObject.gameObject.GetComponent<ACPpayload>().Locks = false;
        gameObject.transform.GetChild(3).transform.GetChild(4).gameObject.GetComponent<Image>().color = Color.red;
        gameObject.transform.GetChild(3).transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;


        MovedButtonPressed = true;
        
        OriginalPosition = MoveObject.gameObject.GetComponent<ACPpayload>().OriginalPosition;

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
                Debug.Log("Colour change to green");

            }


            else if (ParentPosition.name.Contains("logs")) // this changes the pallet position back to logs blue

            {
                ParentPosition.GetComponent<MeshRenderer>().material = LogsBlue;
                Debug.Log("Colour change to blue");
            }


            Debug.Log("SelectedACP is..." + gameObject.transform.GetChild(3).gameObject.GetComponent<PalletCheckButtons>().SelectedACP.transform.gameObject.name); //This is the position of the pallet prior to it being moved.
            MoveObject.transform.SetParent(null);
            Debug.Log("MoveObject parent changed");
            MoveObject.transform.position = new Vector3(MoveObject.transform.position.x, 2.1f, MoveObject.transform.position.z);
            MoveObject.AddComponent<Contactmove>(); // adds contactmove script to the pallet;
            MoveObject.GetComponent<Rigidbody>().isKinematic = false; // this stops the object floating away
            MoveObject.GetComponent<BoxCollider>().enabled = enabled;
            placed = false;
            Debug.Log("Finished moving Pallet");
            AlreadyInUse = true;
            GameObject NewCXbutton = Instantiate(CXmoveButton, gameObject.transform);
            NewCXbutton.transform.SetSiblingIndex(0);
            NewCXbutton.GetComponent<Button>().onClick.AddListener(CxMoveThis);
            LiveMoveButton = NewCXbutton;
            Debug.Log("CXMove Button added");
            Debug.Log("Zule is " + gameObject.transform.GetChild(0).gameObject.name);
           
            if (gameObject.transform.GetChild(1).gameObject.name == "TheMoveBtn(Clone)")

            {

            Destroy(gameObject.transform.GetChild(1).gameObject);

            }


            CurrentMoveObject = MoveObject;
            Destroy(CurrentMoveButton);
            
            


    }



    public void CxMoveThis()
    {
       
        Debug.Log("object is .." + gameObject.name);
        gameObject.transform.GetChild(3).transform.GetChild(3).gameObject.GetComponent<Button>().enabled = enabled;
        gameObject.transform.GetChild(3).transform.GetChild(4).transform.gameObject.GetComponent<Button>().enabled = enabled;
        MoveObject = CurrentMoveObject;
        Initialized = true;
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Move";
        MoveObject.transform.SetParent(OriginalPosition.gameObject.transform);
        MoveObject.transform.parent.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the pallet position material to invisible
        MoveObject.transform.parent.parent.GetComponent<BoxCollider>().enabled = enabled;
        Destroy(MoveObject.gameObject.GetComponent<Contactmove>());
        Debug.Log("ContactMoveScript Destroyerd");
        MoveObject.transform.localPosition = new Vector3(0 , 0 , 2.37f);
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







   


