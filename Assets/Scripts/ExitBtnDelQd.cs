using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtnDelQd : MonoBehaviour
{
    public static bool pause1 = Raycast.pause;

    public void ExitDelete()
    {
        Destroy(GameObject.Find("Delete(Clone)"));
        Raycast.hit.collider.gameObject.GetComponentInChildren<Transform>().gameObject.tag = "loaded";
        Raycast.pause = false;
        Destroy(gameObject);
        Debug.Log("Delete Cancelled");

    }


}
