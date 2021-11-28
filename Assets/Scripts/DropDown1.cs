using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public DropDown DropDownMenu;
    public Text m_Text;


    private void Start()
    {


        GetComponent<Dropdown>().onValueChanged.AddListener(delegate
        {
          //  DropdownValueChanged(DropDownMenu);

        });
        

#pragma warning disable CS8321 // The local function 'DropdownValueChanged' is declared but never used
        void DropdownValueChanged(Dropdown change)
#pragma warning restore CS8321 // The local function 'DropdownValueChanged' is declared but never used
        {
            m_Text.text = "New Value : " + change.value;
        }






    }

}



