using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Contactmove : MonoBehaviour
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
    public Vector3 StartingPosition;
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
    public bool PreviouslyCollided;
    public bool NewlyOccupied;
    public GameObject PreviousACPposition;
    public GameObject CurrentACPposition;
    public GameObject StartingPalletPlace;
    public TextMeshProUGUI PositionText;
    public GameObject SelectedPanel;
    public GameObject TheSelectedPanel;
    public Material BlueNormal;
    public Material GreenSeeThrough;
    public bool Palletalreadymoved;


    private void Awake()
    {

        ParentPosition = MoveACP.ParentPosition; // this is the parent position e.g ADS 2
        StartingPosition = gameObject.transform.position;
        ACPboxcollider = gameObject.GetComponent<BoxCollider>();
        BoxScalenewZ = 0.01f;
        NewlyOccupied = false;
        SelectedPanel = GameObject.Find("SelectedPanel(Clone)");
        BoxScaleX = gameObject.GetComponent<BoxCollider>().size.x;
        BoxScaleY = gameObject.GetComponent<BoxCollider>().size.y;
        BoxScaleZ = gameObject.GetComponent<BoxCollider>().size.z;
        TheSelectedPanel = SelectedPanel;




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
        PreviouslyCollided = false;
        


    }

    public void OnCollisionEnter(Collision collision)

    {
        CurrentACPposition = collision.gameObject;
        col = true;
        Debug.Log("Collision Item =" + collision.transform.parent.name);

        if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null) // collision should be the collider child object of a pallet position
        {
            collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;
            PositionText = SelectedPanel.gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            PositionText.text = collision.gameObject.transform.parent.gameObject.name.ToString();

        }

        if (collision.transform.childCount > 0 && (!collision.gameObject.name.Contains("ADS")) && (collision.transform.GetChild(0).name == gameObject.name)) // check if the pallet position has a pallet on it
        {
            if (Palletalreadymoved == false)
            {
                PreviouslyCollided = true;
                PreviousPallet = collision.transform.GetChild(0).transform.gameObject; // get the pallet which was already occupying the pallet position.
                GameObject TEMP = new GameObject();
                TEMP.transform.SetParent(collision.collider.transform);
                TEMP.transform.name = "TEMP";
                TEMP.transform.SetAsLastSibling();
                PreviousPallet.transform.SetParent(ParentPosition.transform.GetChild(0).transform); // moves the pallet in this position to the now empty one.
                Debug.Log("PreviousPallet" + PreviousPallet.name);
                PreviousPallet.transform.GetComponent<Renderer>().material = BlueNormal;
                PreviousPallet.transform.parent.transform.parent.GetComponent<Renderer>().material = Invisible;
                PreviousPallet.transform.localPosition = new Vector3(0, 0, 2.35f);
                Palletalreadymoved = true;
                return;
            }

            else if (Palletalreadymoved == true)
            {

                return;
            }
        }


        if (CurrentACPposition.transform.parent.transform.name.Contains("logs"))
        {

            gameObject.transform.localEulerAngles = new Vector3(-90, 0, 0); // this sets the orientation of the instantiated pallet
            gameObject.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 90); // this sets the orientation of the canvas gameobject on the instantiated pallet
        }

        else if (CurrentACPposition.transform.parent.transform.name.Contains("ADS"))

        {
            gameObject.transform.localEulerAngles = new Vector3(-90, 90, 0); // This sets the orientation of the instantiated pallet
            gameObject.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void OnCollisionExit(Collision Outgoingcollision)
    {
        col = false;
        if (Outgoingcollision.transform.parent.name.Contains("ADS"))
        {
            if (PreviouslyCollided == true)

            {
                Outgoingcollision.transform.parent.GetComponent<Renderer>().material = Invisible; // returns the material of the collided object back to invisible

            }

            else if (PreviouslyCollided == false)

            {
                Outgoingcollision.transform.parent.GetComponent<Renderer>().material = ADSMat; // returns the material of the collided object back to its original

            }
        }

        else if (Outgoingcollision.transform.parent.name.Contains("logs") && Outgoingcollision.transform.parent.GetComponent<Renderer>() != null)
        {
            Outgoingcollision.transform.parent.GetComponent<Renderer>().material = LogsMat; // returns the material of the collided object back to its original
        }

        if (Outgoingcollision.collider.transform.childCount >= 1)

        {

            if ((Outgoingcollision.collider.transform.GetChild(0).transform.name == "TEMP") && (Palletalreadymoved == true))
            {
                PreviousPallet.transform.parent.transform.parent.GetComponent<Renderer>().material = ADSMat;
                PreviousPallet.transform.SetParent(Outgoingcollision.transform);
                PreviousPallet.transform.localPosition = new Vector3(0, 0, 2.27f);
                PreviousPallet.transform.SetAsLastSibling();
                Destroy(Outgoingcollision.collider.transform.GetChild(0).transform.gameObject);
                Palletalreadymoved = false;


                PreviousPallet.transform.localPosition = new Vector3(0, 0, 2.36f);
                PreviouslyCollided = false;



                if (PreviousPallet.GetComponent<ACPpayload>().Checked == false)

                {
                    PreviousPallet.GetComponent<Renderer>().material = BlueNormal;

                }

                else if (PreviousPallet.GetComponent<ACPpayload>().Checked == true)

                {
                    PreviousPallet.GetComponent<Renderer>().material = GreenSeeThrough;

                }
            }


           
        }

        if (Outgoingcollision.transform.parent.transform.name.Contains("logs"))
        {

            gameObject.transform.localEulerAngles = new Vector3(-90, 0, 0); // this sets the orientation of the instantiated pallet
            gameObject.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 90); // this sets the orientation of the canvas gameobject on the instantiated pallet
        }

        else if (Outgoingcollision.transform.parent.transform.name.Contains("ADS"))

        {
            gameObject.transform.localEulerAngles = new Vector3(-90, 90, 0); // This sets the orientation of the instantiated pallet
            gameObject.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 0);
        }





    }
    
   




    public void OnMouseUp()

    {
        SelectedPanel = GameObject.Find("SelectedPanel(Clone)");
        gameObject.GetComponent<BoxCollider>().size = new Vector3(BoxScaleX, BoxScaleY, BoxScaleZ); // this returns the collider back to a smaller size

        if ((col == true) && (CurrentACPposition.name == "collider"))
        {
            TheSelectedPanel.gameObject.transform.GetChild(3).transform.GetChild(3).gameObject.GetComponent<Button>().enabled = enabled;
            TheSelectedPanel.gameObject.transform.GetChild(3).transform.GetChild(4).transform.gameObject.GetComponent<Button>().enabled = enabled;

            Debug.Log("Contactmove script beginning");
            Debug.Log("MOVEACP Pallet is ... " + MoveACP.ParentPosition.transform.name);
            NewlyOccupied = true;
            gameObject.transform.SetParent(CurrentACPposition.transform); // sets the parent to the 'collider' gameobject
            gameObject.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = !enabled;

           


                
            gameObject.transform.localPosition = new Vector3(0, 0, 2.37f);// sets the position to higher than the mainfloor
            Debug.Log(CurrentACPposition.transform.name + " is the CurrentACPposition");
            CurrentACPposition.transform.parent.transform.GetComponent<Renderer>().material = Invisible;
            CurrentACPposition.transform.parent.transform.GetComponent<BoxCollider>().enabled = enabled;
            thisBody = gameObject.GetComponent<Rigidbody>();
            thisBody.isKinematic = true; // pallet rigidbody turned on
            CurrentACPposition.gameObject.layer = LayerMask.NameToLayer("nohit"); // parent layer changed
            CurrentACPposition.transform.GetChild(0).GetComponent<BoxCollider>().enabled = !enabled; // this pallets box collider turned off
            GameObject.Find("MainCanvas").GetComponent<RaycastOff>().TurnOnRaycast(); // turns the raycast script back on
            Raycast.pause = false;
            Occupied = true;
            MoveACP.ParentPosition.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;
            MoveACP.ParentPosition.transform.GetComponent<BoxCollider>().enabled = !enabled;
            MoveACP.ParentPosition = CurrentACPposition.transform.parent.gameObject;
            MoveACP.MovedButtonPressed = false;

            GameObject SelectedPanel = GameObject.Find("SelectedPanel(Clone)");
            SelectedPanel.GetComponent<MoveACP>().AfterMovedPallet();

            Debug.Log("ContactMove Complete");

            foreach (GameObject i in PalletArray.Palletarray)
            {
                i.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled = enabled; // this is the pallet position eg ADS1
                i.transform.parent.GetComponent<BoxCollider>().enabled = !enabled; // this enables the 'collider' gameobject


            }




            gameObject.GetComponent<ACPpayload>().OriginalPosition = CurrentACPposition;
            //MoveACP.CloseBtn.GetComponent<UnityEngine.UI.Button>().interactable = true; // re-enbles the close button on the selected Panel.
            MoveACP.AlreadyInUse = false;
            Destroy(this); // destroys this script





        }


        else
        {
            dragging = false;
            Debug.Log("The mouse is up");
            gameObject.transform.position = StartingPosition;
        }





    }

    private void OnMouseDown()
    {
        dragging = true;
        gameObject.GetComponent<BoxCollider>().size = new Vector3(BoxScaleX, BoxScaleY, BoxScalenewZ);


    }



    void FixedUpdate()
    {
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
            rayPoint.y = Mathf.Clamp(rayPoint.y, 2.1f, 2.1f);
            rayPoint.z = Mathf.Clamp(rayPoint.z, -2.1f, 2.1f);
            transform.position = rayPoint;
            Debug.Log("dragging");
            ParentPosition.transform.GetComponent<BoxCollider>().enabled = !enabled;


        }




        else
        {
            if (col == false)

            {

                dragging = false;
                Debug.Log("The mouse is up");
                gameObject.transform.position = StartingPosition;

            }


        }

       
    }

}
