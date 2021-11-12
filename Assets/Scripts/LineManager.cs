using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public GameObject Starter;
    public GameObject StarterTarget;
    public GameObject End;
    public GameObject EndTarget;

    
    
  

    // Update is called once per frame
    void Update()
    {
        Starter.transform.position = StarterTarget.transform.position;
        End.transform.position = EndTarget.transform.position;



    }

    
}
