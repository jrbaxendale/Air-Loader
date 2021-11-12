using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtnDelDouble : MonoBehaviour
{
    public static bool pause1 = Raycast.pause;

    public void ExitDelete()
    {
        Destroy(GameObject.Find("DeleteDouble(Clone)"));
        Raycast.hit.collider.gameObject.GetComponentInChildren<Transform>().gameObject.tag = "loaded";
        Raycast.pause = false;
        Destroy(gameObject);
        Debug.Log("Delete Cancelled");

    }



}

