using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPUpanelCols : MonoBehaviour
{
    public bool colliding;
    public Vector3 myposx;
    public Vector3 otherposx;
    public Vector3 myHeightPosz;
    public Vector3 otherHeightPosz;
    public float myHeightintz;
    public float otherHeightintz;
    public float myintposx;
    public float otherintposx;
    public bool IwillMove;
   


    private void Awake()
    {

        IwillMove = false;
        
    }

    

    public void OnCollisionEnter(Collision collision)

     {

       /* Debug.Log("Colliding");
        otherposx = collision.collider.gameObject.transform.position;
        otherintposx = otherposx.x;
        myposx = transform.position;
        myintposx = myposx.x;
        myHeightPosz = transform.position;
        myHeightintz = myHeightPosz.z;
        otherHeightPosz = collision.collider.transform.position;
        otherHeightintz = otherHeightPosz.z;



        if (myintposx > otherintposx)

        {
            if (collision.gameObject.transform.parent.transform.parent.transform.parent.GetComponent<LooseLine>().Imoved == false)
            {

                IwillMove = true;

            }

            else if (collision.gameObject.transform.parent.transform.parent.transform.parent.GetComponent<LooseLine>().Imoved == true)

            {
                IwillMove = false;

            }
      



        }
       */
      


    }

    public void OnCollisionExit(Collision collision)
    {


        IwillMove = false;



      


    }


    public void OnCollisionStay(Collision collision)

    {


      


    }







}
