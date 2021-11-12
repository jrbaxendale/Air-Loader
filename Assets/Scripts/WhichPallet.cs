using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichPallet : MonoBehaviour
{
    
    public GameObject Single;
    public GameObject Double;
    public GameObject Triple;
    public GameObject Quad;
 
    public bool Bool1;
    public bool Bool2;
    public bool Bool3;
    public bool Bool4;
       
 
    



    public void SingleACPopen()
    {
        if (Bool1 == false)
        {

            Single.SetActive(true);
            DlbClose();
            TripleClose();
            QuadClose();


       
        
            Bool1 = true;
        }

        else
        {

            SingleClose();
            
          

        }



    }


public void SingleClose()
    {
        Single.SetActive(false);
     

;
       
        Bool1 = false;

    }




    public void DoubleACPopen()
    {
        if (Bool2 == false)

        {


            SingleClose();
            Double.SetActive(true);
            TripleClose();
            QuadClose();


            
        
           
            Bool2 = true;
        }

        else

        {

            DlbClose();
           
        }

    }

    public void DlbClose()
    {
        
        Double.SetActive(false);
      


       
        Bool2 = false;
    }












    public void TripleACPopen()
    {
        if (Bool3 == false)
        {

            SingleClose();
            DlbClose();
            Triple.SetActive(true);
            QuadClose();


            
       
          
            Bool3 = true;

        }

        else

        {
            TripleClose();
            
        }
     
    }

    public void TripleClose()
    {

        
        Triple.SetActive(false);
      


    
       
        Bool3 = false;
    }








    public void QuadACP()
    {
        if (Bool4 == false)
        {


            SingleClose();
            DlbClose();
            TripleClose();

        Quad.SetActive(true);


      
 
        Bool4 = true;

        }


        else

        {


            QuadClose();
            
        }

    }

    public void QuadClose()
    {
       
        Quad.SetActive(false);


      
        Bool4 = false;
    }

    public void SinglePanelCloseAll()
    {
        
        {

            SingleClose();
            DlbClose();
            TripleClose();
            QuadClose();





        }

       



    }








}

