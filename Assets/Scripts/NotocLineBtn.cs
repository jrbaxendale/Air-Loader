using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotocLineBtn : MonoBehaviour
{
  public void NOTOCchecked()
  {
      TextMeshProUGUI a = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
      a.color = Color.green;
      TextMeshProUGUI b = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
      b.color = Color.green;
      TextMeshProUGUI c = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
      c.color = Color.green;
      TextMeshProUGUI d = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
      d.color = Color.green;
      TextMeshProUGUI e = gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
      e.color = Color.green;
      gameObject.transform.GetChild(5).GetComponent<Button>().interactable = false;

    }
}
