using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PalletArray : MonoBehaviour
{


    public static List<GameObject> Palletarray;

    public Material BlueSeeThrough;
    public Material BlueNormal;

    public Material PalletChecked;
    public Material GreenSeeThrough;
    public TextMeshProUGUI NumberDisplay;

    private void Awake()
    {
        Palletarray = new List<GameObject>();
        BlueSeeThrough = (Material)Resources.Load("Materials/BlueSeeThrough", typeof(Material));
        GreenSeeThrough = (Material)Resources.Load("Materials/GreenSeeThrough", typeof(Material));
        BlueNormal = (Material)Resources.Load("Materials/BlueNormal", typeof(Material));




    }

    public static void RemoveACPfromList(GameObject ThePallet)

    {
        Palletarray.Remove(ThePallet);
    }

    public static void AddACPtoList(GameObject ThePallet)

    {

        Palletarray.Add(ThePallet);
        Debug.Log("Pallet added to list" + ThePallet.name);


    }

    public void ChangeColourDark()

    {
        int i = Palletarray.Count;
        Debug.Log("PalletArray ===" + i);
        if (i >= 1)


            foreach (GameObject ACP in Palletarray)

            {

                Debug.Log("Pallet Array contents ===" + ACP.name);

                if (ACP.gameObject.GetComponent<ACPpayload>() != null) // this is for single pallets

                {


                    if (ACP.gameObject.GetComponent<ACPpayload>().Checked == true)

                    {


                        Debug.Log("ACP is Checked");

                        if (ACP.GetComponent<Renderer>() != null)

                        {

                            ACP.GetComponent<Renderer>().material = GreenSeeThrough;

                        }


                    }

                    else if (ACP.gameObject.GetComponent<ACPpayload>().Checked == false)

                    {
                        Debug.Log("ACP is not checked");

                        if (ACP.GetComponent<Renderer>() != null)
                        {

                            ACP.GetComponent<Renderer>().material = BlueSeeThrough;

                        }

                    }

                }


                else if (ACP.gameObject.GetComponent<ACP_PayloadDBL>() != null) // this for Double Pallets

                {

                    if (ACP.gameObject.GetComponent<ACP_PayloadDBL>().Checked == true)

                    {
                        if (ACP.GetComponent<Renderer>() != null)

                        {

                            Debug.Log("ACP is Checked");
                            Material[] mat = ACP.gameObject.GetComponent<Renderer>().materials;
                            mat[0] = GreenSeeThrough;
                            mat[1] = GreenSeeThrough;
                            ACP.gameObject.GetComponent<Renderer>().materials = mat;

                        }



                    }

                    else if (ACP.gameObject.GetComponent<ACP_PayloadDBL>().Checked == false)

                    {
                        Debug.Log("ACP is not checked");

                        if (ACP.GetComponent<Renderer>() != null)

                        {
                            Material[] mat = ACP.gameObject.GetComponent<Renderer>().materials;
                            mat[0] = BlueSeeThrough;
                            mat[1] = BlueSeeThrough;
                            ACP.gameObject.GetComponent<Renderer>().materials = mat;

                        }


                    }

                }

                else if (ACP.gameObject.GetComponent<ACP_PayloadTPL>() != null) // this for Double Pallets

                {

                    if (ACP.gameObject.GetComponent<ACP_PayloadTPL>().Checked == true)

                    {
                        if (ACP.GetComponent<Renderer>() != null)

                        {

                            Debug.Log("ACP is Checked");
                            Material[] mat = ACP.gameObject.GetComponent<Renderer>().materials;
                            mat[0] = GreenSeeThrough;
                            mat[1] = GreenSeeThrough;
                            mat[2] = GreenSeeThrough;
                            ACP.gameObject.GetComponent<Renderer>().materials = mat;

                        }



                    }

                    else if (ACP.gameObject.GetComponent<ACP_PayloadTPL>().Checked == false)

                    {
                        Debug.Log("ACP is not checked");

                        if (ACP.GetComponent<Renderer>() != null)

                        {
                            Material[] mat = ACP.gameObject.GetComponent<Renderer>().materials;
                            mat[0] = BlueSeeThrough;
                            mat[1] = BlueSeeThrough;
                            mat[2] = BlueSeeThrough;
                            ACP.gameObject.GetComponent<Renderer>().materials = mat;

                        }


                    }

                }
            }


    }






    public void ChangeColourNormal()


    {
        Debug.Log("ChangeColourNormal ran");

        int i = Palletarray.Count;
        Debug.Log("PalletArray ===" + i);

        if (i >= 1)



        {
            foreach (GameObject ACP in Palletarray)
            {

                Debug.Log("Pallet Array contents ===" + ACP.name);

                if (ACP.gameObject.GetComponent<ACPpayload>() != null)

                {
                    if (ACP.gameObject.GetComponent<ACPpayload>().Checked == true)


                    {
                        Debug.Log("ACP is Checked changecolournormal");

                        ACP.GetComponent<Renderer>().material = PalletChecked;

                    }

                    else if (ACP.gameObject.GetComponent<ACPpayload>().Checked == false)


                    {
                        Debug.Log("ACP is not checked changecolournormal");
                        ACP.GetComponent<Renderer>().material = BlueNormal;

                    }


                } // This is for single pallets



                else if (ACP.gameObject.GetComponent<ACP_PayloadDBL>() != null) // this is for double pallets

                {
                    if (ACP.gameObject.GetComponent<ACP_PayloadDBL>().Checked == true)

                    {

                        Debug.Log("ACP is Checked changecolournormal");
                        Material[] mat = ACP.gameObject.GetComponent<Renderer>().materials;
                        mat[0] = PalletChecked;
                        mat[1] = PalletChecked;
                        ACP.gameObject.GetComponent<Renderer>().materials = mat;
                        ACP.transform.parent.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = enabled;



                    }
                    else if (ACP.gameObject.GetComponent<ACP_PayloadDBL>().Checked == false)


                    {
                        Debug.Log("ACP is not checked changecolournormal");
                        Material[] mat = ACP.gameObject.GetComponent<Renderer>().materials;
                        mat[0] = BlueNormal;
                        mat[1] = BlueNormal;
                        ACP.gameObject.GetComponent<Renderer>().materials = mat;
                        ACP.transform.parent.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = enabled;


                    }

                }

                else if (ACP.gameObject.GetComponent<ACP_PayloadTPL>() != null) // this is for double pallets

                {
                    if (ACP.gameObject.GetComponent<ACP_PayloadTPL>().Checked == true)

                    {

                        Debug.Log("ACP is Checked changecolournormal");
                        Material[] mat = ACP.gameObject.GetComponent<Renderer>().materials;
                        mat[0] = PalletChecked;
                        mat[1] = PalletChecked;
                        mat[2] = PalletChecked;
                        ACP.gameObject.GetComponent<Renderer>().materials = mat;
                        ACP.transform.parent.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = enabled;



                    }
                    else if (ACP.gameObject.GetComponent<ACP_PayloadTPL>().Checked == false)


                    {
                        Debug.Log("ACP is not checked changecolournormal");
                        Material[] mat = ACP.gameObject.GetComponent<Renderer>().materials;
                        mat[0] = BlueNormal;
                        mat[1] = BlueNormal;
                        mat[2] = BlueNormal;
                        ACP.gameObject.GetComponent<Renderer>().materials = mat;
                        ACP.transform.parent.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = enabled;


                    }

                }
            }
        }

      
    }


    public void Update()
    {
        NumberDisplay.GetComponent<TextMeshProUGUI>().text = Palletarray.Count.ToString();
    }

    public static void TurnPalletArrayColliderson()
    {
        int i = Palletarray.Count;
        Debug.Log("PalletArray ===" + i);

        if (i >= 1)



        {
            foreach (GameObject ACP in Palletarray)

            {
                ACP.transform.parent.transform.parent.transform.GetComponent<BoxCollider>().enabled = true;
            }

        }

    }
}








