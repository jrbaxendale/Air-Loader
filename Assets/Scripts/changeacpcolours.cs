using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeacpcolours : MonoBehaviour
{
    public Material lightgrey;
    

    public void Lightgrey()
    {
        
           
            {
              
                GameObject[] objects = GameObject.FindGameObjectsWithTag("LOGS");
                foreach (GameObject go in objects)
                {
                    Renderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
                    foreach (Renderer r in renderers)
                    {
                        foreach (Material m in r.materials)
                        {
                        r.material = lightgrey;
                        }
                    }
                }
            }



        }


}










