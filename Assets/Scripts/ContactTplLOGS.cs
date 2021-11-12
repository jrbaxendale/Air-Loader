using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactTplLOGS : MonoBehaviour
{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
    private bool dragging = false;
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    public GameObject DeleteBtnUI;

    public Material Invisible;
    public Material HighlightedACP;
    public Material ADSMat;
    public GameObject Maincanvas;
    public Material LogsMat;



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
        col = true;

        Debug.Log(collision.transform.name);

        if (collision.transform != null && collision.transform.parent.transform.GetComponent<Renderer>() != null)
        {


            collision.transform.parent.transform.GetComponent<Renderer>().material = HighlightedACP;
            collision.transform.parent.parent.transform.GetChild(collision.transform.parent.GetSiblingIndex() + 2).gameObject.GetComponent<Renderer>().material = HighlightedACP;
            collision.transform.parent.parent.transform.GetChild(collision.transform.parent.GetSiblingIndex() + 4).gameObject.GetComponent<Renderer>().material = HighlightedACP;


        }



        othertransform = collision;

    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.parent.name.Contains("logs"))
        {
            collision.transform.parent.GetComponent<Renderer>().material = LogsMat;
            Debug.Log(collision.transform.parent.parent.transform.GetChild(collision.transform.parent.GetSiblingIndex() + 2).transform.name + "collision item");


            collision.transform.parent.parent.transform.GetChild(collision.transform.parent.GetSiblingIndex() + 2).gameObject.GetComponent<Renderer>().material = LogsMat;
            collision.transform.parent.parent.transform.GetChild(collision.transform.parent.GetSiblingIndex() + 4).gameObject.GetComponent<Renderer>().material = LogsMat;
        }
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



                    {
                        Debug.Log("GetMouseUPWorking");
                        gameObject.transform.SetParent(othertransform.transform);
                        gameObject.transform.localPosition = new Vector3(0, -8.5f, 0);


                        placed = true;
                        thisBody = gameObject.GetComponent<Rigidbody>();
                        thisBody.isKinematic = true;
                        thisCollider = gameObject.GetComponent<BoxCollider>();
                        thisCollider.enabled = !thisCollider.enabled;
                        othertransform.transform.GetComponent<BoxCollider>().enabled = !enabled;
                        gameObject.tag = "loaded";
                        gameObject.layer = LayerMask.NameToLayer("loaded");
                        othertransform.gameObject.tag = "loaded";
                        othertransform.transform.parent.gameObject.tag = "loaded";
                        othertransform.gameObject.layer = LayerMask.NameToLayer("loaded");
                        othertransform.transform.parent.gameObject.layer = LayerMask.NameToLayer("loaded");

                        gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = !enabled;

                        Debug.Log("sibling index =" + gameObject.transform.parent.parent.transform.GetSiblingIndex());
                        Transform sibling2 = gameObject.transform.parent.parent.parent.transform.GetChild(gameObject.transform.parent.parent.transform.GetSiblingIndex() + 2);
                        GameObject sib2 = sibling2.gameObject;
                        sib2.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = !enabled;
                        Debug.Log("sibling index =" + gameObject.transform.parent.parent.transform.GetSiblingIndex());
                        Transform sibling1 = gameObject.transform.parent.parent.parent.transform.GetChild(gameObject.transform.parent.parent.transform.GetSiblingIndex() + 4);
                        GameObject sib = sibling1.gameObject;
                        sib.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = !enabled;

                        GameObject.Find("MainCanvas").GetComponent<RaycastOff>().TurnOnRaycast();





                    }

                    if (Input.GetMouseButtonDown(1))
                    {

                        GameObject DeleteBtn = Instantiate(DeleteBtnUI) as GameObject;
                        DeleteBtn.transform.localPosition = new Vector3(0, 420, 0);

                    }



                }



            }
        }
    }
}






