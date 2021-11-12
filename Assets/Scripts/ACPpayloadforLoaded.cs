using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ACPpayloadforloaded : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI Title;

    [SerializeField]
    public bool Locks;

    [SerializeField]
    public bool weight;

    [SerializeField]
    public bool location;

    [SerializeField]
    public bool dg;

    public void Awake()
    {
        Title.text = gameObject.transform.name;


    }







}
