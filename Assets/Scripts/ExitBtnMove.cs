using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtnMove : MonoBehaviour
{
    public static bool pause1 = Raycast.pause;
    
    
    
    
    
    
    public void ExitMove()


    {



        Destroy(GameObject.Find("MoveACP(Clone)"));
        Raycast.hit.collider.gameObject.GetComponentInChildren<Transform>().gameObject.tag = "loaded";
        pause1 = false;
        Destroy(gameObject);
        Debug.Log("Move ACP Cancelled");


    }









}





