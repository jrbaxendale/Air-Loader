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
        

        void DropdownValueChanged(Dropdown change)
        {
            m_Text.text = "New Value : " + change.value;
        }






    }

}



