using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteQd : MonoBehaviour
{
    public GameObject script;
    public GameObject DeleteObject;
    public GameObject DeleteObject2;



    public void DeleteThis()
    {
        Destroy(GameObject.Find("Exit btn Del(Clone)"));

        DeleteObject = GameObject.FindGameObjectWithTag("delete");
        Debug.Log(DeleteObject.transform.name);


        DeleteObject = DeleteObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        Debug.Log(DeleteObject.name);
        Destroy(DeleteObject);
        

        DeleteObject2 = GameObject.FindGameObjectWithTag("delete");
        DeleteObject2.tag = "empty";
        DeleteObject2 = DeleteObject2.transform.GetChild(0).gameObject;
        DeleteObject2.GetComponent<BoxCollider>().enabled = true;
        DeleteObject2 = DeleteObject2.transform.parent.gameObject;
        Debug.Log(DeleteObject2.name);

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

        script = GameObject.Find("MainCanvas");
       
        Raycast.pause = false;
        



        Destroy(gameObject);





    }
}
