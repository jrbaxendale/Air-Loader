
using System.Collections;
using UnityEngine;

class DragDrop : MonoBehaviour
{
#pragma warning disable CS0649 // Field 'DragDrop.mainfloorblock' is never assigned to, and will always have its default value null
    public GameObject mainfloorblock;
#pragma warning restore CS0649 // Field 'DragDrop.mainfloorblock' is never assigned to, and will always have its default value null


    private bool dragging = false;
    private float distance;

#pragma warning disable CS0649 // Field 'DragDrop.loaded' is never assigned to, and will always have its default value false
    public bool loaded;
#pragma warning restore CS0649 // Field 'DragDrop.loaded' is never assigned to, and will always have its default value false




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









    

       

    