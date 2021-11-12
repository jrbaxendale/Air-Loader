using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseLine : MonoBehaviour
{
    public LineRenderer Line;
    public GameObject Start;
    public GameObject End;
    public GameObject EdgeCol;
    public GameObject FS0;
    public Vector3[] m_Points;

    public Vector3[] LinePositions;
    public Vector2 Startpoint;
    public Vector2 Endpoint;
    public Vector2[] V2pointsArray;
    public Vector3 raystart;
    public static RaycastHit hit;
    public static RaycastHit hita;
    public bool rayhit;
    public Vector3 Pos;
    public float i;
    public bool collision;
    public bool hitting;
    public bool shootingleft;
    public bool shootingright;
    public bool Imoved;





    private void Awake()
    {
        hitting = false;
        Line = GetComponent<LineRenderer>();
        Line.positionCount = 2;

        Line.startWidth = 0.04f;
        Line.endWidth = 0.04f;
        Line.startColor = Color.red;
        Line.endColor = Color.red;

        LinePositions = new Vector3[Line.positionCount];
        Pos = new Vector3(0, 0, 0);
        FS0 = GameObject.Find("FlightStationZero");

        End.transform.position = new Vector3(transform.position.x, transform.position.y, FS0.transform.position.z - 3);


    }




    private void Update() // this function will send out a ray from the tpu and if it collides with something it will go around it.
    {
        raystart = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Physics.Raycast(raystart, Vector3.back, out hit, Mathf.Infinity);


        if (hit.collider == null) // no collision means it will just draw a straight line

        {
            hitting = false;
            Line.positionCount = 2;
            Line.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z)); // the line starts at the tpu
            Line.SetPosition(1, new Vector3(transform.position.x, transform.position.y, FS0.transform.position.z - 3)); // the line ends here

            if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == false)


            {

                End.transform.position = new Vector3(transform.position.x, transform.position.y, FS0.transform.position.z - 3);
                Imoved = false;

            }

            else if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == true)

            {
                End.transform.position = new Vector3(transform.position.x, transform.position.y, FS0.transform.position.z - 4.2f);
                Imoved = true;

            }



        }

        else if (hit.collider != null) // this detects that something has collided

        {
            hitting = true;
            Line.positionCount = 4;
            Pos = hit.transform.position;
            Line.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z)); // the line starts at the tpu
            Line.SetPosition(1, new Vector3(transform.position.x, transform.position.y, Pos.z + 1)); // this is the end of the first line which is near to the collision point

            if (hit.collider.transform.gameObject.GetComponent<LooseLine>().hitting == false)

            {

                for (i = 0.5f; i < 1000; i++) // this loop will continue to extend the 2nd line from left to right until it can get past a collision item on its right.

                {
                    
                    Line.SetPosition(2, new Vector3(Pos.x + i, Pos.y, Pos.z + 1)); // this is an incremental position along the x axis
                    Vector3 Posb = new Vector3(Pos.x + i, Pos.y, Pos.z + 1); // get a position slightly right from the hit
                    Physics.Raycast(Posb, Vector3.back, out hit, Mathf.Infinity); // shoot a ray downwards from the above slightly right position

                    if (hit.collider == null)
                    {
                        shootingright = true;
                        shootingleft = false;
                        Vector3 posr = Line.GetPosition(2);
                        Line.SetPosition(3, new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3));
                        i = 2000;

                        if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == false)

                        {

                            End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3);
                            Imoved = false;

                        }

                        else if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == true)

                        {
                            End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 4.2f);
                            Imoved = true;
                        }

                    }



                    else if (hit.collider != null)
                    {

                        Posb = new Vector3(Pos.x - i, Pos.y, Pos.z + 1); // get a position slightly right from the hit
                        Physics.Raycast(Posb, Vector3.back, out hit, Mathf.Infinity); // shoot a ray downwards from the above slightly right position
                        shootingleft = true;
                        shootingright = false;

                        if (hit.collider == null)
                        {

                            Vector3 posr = Line.GetPosition(2);
                            Line.SetPosition(3, new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3));
                            i = 2000;

                            if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == false)

                            {

                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3);
                                Imoved = false;

                            }

                            else if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == true)

                            {
                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 4.2f);
                                Imoved = true;
                            }
                        }


                    }




                }


            }

            else if (hit.collider.transform.gameObject.GetComponent<LooseLine>().hitting == true)

            {
                if (hit.collider.transform.gameObject.GetComponent<LooseLine>().shootingleft == true)
                {




                    for (i = 0.5f; i < 1000; i++)

                    {
                       
                        Line.SetPosition(2, new Vector3(Pos.x + i, Pos.y, Pos.z + 1)); // this is an incremental position along the x axis
                        Vector3 Posb = new Vector3(Pos.x + i, Pos.y, Pos.z + 1);
                        Physics.Raycast(Posb, Vector3.back, out hit, Mathf.Infinity);

                        if (hit.collider == null)
                        {

                            shootingright = true;
                            shootingleft = false;
                            Vector3 posr = Line.GetPosition(2);
                            Line.SetPosition(3, new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3));
                            i = 2000;

                            if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == false)

                            {

                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3);

                            }

                            else if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == true)

                            {
                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 4.2f);

                            }



                        }

                        else if (hit.collider != null)
                        {

                            Posb = new Vector3(Pos.x - i, Pos.y, Pos.z + 1); // get a position slightly right from the hit
                            Physics.Raycast(Posb, Vector3.back, out hit, Mathf.Infinity); // shoot a ray downwards from the above slightly right position
                            shootingleft = true;
                            shootingright = false;
                            Vector3 posr = Line.GetPosition(2);
                            Line.SetPosition(3, new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3));
                            i = 2000;

                            if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == false)

                            {

                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3);
                                Imoved = false;

                            }

                            else if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == true)

                            {
                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 4.2f);
                                Imoved = true;
                            }

                        }



                    }



                }

                else if (hit.collider.transform.gameObject.GetComponent<LooseLine>().shootingright == true)


                {
                    for (i = 0.5f; i < 1000; i++)

                    {
                     
                        Line.SetPosition(2, new Vector3(Pos.x - i, Pos.y, Pos.z + 1)); // this is an incremental position along the x axis
                        Vector3 Posb = new Vector3(Pos.x + i, Pos.y, Pos.z + 1);
                        Physics.Raycast(Posb, Vector3.back, out hit, Mathf.Infinity);

                        if (hit.collider == null)
                        {

                            shootingright = false;
                            shootingleft = true;
                            Vector3 posr = Line.GetPosition(2);
                            Line.SetPosition(3, new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3));
                            i = 2000;

                            if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == false)

                            {

                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3);

                            }

                            else if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == true)

                            {
                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 4.2f);

                            }



                        }

                        else if (hit.collider != null)
                        {

                            Posb = new Vector3(Pos.x + i, Pos.y, Pos.z + 1); // get a position slightly right from the hit
                            Physics.Raycast(Posb, Vector3.back, out hit, Mathf.Infinity); // shoot a ray downwards from the above slightly right position
                            shootingleft = true;
                            shootingright = false;
                            Vector3 posr = Line.GetPosition(2);
                            Line.SetPosition(3, new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3));
                            i = 2000;

                            if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == false)

                            {

                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 3);
                                Imoved = false;

                            }

                            else if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<TPUpanelCols>().IwillMove == true)

                            {
                                End.transform.position = new Vector3(posr.x, Pos.y, FS0.transform.position.z - 4.2f);
                                Imoved = true;
                            }

                        }



                    }




                }

            }

        }

    }
}



















