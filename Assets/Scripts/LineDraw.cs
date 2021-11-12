using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
   public LineRenderer Line;
   public GameObject Start;
   public GameObject End;



    private void Awake()
    {
      
        Line = GetComponent<LineRenderer>();
        Line.positionCount = 2;
      
        Line.startWidth = 1;
        Line.endWidth = 1;
        Line.startColor = Color.red;
        Line.endColor = Color.red;


    }

    private void Update()
    {
        Line.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        Line.SetPosition(1, new Vector3(End.transform.position.x, End.transform.position.y, End.transform.position.z));

    }
}
