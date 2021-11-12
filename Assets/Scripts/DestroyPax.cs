using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPax : MonoBehaviour
{
    public  bool PaxWeight200;
    public  bool PaxWeight210;
    public  bool PaxWeight230;
    public  bool PaxWeight250;
    public  decimal ThisPassengerWt;
    public decimal ThisPassengerMoment;

     void Awake()
    {
        ThisPassengerWt = LoadPax.PaxWeight;
        Debug.Log("ThisPassengerWt = " + ThisPassengerWt);



    }



    private void OnMouseDown()
    {
        if (PassengerBtn.bool1 == false)
        {
            if (PaxWeight200 == true)
            {
                LoadPax.PaxWeight = 200;



            }

            if (PaxWeight210 == true)
            {
                LoadPax.PaxWeight = 210;


            }

            if (PaxWeight230 == true)
            {

                LoadPax.PaxWeight = 230;

            }

            if (PaxWeight250 == true)
            {

                LoadPax.PaxWeight = 250;

            }



            Payload.PaxNumber = Payload.PaxNumber - 1;
            Payload.TotalPaxWt = Payload.TotalPaxWt - ThisPassengerWt;
            Payload.TotalPayloadWt -= ThisPassengerWt;
            Payload.Moment -= ThisPassengerMoment;

            Debug.Log("Pax Wt = " + ThisPassengerWt);


            Destroy(gameObject);

        }

        else return;
      
            
            


    }






}
