using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgMoveButtons : MonoBehaviour
{
    public GameObject DgItem;

    public void MoveLeft()
    {
        if (Input.GetMouseButton(0))
        {
            DgItem = DangerousGoods.DgItem;
            Debug.Log("Left Button Pressed");

            DgItem.transform.position = new Vector3(DgItem.transform.position.x - 1, DgItem.transform.position.y, DgItem.transform.position.z);


        }


    }

    public void MoveRight()
    {
        if (Input.GetMouseButton(0))
        {
            DgItem = DangerousGoods.DgItem;
            Debug.Log("Left Button Pressed");

            DgItem.transform.position = new Vector3(DgItem.transform.position.x + 1, DgItem.transform.position.y, DgItem.transform.position.z);


        }


    }

    public void MoveDown()
    {
        if (Input.GetMouseButton(0))
        {
            DgItem = DangerousGoods.DgItem;
            Debug.Log("Left Button Pressed");

            DgItem.transform.position = new Vector3(DgItem.transform.position.x , DgItem.transform.position.y - 1, DgItem.transform.position.z);


        }


    }

    public void MoveUp()
    {
        if (Input.GetMouseButton(0))
        {
            DgItem = DangerousGoods.DgItem;
            Debug.Log("Left Button Pressed");

            DgItem.transform.position = new Vector3(DgItem.transform.position.x, DgItem.transform.position.y + 1, DgItem.transform.position.z);


        }


    }


}


