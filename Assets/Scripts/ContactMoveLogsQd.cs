using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactMoveLogsQd : MonoBehaviour
{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
    private bool dragging = false;
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    public GameObject OldCollider;



    private void Start()
    {

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.28f, gameObject.transform.position.z);
        placed = false;
    }


    void OnMouseDown()


    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Debug.Log("mousedownMOVEACP");

    }


    void OnMouseUp()
    {
        dragging = false;
        Debug.Log("mouseupMOVEACP");
    }





    public void OnCollisionEnter(Collision collision)

    {
        col = true;
        Debug.Log("COLLISION!" + collision.transform.gameObject.name);









        othertransform = collision;

    }
    void Update()
    {
        Debug.Log("MOVEACP");


        if
            ((!dragging) && (placed == false))
        {





        }

        if (dragging)
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            rayPoint.x = Mathf.Clamp(rayPoint.x, -13.4f, 11.4f);
            rayPoint.z = Mathf.Clamp(rayPoint.z, -2.1f, 2.1f);
            rayPoint.y = Mathf.Clamp(rayPoint.y, 0.28f, 0.28f);




            transform.position = rayPoint;
            Debug.Log("dragging");

        }


        if (Input.GetMouseButtonUp(0) && (col == true) && (placed == false) && (othertransform.gameObject.name == "collider"))
        {
            Debug.Log("Movingacp");

            gameObject.transform.SetParent(othertransform.transform);
            gameObject.transform.localPosition = new Vector3(0, -9.73f, 0);



            placed = true;
            thisBody = gameObject.GetComponent<Rigidbody>();
            thisBody.isKinematic = true;
            thisCollider = gameObject.GetComponent<BoxCollider>();
            thisCollider.enabled = !thisCollider.enabled;
            // othertransform.transform.GetComponent<BoxCollider>().enabled = !enabled;
            gameObject.tag = "loaded";
            gameObject.layer = LayerMask.NameToLayer("loaded");
            othertransform.gameObject.tag = "loaded";
            othertransform.transform.parent.gameObject.tag = "loaded";
            othertransform.gameObject.layer = LayerMask.NameToLayer("nohit");
            othertransform.transform.parent.gameObject.layer = LayerMask.NameToLayer("loaded");
            othertransform.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;

            gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().enabled = !enabled;

            GameObject oldCollider = MoveACP.PalletPosition;

            Debug.Log(oldCollider.name + "sos");
            oldCollider.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = enabled;

            GameObject MainCanvas = GameObject.Find("MainCanvas");
            Raycast.pause = false;
            oldCollider = MoveACP.PalletPosition.gameObject;
            Debug.Log("Move Complete");
          
            Destroy(this);





        }





    }


}
