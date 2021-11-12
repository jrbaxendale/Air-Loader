using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;

public class DropDown1 : MonoBehaviour
{
    [SerializeField]
    AssetReferenceGameObject Vehicle;
    public TextMeshProUGUI m_Text;
    public GameObject TiedownPoints;




    public void ChangeText(int value)
    {
        if (value == 0)
        {
            m_Text.text = "Option A";
        }

        if (value == 1)
        {
            m_Text.text = "Option B";
        }

        if (value == 2)
        {
            m_Text.text = "Option C";
        }

        

    }

    public void ChangeDropmenu()
    {
        if (GetComponent<TMP_Dropdown>().captionText.text == "TDS 378")
        {
            m_Text.text = "TDS 378 Loaded";
            Addressables.InstantiateAsync(Vehicle);
            TiedownPoints.SetActive(true);

        }
     


    }
}



