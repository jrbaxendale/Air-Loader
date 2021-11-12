using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveACPlogsDbl : MonoBehaviour

{
    public bool placed = false;
    public bool col;
    public Collision othertransform;
    private bool dragging = false;
    private float distance;
    private Rigidbody thisBody;
    private Collider thisCollider;
    public static GameObject Old1Collider;
    public static GameObject movebtn;
    public Material ADSGreen;
    public Material LogsBlue;




    public void Start()
    {
        movebtn = gameObject;

    }

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
        MoveObject.AddComponent<ContactMoveDbl>();

    }


}








