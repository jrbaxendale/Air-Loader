using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds : MonoBehaviour

{ 

   public GameObject TPUprefab1;


    private void OnTriggerEnter(Collider col) 
    {
        
        if ( col.gameObject.name == "TPU3(Clone)")

        {
            Debug.Log("collided");
            //TPUprefab1.transform.localPosition = new Vector3(0, 1, 0);
           // TPUprefab1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
           // TPUprefab1.transform.localEulerAngles = new Vector3(0, 0, 0);

        }


    }

}

