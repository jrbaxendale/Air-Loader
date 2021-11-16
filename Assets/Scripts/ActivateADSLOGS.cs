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
    public List<GameObject> ADSarray;

    public static bool ADSArrayBool;
    public Material Invisible;
    public List<GameObject> LOGSarray;
    [SerializeField]
    public static bool LOGSarrayBool;
    [SerializeField]
    public static bool ADStextLower;
    [SerializeField]
    public static bool LOGStextLower;

    public void Awake()
    {
        circleADS.GetComponent<Image>().color = Color.green;
        circleLOGS.GetComponent<Image>().color = Color.green;
        ADSbool = true;
        ADSArrayBool = true;
        LOGSarrayBool = true;
        LOGSbool = true;
        ADSarray = new List<GameObject>();
        ADSarray.Add(ADS1);
        ADSarray.Add(ADS2);
        ADSarray.Add(ADS3);
        ADSarray.Add(ADS4);
        ADSarray.Add(ADS5);
        ADSarray.Add(ADS6);
        ADSarray.Add(ADS7);
        ADSarray.Add(ADS8);
        ADSarray.Add(ADS9);
        ADSarray.Add(ADS10);
        ADSarray.Add(ADS11);

        LOGSarray = new List<GameObject>();
        LOGSarray.Add(logs1L);
        LOGSarray.Add(logs2L);
        LOGSarray.Add(logs3L);
        LOGSarray.Add(logs4L);
        LOGSarray.Add(logs5L);
        LOGSarray.Add(logs6L);
        LOGSarray.Add(logs7L);
        LOGSarray.Add(logs8L);
        LOGSarray.Add(logs9L);
        LOGSarray.Add(logs1R);
        LOGSarray.Add(logs2R);
        LOGSarray.Add(logs3R);
        LOGSarray.Add(logs4R);
        LOGSarray.Add(logs5R);
        LOGSarray.Add(logs6R);
        LOGSarray.Add(logs7R);
        LOGSarray.Add(logs8R);
        LOGSarray.Add(logs9R);

        LOGStextLower = false;
        ADStextLower = true;
    }

    public void ActivateLOGSarray()


    {
        if (LOGSarrayBool == false)

        {
            LOGSarrayBool = true;
            LOGSbool = true;
            circleLOGS.GetComponent<Image>().color = Color.green;
            LogstextR.SetActive(true);
            LogstextL.SetActive(true);

            if (ADStext.activeSelf == false)

            {
                LogstextR.transform.localPosition = new Vector3(-11.33704f, 0.132f, 5.78f);
                LOGStextLower = true;
            }

            if (ADStext.activeSelf)
            {

                if (ADStextLower)

                {

                    LogstextR.transform.localPosition = new Vector3(-11.33704f, 0.132f, 4.68f);
                    LOGStextLower = false;

                }

                else if (ADStextLower == false)

                {
                    LogstextR.transform.localPosition = new Vector3(-11.33704f, 0.132f, 5.78f);
                    LOGStextLower = true;
                }
            }




            if (TDPtext.activeSelf)
            {
                LogstextL.transform.localPosition = new Vector3(-33.98425f, 0.17f, 13.54f);
            }

            if (TDPtext.activeSelf == false)
            {
                LogstextL.transform.localPosition = new Vector3(-33.98425f, 0.17f, 12.36f);
            }


            foreach (GameObject g in LOGSarray)

            {
                if (g.transform.GetChild(0).transform.childCount == 0)

                {

                    g.SetActive(true);

                }

                else

                {

                    g.SetActive(true);
                    g.GetComponent<Renderer>().material = Invisible;
                    g.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = !enabled;
                }
            }
        }



        else if (LOGSarrayBool)

        {
            LOGSarrayBool = false;
            LOGSbool = false;
            circleLOGS.GetComponent<Image>().color = Color.white;
            LogstextR.SetActive(false);
            LOGStextLower = false;
            LogstextL.SetActive(false);

            if (ADSbool == true && ADStextLower == false)

            {
                ADStext.transform.localPosition = new Vector3(-21.84467f, 0.08f, 5.64f);
                ADStextLower = true;
            }


            foreach (GameObject g in LOGSarray)
            {
                if (g.transform.GetChild(0).transform.childCount == 0)

                {

                    g.SetActive(false);

                }

                else

                {

                    g.SetActive(true);
                    g.GetComponent<Renderer>().material = Invisible;
                    g.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = !enabled;
                }



            }
        }



    }

    public void ActivateArrayADS()
    {
        if (ADSArrayBool == false)

        {

            ADSArrayBool = true;
            ADSbool = true;
            circleADS.GetComponent<Image>().color = Color.green;
            ADStext.SetActive(true);
           

            if (LogstextR.activeSelf)

            {
               if (LOGStextLower)

                {
                    ADStext.transform.localPosition = new Vector3(-21.84467f, 0.08f, 4.63f);
                    ADStextLower = false;
                }

               else if (LOGStextLower == false)

               {
                   ADStext.transform.localPosition = new Vector3(-21.84467f, 0.08f, 5.64f);
                   ADStextLower = true;
               }
            }

            if (LogstextR.activeSelf == false)

            {
                ADStext.transform.localPosition = new Vector3(-21.84467f, 0.08f, 5.64f);
                ADStextLower = true;
            }

            foreach (GameObject g in ADSarray)
            {
                if (g.transform.GetChild(0).transform.childCount == 0)

                {

                    g.SetActive(true);

                }

                else 

                {

                    g.SetActive(true);
                    g.GetComponent<Renderer>().material = Invisible;
                    g.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = !enabled;
                }
            }
        }

        else if (ADSArrayBool)

        {
            ADSArrayBool = false;
            ADSbool = false;
            circleADS.GetComponent<Image>().color = Color.white;
            ADStext.SetActive(false);
            ADStextLower = false;

            if (LOGSbool== true && LOGStextLower == false)

            {
                LogstextR.transform.localPosition = new Vector3(-11.33704f, 0.132f, 5.78f);
                LOGStextLower = true;
            }


            foreach (GameObject g in ADSarray)
            {
                if (g.transform.GetChild(0).transform.childCount == 0)

                {

                    g.SetActive(false);

                }

                else

                {

                    g.SetActive(true);
                    g.GetComponent<Renderer>().material = Invisible;
                    g.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = !enabled;
                }

                
                
            }
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









