using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveBack : MonoBehaviour
{
    
    public GameObject MainCam;
    public GameObject MainCanvas;
    public GameObject ExitBtn;
    public GameObject LoadingPanel;
    public GameObject locksButton;
    public GameObject WeightButton;
    public GameObject LocationButton;
    public GameObject DangerousGoodsBtn;
    float rotationSpeed = 4f;
    public GameObject target;
    public static float smoothTime = 0.9f;
    public static Vector3 velocity = Vector3.zero;
    public GameObject OriginalCamPos;



    public void Update()
        {


           // Vector3 targetPosition = Raycast.hit.transform.TransformPoint(new Vector3(0.019f, 0.009f, 0.0099f)); // This points the cam at the target object, the last figure is height, the middle figure is left to right, 
            MainCam.transform.position = Vector3.SmoothDamp(MainCam.transform.position,OriginalCamPos.transform.position, ref velocity, smoothTime);
           MainCam.transform.rotation = Quaternion.Slerp(MainCam.transform.rotation, OriginalCamPos.transform.rotation, rotationSpeed * Time.deltaTime); // this sets the rotation of the moving camera
            ExitBtn.SetActive(true);

        }







    
}
