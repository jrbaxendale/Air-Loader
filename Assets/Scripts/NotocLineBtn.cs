using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotocLineBtn : MonoBehaviour
{
    public bool CheckedBool;
  public void NOTOCchecked()
  {
      TextMeshProUGUI a = gameObject.transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>();
        a.color = Color.green;
      TextMeshProUGUI b = gameObject.transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>();
        b.color = Color.green;
      TextMeshProUGUI c = gameObject.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>();
        c.color = Color.green;
      TextMeshProUGUI d = gameObject.transform.parent.GetChild(3).GetComponent<TextMeshProUGUI>();
        d.color = Color.green;
      TextMeshProUGUI e = gameObject.transform.parent.GetChild(4).GetComponent<TextMeshProUGUI>();
        e.color = Color.green;
      gameObject.transform.GetComponent<Button>().interactable = false;

      CheckedBool = true;
     GameObject.FindWithTag("DG").gameObject.GetComponent<Clipboard>().NotocButtonCount += 1;
      GameObject.FindWithTag("DG").gameObject.GetComponent<Clipboard>().CheckAllNOTOCs();
     


  }
}
