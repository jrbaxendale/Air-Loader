using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactDbl : MonoBehaviour
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
    public GameObject Sphere;



    void OnMouseDown()


    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;

    }


    void OnMouseUp()
    {
        dragging = false;
    }




void Update()
    {



        if
            ((!dragging) && (placed == false))
        {
            transform.position = new Vector3(0, 0.28f, 0);


        }
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            rayPoint.x = Mathf.Clamp(rayPoint.x, -13.4f, 11.4f);
            rayPoint.z = Mathf.Clamp(rayPoint.z, -2.1f, 2.1f);
            rayPoint.y = transform.position.y;

            transform.position = rayPoint;

        }


        if (Input.GetMouseButtonUp(0))
        {
            if (othertransform != null)
            {

                if ((othertransform.transform.name.Contains("col")) && (col == true) && (placed == false))
                {




                    Debug.Log("GetMouseUPWorking");
                    gameObject.transform.SetParent(othertransform.transform);
                    gameObject.transform.localPosition = new Vector3(0, -3.213f, 0);


                    placed = true;
                    thisBody = gameObject.GetComponent<Rigidbody>();
                    thisBody.isKinematic = true;
                    thisCollider = gameObject.GetComponent<BoxCollider>();
                    thisCollider.enabled = !thisCollider.enabled;
                    othertransform.transform.GetComponent<BoxCollider>().enabled = !enabled;
                    Debug.Log("sibling index =" + gameObject.transform.parent.parent.transform.GetSiblingIndex());
                    Transform sibling1 = gameObject.transform.parent.parent.parent.transform.GetChild(gameObject.transform.parent.parent.transform.GetSiblingIndex() + 2);
                    GameObject sib = sibling1.gameObject;
                    sib.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = !enabled;
                    gameObject.tag = "loaded";
                    gameObject.layer = LayerMask.NameToLayer("loaded");

                    gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = !enabled;

                    GameObject.Find("MainCanvas").GetComponent<RaycastOff>().TurnOnRaycast();
                    othertransform.gameObject.tag = "loaded";
                    othertransform.transform.parent.gameObject.tag = "loaded";
                    othertransform.gameObject.layer = LayerMask.NameToLayer("loaded");
                    othertransform.transform.parent.gameObject.layer = LayerMask.NameToLayer("loaded");
                    GameObject Make = GameObject.FindGameObjectWithTag("AddDoubleACP");
                    Make.gameObject.GetComponent<Button>().interactable = true;
                    Sphere.transform.localPosition = new Vector3(0, 0, 0);
                    Vector2 vec = new Vector2(Sphere.transform.localPosition.x, Sphere.transform.localPosition.y);
                    Vector2 veb = new Vector2(FlightStationZero.FS0.transform.localPosition.x, FlightStationZero.FS0.transform.localPosition.y);
                    Debug.Log("DISTANCE IS ...." + Vector2.Distance(vec, veb));
                    
                }

            }






        }



    }
}



