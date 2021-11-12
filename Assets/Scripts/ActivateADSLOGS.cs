using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateADSLOGS : MonoBehaviour
{
    public GameObject ADStext;
    public GameObject LogstextR;
    public GameObject LogstextL;
    public GameObject TDPtext;
    public GameObject TDPs;


    public GameObject ADS1;
    public GameObject ADS2;
    public GameObject ADS3;
    public GameObject ADS4;
    public GameObject ADS5;
    public GameObject ADS6;
    public GameObject ADS7;
    public GameObject ADS8;
    public GameObject ADS9;
    public GameObject ADS10;
    public GameObject ADS11;

    public GameObject logs1L;
    public GameObject logs1R;
    public GameObject logs2L;
    public GameObject logs2R;
    public GameObject logs3L;
    public GameObject logs3R;
    public GameObject logs4L;
    public GameObject logs4R;
    public GameObject logs5L;
    public GameObject logs5R;
    public GameObject logs6L;
    public GameObject logs6R;
    public GameObject logs7L;
    public GameObject logs7R;
    public GameObject logs8L;
    public GameObject logs8R;
    public GameObject logs9L;
    public GameObject logs9R;

    [SerializeField]
    public static bool ADSbool;
   [SerializeField]
    public static bool LOGSbool;
    [SerializeField]
    public static bool TDPbool;

    public Image circleADS;
    public Image circleLOGS;
    public Image circleFLAT;

    public void Awake()
    {
        circleADS.GetComponent<Image>().color = Color.green;
        circleLOGS.GetComponent<Image>().color = Color.green;
        ADSbool = true;
        LOGSbool = true;



    }




    public void ActivateADS()
    {
        ADSbool = !ADSbool;


        if (ADSbool == true)
        {
            if (LogstextR.activeSelf == false)
            {


                ADStext.SetActive(true);

            }

            else
            {
                ADStext.SetActive(true);
                ADStext.transform.localPosition = new Vector3(-21.84467f, 0.08f, 5.21f);
                circleADS.GetComponent<Image>().color = Color.green;


            }


        }

        else
        {

            ADStext.SetActive(false);
            circleADS.GetComponent<Image>().color = Color.white;

        }

        if (ADS1.tag == "empty" && ADS1.activeSelf == true)
        {

            ADS1.SetActive(false);
        }

        else
        {

            ADS1.SetActive(true);
        }


        if (ADS2.tag == "empty" && ADS2.activeSelf == true)
        {

            ADS2.SetActive(false);
        }

        else
        {

            ADS2.SetActive(true);
        }



        if (ADS3.tag == "empty" && ADS3.activeSelf == true)
        {

            ADS3.SetActive(false);
        }
        else
        {

            ADS3.SetActive(true);
        }




        if (ADS4.tag == "empty" && ADS4.activeSelf == true)
        {

            ADS4.SetActive(false);
        }
        else
        {

            ADS4.SetActive(true);
        }



        if (ADS5.tag == "empty" && ADS5.activeSelf == true)
        {

            ADS5.SetActive(false);
        }
        else
        {

            ADS5.SetActive(true);
        }


        if (ADS6.tag == "empty" && ADS6.activeSelf == true)
        {

            ADS6.SetActive(false);
        }
        else
        {

            ADS6.SetActive(true);
        }

        if (ADS7.tag == "empty" && ADS7.activeSelf == true)
        {

            ADS7.SetActive(false);
        }
        else
        {

            ADS7.SetActive(true);
        }

        if (ADS8.tag == "empty" && ADS8.activeSelf == true)
        {

            ADS8.SetActive(false);
        }
        else
        {

            ADS8.SetActive(true);
        }

        if (ADS9.tag == "empty" && ADS9.activeSelf == true)
        {

            ADS9.SetActive(false);
        }
        else
        {

            ADS9.SetActive(true);
        }

        if (ADS10.tag == "empty" && ADS10.activeSelf == true)
        {

            ADS10.SetActive(false);
        }
        else
        {

            ADS10.SetActive(true);
        }

        if (ADS11.tag == "empty" && ADS11.activeSelf == true)
        {

            ADS11.SetActive(false);
        }
        else
        {

            ADS11.SetActive(true);
        }

    }




    public void activateLOGs()


    {

        LOGSbool = !LOGSbool;



        if (LOGSbool == true)
        {

            if (ADStext.activeSelf == true)

            {

                LogstextR.SetActive(true);
                circleLOGS.GetComponent<Image>().color = Color.green;



            }

            else if (ADStext.activeSelf == false)

            {

                LogstextR.SetActive(true);
                LogstextR.transform.localPosition = new Vector3(-11.33704f, 0.132f, 5.78f);

            }

            if (TDPtext.activeSelf == true)
            {
                LogstextL.SetActive(true);
                LogstextL.transform.localPosition = new Vector3(-33.98425f, 0.17f, 13.54f);
            }

            else if (TDPtext.activeSelf == false)
            {
                LogstextL.SetActive(true);
                LogstextL.transform.localPosition = new Vector3(-33.98425f, 0.17f, 12.36f);

            }

        }


        else
        {
            LogstextR.SetActive(false);
            LogstextL.SetActive(false);
            circleLOGS.GetComponent<Image>().color = Color.white;

        }




        if (logs1L.tag == "empty" && logs1L.activeSelf == true)
        {

            logs1L.SetActive(false);
        }
        else
        {

            logs1L.SetActive(true);
        }

        if (logs1R.tag == "empty" && logs1R.activeSelf == true)
        {

            logs1R.SetActive(false);
        }
        else
        {

            logs1R.SetActive(true);
        }

        if (logs2L.tag == "empty" && logs2L.activeSelf == true)
        {

            logs2L.SetActive(false);
        }
        else
        {

            logs2L.SetActive(true);
        }

        if (logs2R.tag == "empty" && logs2R.activeSelf == true)
        {

            logs2R.SetActive(false);
        }
        else
        {

            logs2R.SetActive(true);
        }

        if (logs3L.tag == "empty" && logs3L.activeSelf == true)
        {

            logs3L.SetActive(false);
        }
        else
        {

            logs3L.SetActive(true);
        }

        if (logs3R.tag == "empty" && logs3R.activeSelf == true)
        {

            logs3R.SetActive(false);
        }
        else
        {

            logs3R.SetActive(true);
        }

        if (logs4L.tag == "empty" && logs4L.activeSelf == true)
        {

            logs4L.SetActive(false);
        }
        else
        {

            logs4L.SetActive(true);
        }

        if (logs4R.tag == "empty" && logs4R.activeSelf == true)
        {

            logs4R.SetActive(false);
        }
        else
        {

            logs4R.SetActive(true);
        }

        if (logs5L.tag == "empty" && logs5L.activeSelf == true)
        {

            logs5L.SetActive(false);
        }
        else
        {

            logs5L.SetActive(true);
        }

        if (logs5R.tag == "empty" && logs5R.activeSelf == true)
        {

            logs5R.SetActive(false);
        }
        else
        {

            logs5R.SetActive(true);
        }

        if (logs6L.tag == "empty" && logs6L.activeSelf == true)
        {

            logs6L.SetActive(false);
        }
        else
        {

            logs6L.SetActive(true);
        }

        if (logs6R.tag == "empty" && logs6R.activeSelf == true)
        {

            logs6R.SetActive(false);
        }
        else
        {

            logs6R.SetActive(true);
        }

        if (logs7L.tag == "empty" && logs7L.activeSelf == true)
        {

            logs7L.SetActive(false);
        }
        else
        {

            logs7L.SetActive(true);
        }

        if (logs7R.tag == "empty" && logs7R.activeSelf == true)
        {

            logs7R.SetActive(false);
        }
        else
        {

            logs7R.SetActive(true);
        }

        if (logs8L.tag == "empty" && logs8L.activeSelf == true)
        {

            logs8L.SetActive(false);
        }
        else
        {

            logs8L.SetActive(true);
        }

        if (logs8R.tag == "empty" && logs8R.activeSelf == true)
        {

            logs8R.SetActive(false);
        }
        else
        {

            logs8R.SetActive(true);
        }

        if (logs9L.tag == "empty" && logs9L.activeSelf == true)
        {

            logs9L.SetActive(false);
        }
        else
        {

            logs9L.SetActive(true);
        }

        if (logs9R.tag == "empty" && logs9R.activeSelf == true)
        {

            logs9R.SetActive(false);
        }
        else
        {

            logs9R.SetActive(true);
        }









    }

    public void ActivateFlatfloor()
    {
        TDPbool = !TDPbool;


        if (TDPbool == true)

           
        {
            TDPs.SetActive(true);

            if (LogstextL.activeSelf == true)

            {
                TDPtext.SetActive(true);
                TDPtext.transform.localPosition = new Vector3(-22.51689f, 0.18f, 13.57f);
                circleFLAT.GetComponent<Image>().color = Color.green;



            }

            else if (LogstextL.activeSelf == false)

            {
                TDPtext.SetActive(true);
                TDPtext.transform.localPosition = new Vector3(-22.51689f, 0.18f, 12.47f);


            }
        }

        else {


            TDPtext.SetActive(false);
            circleFLAT.GetComponent<Image>().color = Color.white;

            TDPs.SetActive(false);
        }
    }



}









