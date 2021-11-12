
using System.Collections;
using UnityEngine;

class DragDrop : MonoBehaviour
{
    public GameObject mainfloorblock;


    private bool dragging = false;
    private float distance;

    public bool loaded;




    void OnMouseDown()


    {




        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;

    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()


    {



        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            rayPoint.x = Mathf.Clamp(rayPoint.x, -13.4f, 11.4f);
            rayPoint.z = Mathf.Clamp(rayPoint.z, -2.1f, 2.1f);
            rayPoint.y = Mathf.Clamp(rayPoint.y, 0.1f, 0.1f);

            transform.position = rayPoint;

        }


    }



}









    

       

    