using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Easiersave : MonoBehaviour
{
    public TextMeshProUGUI TheWeight;

    public void saving()
    {



        TheWeight.text = makeACP.weight.text;
    }

}
