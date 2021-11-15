using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contact : MonoBehaviour
{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
    private bool dragging = false;
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    public GUI DeleteBtnUI;
    
    public Material Invisible;
    public Material HighlightedACP;
    public Material ADSMat;
    public GameObject Maincanvas;
    public Material LogsMat;
    public GameObject MakeACPBtn;
    public GameObject MainCanvas;

    public static string ParentName;
    public static string PalletsWeight;
    public static string PalletsID;
    public static string PalletsDest;
    public static string Sgl;


    public void Awake()
    {
        Maincanvas = GameObject.Find("MainCanvas");
     
    }

    private void Start()
    {
       


        transform.position = new Vector3(0, 0.83f, 0);

    }



   




    public void OnCollisionEnter(Collision collision)

    {
        col = true;
        Debug.Log(collision.transform.name);

        if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null)
        {
            collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;
        }

        othertransform = collision; // othertransform is the gameobject( logs or ADS child collider) which the pallet has collided with

    }

    public void OnCollisionExit(Collision collision)
    {
        if ((collision.transform.parent.name.Contains("ADS")) && (collision.transform.parent.tag != "ignore"))
        {
            collision.transform.parent.GetComponent<Renderer>().material = ADSMat; // returns the material of the collided object back to its original
           
        }
       
        else if (collision.transform.parent.name.Contains("logs"))
        {
            collision.transform.parent.GetComponent<Renderer>().material = LogsMat; // returns the material of the collided object back to its original
        }
    }




    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))


        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;


        }


        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }



        if
            ((!dragging) && (placed == false))
        {
            transform.position = new Vector3(0, 0.83f, 0); // if player lets go of the mouse button and its not above a pallet position it will return the pallet to 0,0,0,

        }

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            rayPoint.x = Mathf.Clamp(rayPoint.x, -13.4f, 11.4f);// these 3 lines limit where the pallet can be dragged to
            rayPoint.z = Mathf.Clamp(rayPoint.z, -2.1f, 2.1f);
            rayPoint.y = Mathf.Clamp(rayPoint.y, 0.83f, 0.83f);
          

            transform.position = rayPoint;
            Debug.Log("dragging");

        }


        if (Input.GetMouseButtonUp(0)) 
            
        {
            if (othertransform != null)
            {

                if ((othertransform.transform.name.Contains("col"))/* && (col == true) && (placed == false)*/) // this checks whether the pallet has collided with the correct collider called 'col'; checks whether the collision is actually true; checks there is not another pallet on it already (placed == false)
                {
                    Debug.Log("GetMouseUPWorking");
                    gameObject.transform.SetParent(othertransform.transform); // sets the pallet parent to the collider
                    gameObject.GetComponent<ACPpayload>().OriginalPosition = gameObject.transform.parent.gameObject;
                    gameObject.transform.localPosition = new Vector3(0, 0, 2.37f); // sets local position of the pallet to 0
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
                    othertransform.transform.GetComponent<BoxCollider>().enabled = !enabled; // this turns off the pallet positions collider
                    gameObject.tag = "loaded"; // pallet tag is loaded
                    gameObject.layer = LayerMask.NameToLayer("loaded"); // pallet layer is loaded
                    //gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = !enabled; // thjis turns of the orange glow animation
                    othertransform.gameObject.tag = "loaded"; // this puts the pallet positions collider tag as loaded
                    othertransform.transform.parent.gameObject.tag = "loaded"; // this sets the pallet positions tag as loaded
                    othertransform.gameObject.layer = LayerMask.NameToLayer("nohit"); // this sets the pallet positions layer to 'nohit' 
                    othertransform.transform.parent.gameObject.layer = LayerMask.NameToLayer("loaded"); // this sets the pallet position layer to loaded
                    Maincanvas.GetComponent<RaycastOff>().TurnOnRaycast(); // this turns the raycast back on now that the pallet is placed
                    othertransform.transform.parent.GetComponent<Renderer>().material = Invisible; // this turns the pallet position material to invisible
                    GameObject Make = GameObject.FindGameObjectWithTag("AddSingleACP"); // this finds the makeACP button
                    Make.gameObject.GetComponent<Button>().interactable = true; // this turns the makeACP button back on now the pallet is placed
                    gameObject.GetComponent<ACPpayload>().GetTitle();
                    othertransform.transform.parent.GetComponent<BoxCollider>().enabled = enabled;
                    Maincanvas.transform.GetChild(1).gameObject.SetActive(true); // this is which pallet panel
                    Maincanvas.transform.GetChild(6).gameObject.SetActive(true); // this is config
                    Maincanvas.transform.GetChild(7).gameObject.SetActive(true); // this is part one
                    Maincanvas.transform.GetChild(8).gameObject.SetActive(true); // this is load view
                    gameObject.GetComponent<ACPpayload>().StartPos = gameObject.transform.parent.transform.gameObject;


                    Destroy(this); // destroys this script as it gets in the way of the MOVE and Delete scripts
                    return;
                }

            }
        }
         


    }


}
   


