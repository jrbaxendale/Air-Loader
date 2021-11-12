
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassengerBtn : MonoBehaviour
{

    public Material Black;
    public Material White;
    public GameObject SideWallSeats;
    public GameObject LOGS;
    public GameObject ADS;
    public Material LOGSColour;
    public Material ADSColour;
    public GameObject CLseatPanel;
    public GameObject PaxWtBtns;
    public Image circle;

    public static bool bool1;


    private void Start()
    {

       
        bool1 = true;
     
    }

    public void SeatColourChange()
    {
        Debug.Log("paxcolour");

        if (bool1 == true)


        {
           
            Renderer[] SideWallSeatsArray = SideWallSeats.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in SideWallSeatsArray)
            {
                foreach (Material m in r.materials)
                {
                    if (r.transform.name.Contains("SEAT")) 
                    {
                        r.material = White;
                        r.GetComponent<BoxCollider>().enabled = enabled;
                    }
                }
            }


            Transform[] ADSarray = ADS.GetComponentsInChildren<Transform>();

            foreach (Transform e in ADSarray)
            {

                if (e.tag == "empty")
                {
                    e.GetComponent<Renderer>().material = Black;

                }

 
            }
          

            Transform[] LOGSarray = LOGS.GetComponentsInChildren<Transform>();

            foreach (Transform f in LOGSarray)
            {

                if (f.tag == "empty")
                {
                    f.GetComponent<Renderer>().material = Black;

                }


            }
            bool1 = false;

            CLseatPanel.SetActive(true);
            PaxWtBtns.SetActive(true);
            circle.GetComponent<Image>().color = Color.green;


        }


        else
        {
            circle.GetComponent<Image>().color = Color.white;


            Renderer[] SideWallSeatsArray = SideWallSeats.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in SideWallSeatsArray)
            {
                foreach (Material m in r.materials)
                {
                    if (r.transform.name.Contains("SEAT"))
                    {
                        r.material = Black;
                        r.GetComponent<BoxCollider>().enabled = !enabled;

                    }
                }
            }


            Transform[] ADSarray = ADS.GetComponentsInChildren<Transform>();

            foreach (Transform e in ADSarray)
            {

                if (e.tag == "empty")
                {
                    e.GetComponent<Renderer>().material = ADSColour;

                }


            }
           

            Transform[] LOGSarray = LOGS.GetComponentsInChildren<Transform>();

            foreach (Transform f in LOGSarray)
            {

                if (f.tag == "empty")
                {
                    f.GetComponent<Renderer>().material = LOGSColour;

                }


            }

            CLseatPanel.SetActive(false);
            PaxWtBtns.SetActive(false);
            circle.GetComponent<Image>().color = Color.white;
            bool1 = true;

        }



    }

   


    public void ClosethePaxPanels()
  {
        {


            Renderer[] SideWallSeatsArray = SideWallSeats.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in SideWallSeatsArray)
            {
                foreach (Material m in r.materials)
                {
                    if (r.transform.name.Contains("SEAT"))
                    {
                        r.material = Black;
                        r.GetComponent<BoxCollider>().enabled = !enabled;

                    }
                }
            }


            Transform[] ADSarray = ADS.GetComponentsInChildren<Transform>();

            foreach (Transform e in ADSarray)
            {

                if (e.tag == "empty")
                {
                    e.GetComponent<Renderer>().material = ADSColour;

                }


            }


            Transform[] LOGSarray = LOGS.GetComponentsInChildren<Transform>();

            foreach (Transform f in LOGSarray)
            {

                if (f.tag == "empty")
                {
                    f.GetComponent<Renderer>().material = LOGSColour;

                }


            }

            CLseatPanel.SetActive(false);
            PaxWtBtns.SetActive(false);
            circle.GetComponent<Image>().color = Color.white;
            bool1 = true;

        }


    }









}







