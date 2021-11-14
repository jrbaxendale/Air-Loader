using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQdADS : MonoBehaviour

{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
    private bool dragging = false;
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    public GameObject Old1Collider;
    public GameObject DeleteObject2;
    public GameObject DeleteObject4;
    public Material ADSGreen;
    public Material LogsBlue;


    public void MoveThis()
    {

        GameObject MoveObject = GameObject.FindGameObjectWithTag("move");
        Debug.Log(MoveObject.transform.name + "this one!");
        Old1Collider = MoveObject;

        if (MoveObject.gameObject.name.Contains("ADS"))
        {

            MoveObject.gameObject.GetComponent<MeshRenderer>().material = ADSGreen;
            Debug.Log("Colour change to green");


        }

        else
        {
            Debug.Log("No material change");


        }


        if (MoveObject.gameObject.name.Contains("logs"))

        {
            MoveObject.gameObject.GetComponent<MeshRenderer>().material = LogsBlue;
            Debug.Log("Colour change to blue");
        }

        else
        {
            Debug.Log("No material change");


        }







        MoveObject.tag = "empty";
        MoveObject.layer = LayerMask.NameToLayer("empty");
        //MoveObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;
        MoveObject.transform.GetChild(0).tag = "empty";
        MoveObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("nohit");
        Debug.Log("Moving Pallet");
        MoveObject = MoveObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        MoveObject.transform.SetParent(null);
        MoveObject.GetComponent<Rigidbody>().isKinematic = false;
        MoveObject.GetComponent<BoxCollider>().enabled = enabled;
        MoveObject.tag = "empty";
        Debug.Log("tag is now empty");
        placed = false;
        Debug.Log("placed = false");
        MoveObject.AddComponent<ContactMoveQD>();

        int index = DeleteObject2.transform.GetSiblingIndex();
        Transform DeleteObject3 = DeleteObject2.transform.parent.GetChild(index + 1);
        Debug.Log(DeleteObject3.name);
        DeleteObject3.tag = "empty";
        DeleteObject3.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;

        Transform DeleteObject4 = DeleteObject2.transform.parent.GetChild(index + 2);
        Debug.Log(DeleteObject4.name);
        DeleteObject4.tag = "empty";
        DeleteObject4.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;

        Transform DeleteObject5 = DeleteObject2.transform.parent.GetChild(index + 3);
        Debug.Log(DeleteObject5.name);
        DeleteObject5.tag = "empty";
        DeleteObject5.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = enabled;

    }


}








