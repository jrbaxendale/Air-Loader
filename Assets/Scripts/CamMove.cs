using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMove : MonoBehaviour
{

    public GameObject cam;
    public GameObject MainCam;
    public GameObject MainCanvas;
    public GameObject ExitBtn;
    public GameObject LoadingPanel;
    public GameObject locksButton;
    public GameObject WeightButton;
    public GameObject LocationButton;
    public GameObject DangerousGoodsBtn;
#pragma warning disable CS0414 // The field 'CamMove.rotationSpeed' is assigned but its value is never used
    float rotationSpeed = 4f;
#pragma warning restore CS0414 // The field 'CamMove.rotationSpeed' is assigned but its value is never used
    public GameObject target;
    public static float smoothTime = 0.9f;
    public static Vector3 velocity = Vector3.zero;
    public GameObject OriginalCamPos;
    public Transform[] ThePath;


  // private void OnDrawGizmos()
  //  {
   //     iTween.DrawPath(ThePath, Color.green);
   // }


    //public void Move()
    //{
     //   iTween.PutOnPath(MainCam, ThePath, 2);

  //  } 

   

    public void Exit()
    {
       
        ExitBtn.SetActive(false);
        LoadingPanel.SetActive(false);
        Vector3 targetPosition = new Vector3(0, 0, 0);
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, targetPosition, ref velocity, Time.deltaTime);
        cam.gameObject.SetActive(false);
        MainCam.gameObject.SetActive(true);
        MainCanvas.SetActive(true);

    }

    public void CheckACPbuttons()
    {

        if (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().Locks == true)
        {
            locksButton.GetComponent<Button>().interactable = false;


        }
          
        else if (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().Locks == false)
        {

           locksButton.transform.GetComponent<Button>().interactable = true;

        }



        if (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().weight == true)
        {
            WeightButton.transform.GetComponent<Button>().interactable = false;


        }

        else if (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().weight == false)
        {
            WeightButton.transform.GetComponent<Button>().interactable = true;


        }


        if (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().location == true)
        {
           LocationButton.transform.GetComponent<Button>().interactable = false;


        }

        else if (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().location == false)
        {
            LocationButton.transform.GetComponent<Button>().interactable = true;


        }

        if (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().dg == true)
        {
            DangerousGoodsBtn.transform.GetComponent<Button>().interactable = false;

        }

       else if (Raycast.hit.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<ACPpayload>().dg == false)
        {
            DangerousGoodsBtn.transform.GetComponent<Button>().interactable = true;

        }

    }





}
